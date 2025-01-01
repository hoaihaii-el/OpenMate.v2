using System.ComponentModel.DataAnnotations;

namespace OpenMate.API.Domain.Entities.Board
{
    public class Project
    {
        [Key]
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? CustomerName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        [MaxLength(50)]
        public string? ProductType { get; set; }
        [MaxLength(10)]
        public string? ProjectManager { get; set; }
        [MaxLength(50)]
        public string? Status { get; set; }
    }
}
