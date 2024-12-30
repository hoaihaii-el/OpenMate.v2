namespace OpenMate.API.Domain.Responses
{
    public class EventRes
    {
        public int ID { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Location { get; set; }
        public string? CreatedBy { get; set; }
        public string? MeetingUrl { get; set; }
        public int RemindBefore { get; set; }
        public List<AttendeeRes>? Attendees { get; set; }
    }
}
