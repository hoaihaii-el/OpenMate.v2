namespace OpenMate.API.Domain.Responses
{
    public class MessageRes
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public string? SenderId { get; set; }
        public string? Sender { get; set; }
        public string? Text { get; set; }
        public string? MediaUrl { get; set; }
        public string? MediaType { get; set; }
        public bool IsPinned { get; set; }
    }
}
