using OpenMate.Work.Resources.Uitilities;
using System;

namespace OpenMate.Work.Model
{
    public class Sprint : BaseViewModel
    {
        public int Id { get; set; }
        public int Order { get; set; }
        public string ProjectID { get; set; }
        public string SprintName => $"Sprint {Order}";
        public int Todo { get; set; }
        public int Doing { get; set; }
        public int Review { get; set; }
        public int Finish { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Today;
        public DateTime EndDate { get; set; } = DateTime.Today;

        private string _Status;
        public string Status
        {
            get => _Status;
            set => SetProperty(ref _Status, value);
        }
    }
}
