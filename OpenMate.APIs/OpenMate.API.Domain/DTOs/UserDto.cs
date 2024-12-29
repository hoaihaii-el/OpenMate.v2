using System.ComponentModel.DataAnnotations;

namespace OpenMate.API.Domain.DTOs
{
    public class UserDto
    {
        [Required]
        public string? Id { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? Name { get; set; }
        public string? MainRole { get; set; }
        public string? SkillSet { get; set; }
    }
}
