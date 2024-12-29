namespace OpenMate.API.Domain.DTOs
{
    public class EventDto
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string? Location { get; set; }
        public string? CreatedBy { get; set; }
        public string? MeetingUrl { get; set; }
        public int RemindBefore { get; set; } = 15;
        public List<string?>? AttendeesId { get; set; }
    }
}
