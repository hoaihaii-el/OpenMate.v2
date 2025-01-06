namespace OpenMate.API.Domain.DTOs
{
    public class SprintDto
    {
        public int Id { get; set; }
        public string? ProjectID { get; set; }
        public int Order { get; set; }
        public string? Status { get; set; }
        public int Todo { get; set; }
        public int Doing { get; set; }
        public int Review { get; set; }
        public int Finish { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
