using System.ComponentModel.DataAnnotations;

namespace OpenMate.API.Domain.Entities.Board
{
    public class TaskOM
    {
        [Key]
        public string? Id { get; set; }
        public int? SprintID { get; set; }
        public string? Title { get; set; }
        [MaxLength(10)]
        public string? OwnerID { get; set; }
        [MaxLength(10)]
        public string? AssigneeID { get; set; }
        [MaxLength(10)]
        public string? ReviewerID { get; set; }
        [MaxLength(10)]
        public string? TesterID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? TicketType { get; set; }
        [MaxLength(50)]
        public string? Priority { get; set; }
        public int StoryPoint { get; set; }
        [MaxLength(50)]
        public string? Status { get; set; }
        public int MoveFromSprint { get; set; }
    }
}
