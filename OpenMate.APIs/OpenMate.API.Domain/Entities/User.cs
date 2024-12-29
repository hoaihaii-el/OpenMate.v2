using System.ComponentModel.DataAnnotations;

namespace OpenMate.API.Domain.Entities
{
    public class User
    {
        [Key]
        [MaxLength(10)]
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        [MaxLength(50)]
        public string? DisplayName { get; set; }
        public string? MainRole { get; set; }
        [MaxLength(200)]
        public string? SkillSet { get; set; }
    }
}
