namespace OpenMate.API.Domain.Entities.Calendar
{
    public class EventParticipants
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string? UserId { get; set; }
    }
}
