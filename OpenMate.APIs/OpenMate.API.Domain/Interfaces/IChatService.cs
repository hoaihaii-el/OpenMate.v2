using OpenMate.API.Domain.DTOs;
using OpenMate.API.Domain.Entities.Chat;
using OpenMate.API.Domain.Responses;

namespace OpenMate.API.Domain.Interfaces
{
    public interface IChatService
    {
        Task<IEnumerable<RoomRes>> GetRooms(string userId);
        Task<RoomDto> GetRoom(int roomId);
        Task CreateRoom(RoomDto room);
        Task<IEnumerable<MessageRes>> GetMessages(int roomId);
        Task CreateMessage(MessageDto message);
        Task PinMessage(string messageId);
        Task ReadMessage(string messageId);
        Task CreateUserCalendar(string userId);
        Task CreateUserBoard(string userId);
        Task AddBoardNotification(string userId, string content);
        Task AddCalendarNotification(string userId, string content);
        Task<IEnumerable<Message>> GetPinnedMessages(int roomId);

        Task<string> UploadFile(FileDto file);
    }
}
