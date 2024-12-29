using System.ComponentModel.DataAnnotations;

namespace OpenMate.API.Domain.Entities
{
    public class User
    {
        [Key]
        [MaxLength(10)]
        public string? Id { get; set; }
        public string? PasswordHash { get; set; }
        [MaxLength(50)]
        public string? Name { get; set; }
        public string? MainRole { get; set; }
        [MaxLength(200)]
        public string? SkillSet { get; set; }
    }
}
