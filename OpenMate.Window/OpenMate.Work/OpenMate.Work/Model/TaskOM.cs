using System;

namespace OpenMate.Work.Model
{
    public class TaskOM
    {
        public string Id { get; set; }  
        public int SprintID { get; set; }
        public string Title { get; set; }
        public Attendee Owner { get; set; }
        public Attendee Assignee { get; set; }
        public Attendee Reviewer { get; set; }
        public Attendee Tester { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string TicketType { get; set; }
        public string Priority { get; set; }
        public int StoryPoint { get; set; }
        public string Status { get; set; }
        public int? MoveFromSprint { get; set; }
    }
}
