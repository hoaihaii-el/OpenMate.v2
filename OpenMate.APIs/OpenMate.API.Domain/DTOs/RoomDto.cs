using OpenMate.API.Domain.Responses;

namespace OpenMate.API.Domain.DTOs
{
    public class RoomDto
    {
        public string? Title { get; set; }
        public string? CreatedBy { get; set; }
        public List<AttendeeRes>? Participants { get; set; }
    }
}
