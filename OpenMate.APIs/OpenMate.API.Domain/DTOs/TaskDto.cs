namespace OpenMate.API.Domain.DTOs
{
    public class TaskDto
    {
        public int? SprintID { get; set; }
        public string? Title { get; set; }
        public string? OwnerID { get; set; }
        public string? AssigneeID { get; set; }
        public string? ReviewerID { get; set; }
        public string? TesterID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? TicketType { get; set; }
        public string? Priority { get; set; }
        public int StoryPoint { get; set; }
        public string? Status { get; set; }
        public int MoveFromSprint { get; set; }
    }
}
