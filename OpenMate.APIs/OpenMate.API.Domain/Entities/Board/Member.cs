using System.ComponentModel.DataAnnotations;

namespace OpenMate.API.Domain.Entities.Board
{
    public class Member
    {
        [Key]
        public int? Id { get; set; }
        [MaxLength(10)]
        public string? MemberID { get; set; }
        [MaxLength(10)]
        public string? ProjectID { get; set; }
        public string? Role { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime LeaveDate { get; set; }
    }
}
