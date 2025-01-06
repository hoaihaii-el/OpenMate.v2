using System.Collections.Generic;

namespace OpenMate.Work.Model
{
    public class SprintStat
    {
        public List<int> StoryPoints { get; set; } = new List<int>();
        public List<(string, int)> Defects { get; set; } = new List<(string, int)>();
    }
}
