using System.ComponentModel.DataAnnotations;

namespace OpenMate.API.Domain.Entities.Chat
{
    public class Room
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        [MaxLength(10)]
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
