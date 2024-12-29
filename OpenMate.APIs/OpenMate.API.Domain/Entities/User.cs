using System.ComponentModel.DataAnnotations;

namespace OpenMate.API.Domain.Entities
{
    public class User
    {
        [Key]
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? DisplayName { get; set; }
        public string? MainRole { get; set; }
        public string? SkillSet { get; set; }
    }
}
