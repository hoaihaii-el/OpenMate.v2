namespace OpenMate.Work.Model
{
    public class Task
    {
        public string Id { get; set; }  
        public int Sprint { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Priority { get; set; } = "Medium";
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public string Status { get; set; }
        public string Assignee { get; set; }
        public string Reviewer { get; set; }
        public string Tester { get; set; }
        public string Owner { get; set; }
        public int? MoveFromSprint { get; set; }
    }
}
