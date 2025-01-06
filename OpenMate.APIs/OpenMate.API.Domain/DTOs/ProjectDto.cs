using OpenMate.API.Domain.Responses;

namespace OpenMate.API.Domain.DTOs
{
    public class ProjectDto
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CustomerName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? ProductType { get; set; }
        public AttendeeRes? ProjectManager { get; set; }
        public List<MemberRes>? Members { get; set; }
        public string? Status { get; set; }
    }
}
