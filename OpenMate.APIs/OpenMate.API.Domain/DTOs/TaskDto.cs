using OpenMate.API.Domain.Responses;

namespace OpenMate.API.Domain.DTOs
{
    public class TaskDto
    {
        public string? Id { get; set; }
        public int? SprintID { get; set; }
        public string? Title { get; set; }
        public AttendeeRes? Owner { get; set; }
        public AttendeeRes? Assignee { get; set; }
        public AttendeeRes? Reviewer { get; set; }
        public AttendeeRes? Tester { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? TicketType { get; set; }
        public string? Priority { get; set; }
        public int StoryPoint { get; set; }
        public string? Status { get; set; }
        public int MoveFromSprint { get; set; }
    }
}
