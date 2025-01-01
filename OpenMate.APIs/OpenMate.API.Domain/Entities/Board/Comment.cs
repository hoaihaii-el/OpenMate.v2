using System.ComponentModel.DataAnnotations;

namespace OpenMate.API.Domain.Entities.Board
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(10)]
        public string? TaskID { get; set; }
        public string? CommentText { get; set; }
        [MaxLength(10)]
        public string? Commenter { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime CommentDate { get; set; }
    }
}
