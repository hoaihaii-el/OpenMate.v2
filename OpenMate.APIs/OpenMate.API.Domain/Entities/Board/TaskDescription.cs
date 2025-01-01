using System.ComponentModel.DataAnnotations;

namespace OpenMate.API.Domain.Entities.Board
{
    public class TaskDescription
    {
        [Key]
        public int Id { get; set; }
        public string? TaskID { get; set; }
        public int Order { get; set; }
        public bool IsImage { get; set; }
        public string? Xaml { get; set; }
        public string? ImageUrl { get; set; }
    }
}
