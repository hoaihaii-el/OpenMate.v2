using Microsoft.EntityFrameworkCore;
using OpenMate.API.Domain.DTOs;
using OpenMate.API.Domain.Entities.Chat;
using OpenMate.API.Domain.Interfaces;
using OpenMate.API.Domain.Responses;
using OpenMate.API.Infrastructure.Data;

namespace OpenMate.API.Infrastructure.Services
{
    public class ChatService(DataContext context) : IChatService
    {
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

        public async Task<IEnumerable<Message>> GetMessages(string roomId)
        {
            return await context.Messages.Where(m => m.RoomId == roomId).ToListAsync();
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

        public async Task<IEnumerable<Room>> GetRooms(string userId)
        {
            var involed = await context.Participants
                .Where(p => p.UserId == userId)
                .Select(p => p.RoomId)
                .ToListAsync();

            return await context.Rooms.Where(r => involed.Contains(r.Id)).ToListAsync();
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
    }
}
