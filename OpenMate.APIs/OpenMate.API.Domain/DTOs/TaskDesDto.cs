namespace OpenMate.API.Domain.DTOs
{
    public class TaskDesDto
    {
        public string? TaskID { get; set; }
        public int Order { get; set; }
        public bool IsImage { get; set; }
        public string? Xaml { get; set; }
        public string? ImageUrl { get; set; }
    }
}
