using OpenMate.API.Domain.DTOs;
using OpenMate.API.Domain.Entities.Chat;

namespace OpenMate.API.Domain.Interfaces
{
    public interface IChatService
    {
        Task<IEnumerable<Room>> GetRooms(string userId);
        Task<RoomDto> GetRoom(int roomId);
        Task CreateRoom(RoomDto room);
        Task<IEnumerable<Message>> GetMessages(string roomId);
        Task CreateMessage(MessageDto message);
        Task PinMessage(string messageId);
        Task ReadMessage(string messageId);
    }
}
