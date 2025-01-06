namespace OpenMate.API.Domain.DTOs
{
    public class SprintStatisticsDto
    {
        public List<int> StoryPoints { get; set; } = new List<int>();
        public List<(string, int)> Defects { get; set; } = new List<(string, int)>();
    }
}
