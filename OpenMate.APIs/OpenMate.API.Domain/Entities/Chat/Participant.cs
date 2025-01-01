using System.ComponentModel.DataAnnotations;

namespace OpenMate.API.Domain.Entities.Chat
{
    public class Participant
    {
        [Key]
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public string? UserId { get; set; }
    }
}
