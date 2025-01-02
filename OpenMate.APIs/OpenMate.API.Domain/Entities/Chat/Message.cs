using System.ComponentModel.DataAnnotations;

namespace OpenMate.API.Domain.Entities.Chat
{
    public class Message
    {
        [Key]
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public string? SenderId { get; set; }
        public string? Text { get; set; }
        public string? MediaUrl { get; set; }
        public string? MediaType { get; set; }
        public bool IsPinned { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
