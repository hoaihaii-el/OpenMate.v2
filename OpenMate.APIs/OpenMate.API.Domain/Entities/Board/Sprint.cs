using System.ComponentModel.DataAnnotations;

namespace OpenMate.API.Domain.Entities.Board
{
    public class Sprint
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(10)]
        public string? ProjectID { get; set; }
        public int Order { get; set; }
        [MaxLength(50)]
        public string? Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
