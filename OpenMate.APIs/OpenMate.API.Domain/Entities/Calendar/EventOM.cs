using System.ComponentModel.DataAnnotations;

namespace OpenMate.API.Domain.Entities.Calendar
{
    public class EventOM
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string? Location { get; set; }
        [MaxLength(10)]
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? MeetingUrl { get; set; }
        public int RemindBefore { get; set; } = 15;
    }
}
