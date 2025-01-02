namespace OpenMate.API.Domain.Responses
{
    public class RoomRes
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public int ParticipantsCount { get; set; }
        public bool IsRead { get; set; }
    }
}
