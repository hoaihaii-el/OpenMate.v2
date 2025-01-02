using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.EntityFrameworkCore;
using OpenMate.API.Domain.DTOs;
using OpenMate.API.Domain.Entities.Chat;
using OpenMate.API.Domain.Interfaces;
using OpenMate.API.Domain.Responses;
using OpenMate.API.Infrastructure.Configuration;
using OpenMate.API.Infrastructure.Data;

namespace OpenMate.API.Infrastructure.Services
{
    public class ChatService : IChatService
    {
        private readonly DataContext context;
        private Cloudinary cloudinary;

        public ChatService(DataContext context)
        {
            this.context = context;

            var account = new Account(
                CloudinarySetting.CloudName, 
                CloudinarySetting.ApiKey, 
                CloudinarySetting.ApiSecret
            );

            cloudinary = new Cloudinary(account);
        }

        public async Task AddBoardNotification(string userId, string content)
        {
            var room = await context.Rooms.FirstOrDefaultAsync(r => r.Title == "BOARD" && r.CreatedBy == userId);
            var message = new Message
            {
                RoomId = room!.Id,
                SenderId = "SYSTEM",
                Text = content,
                IsPinned = false,
                IsRead = false,
                CreatedAt = DateTime.Now
            };
        }

        public async Task AddCalendarNotification(string userId, string content)
        {
            var room = await context.Rooms.FirstOrDefaultAsync(r => r.Title == "CALENDAR" && r.CreatedBy == userId);
            var message = new Message
            {
                RoomId = room!.Id,
                SenderId = "SYSTEM",
                Text = content,
                IsPinned = false,
                IsRead = false,
                CreatedAt = DateTime.Now
            };
        }

        public async Task CreateMessage(MessageDto message)
        {
            var msg = new Message
            {
                RoomId = message.RoomId,
                SenderId = message.SenderId,
                Text = message.Text,
                MediaUrl = message.MediaUrl,
                MediaType = message.MediaType,
                IsPinned = false,
                IsRead = false,
                CreatedAt = DateTime.Now
            };

            context.Messages.Add(msg);
            await context.SaveChangesAsync();
        }

        public async Task CreateRoom(RoomDto room)
        {
            var newRoom = new Room
            {
                Title = room.Title,
                CreatedBy = room.CreatedBy,
                CreatedAt = DateTime.Now
            };

            context.Rooms.Add(newRoom);
            await context.SaveChangesAsync();

            foreach (var p in room.Participants!)
            {
                var participant = new Participant
                {
                    RoomId = newRoom.Id,
                    UserId = p.ID
                };

                context.Participants.Add(participant);
            }
            await context.SaveChangesAsync();
        }

        public async Task CreateUserBoard(string userId)
        {
            var room = new Room
            {
                Title = "BOARD",
                CreatedBy = userId,
                CreatedAt = DateTime.Now
            };

            context.Rooms.Add(room);
            await context.SaveChangesAsync();

            var participant = new Participant
            {
                RoomId = room.Id,
                UserId = userId
            };

            context.Participants.Add(participant);
            await context.SaveChangesAsync();
        }

        public async Task CreateUserCalendar(string userId)
        {
            var room = new Room
            {
                Title = "CALENDAR",
                CreatedBy = userId,
                CreatedAt = DateTime.Now
            };

            context.Rooms.Add(room);
            await context.SaveChangesAsync();

            var participant = new Participant
            {
                RoomId = room.Id,
                UserId = userId
            };

            context.Participants.Add(participant);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<MessageRes>> GetMessages(int roomId)
        {
            var msgs = await context.Messages
                .Where(m => m.RoomId == roomId)
                .Select(m => new MessageRes
                {
                    Id = m.Id,
                    SenderId = m.SenderId,
                    Text = m.Text,
                    MediaUrl = m.MediaUrl,
                    MediaType = m.MediaType,
                    IsPinned = m.IsPinned,
                    RoomId = m.RoomId
                })
                .ToListAsync();

            foreach (var m in msgs)
            {
                var sender = await context.Users.FindAsync(m.SenderId);
                m.Sender = sender!.Name;
            }

            return msgs ?? new List<MessageRes>();
        }

        public async Task<IEnumerable<Message>> GetPinnedMessages(int roomId)
        {
            return await context.Messages.Where(m => m.RoomId == roomId && m.IsPinned).ToListAsync();
        }

        public async Task<RoomDto> GetRoom(int roomId)
        {
            var room = await context.Rooms
                .Where(r => r.Id == roomId)
                .Select(r => new RoomDto
                {
                    Title = r.Title,
                    CreatedBy = r.CreatedBy
                })
                .FirstOrDefaultAsync();

            var participants = await context.Participants.Where(p => p.RoomId == roomId).ToListAsync();
            foreach (var p in participants)
            {
                room!.Participants!.Add(new AttendeeRes
                {
                    ID = p.UserId,
                    Name = context.Users.Find(p.UserId)!.Name
                });
            }

            return room!;
        }

        public async Task<IEnumerable<RoomRes>> GetRooms(string userId)
        {
            var involed = await context.Participants
                .Where(p => p.UserId == userId)
                .Select(p => p.RoomId)
                .ToListAsync();

            var rooms = await context.Rooms
                .Where(r => involed.Contains(r.Id))
                .Select(r => new RoomRes
                {
                    Id = r.Id,
                    Title = r.Title,
                    CreatedBy = r.CreatedBy,
                    CreatedAt = r.CreatedAt,
                    ParticipantsCount = context.Participants.Count(p => p.RoomId == r.Id),
                    IsRead = context.Participants.FirstOrDefault(p => p.RoomId == r.Id && p.UserId == userId)!.UnReadCount == 0
                })
                .ToListAsync();

            return rooms;
        }

        public async Task PinMessage(string messageId)
        {
            var msg = await context.Messages.FindAsync(messageId);
            msg!.IsPinned = true;

            context.Messages.Update(msg);
            await context.SaveChangesAsync();
        }

        public async Task ReadMessage(string messageId)
        {
            var msg = await context.Messages.FindAsync(messageId);
            msg!.IsRead = true;

            context.Messages.Update(msg);
            await context.SaveChangesAsync();
        }

        public async Task<string> UploadFile(FileDto file)
        {
            if (string.IsNullOrEmpty(file.Base64))
            {
                throw new ArgumentNullException("Missing Base64");
            }

            var bytes = Convert.FromBase64String(file.Base64);

            if (file.FileType == "Video")
            {
                var uploadResult = new VideoUploadResult();

                using (var stream = new MemoryStream(bytes))
                {
                    var uploadParams = new VideoUploadParams
                    {
                        File = new FileDescription(file.FileName, stream),
                        UseFilename = true,
                        UniqueFilename = false,
                        Overwrite = true
                    };

                    uploadResult = await cloudinary.UploadAsync(uploadParams);
                }

                return uploadResult.Url.ToString();
            }
            else
            {
                var uploadResult = new ImageUploadResult();

                using (var stream = new MemoryStream(bytes))
                {
                    var uploadParams = new ImageUploadParams
                    {
                        File = new FileDescription(file.FileName, stream),
                        UseFilename = true,
                        UniqueFilename = false,
                        Overwrite = true
                    };

                    uploadResult = await cloudinary.UploadAsync(uploadParams);
                }

                return uploadResult.Url.ToString();
            }
        }
    }
}
