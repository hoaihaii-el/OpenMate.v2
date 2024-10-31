using OpenMate.Work.Resources.Uitilities;

namespace OpenMate.Work.Model
{
    public class Sprint : BaseViewModel
    {
        public string SprintName { get; set; }
        public int BackLogCount { get; set; }
        public int DoingCount { get; set; }
        public int ReviewCount { get; set; }
        public int FinishCount { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

        private string _Status;
        public string Status
        {
            get => _Status;
            set => SetProperty(ref _Status, value);
        }
    }
}
