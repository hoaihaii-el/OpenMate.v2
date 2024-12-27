using OpenMate.Work.Model;
using OpenMate.Work.Resources.Uitilities;
using System.Collections.ObjectModel;

namespace OpenMate.Work.ViewModel.Boards
{
    public partial class BoardVM : BaseViewModel
    {
        private ObservableCollection<Task> _BackLogs;
        public ObservableCollection<Task> BackLogs
        {
            get => _BackLogs;
            set => SetProperty(ref _BackLogs, value);
        }

        public void InitBackLog()
        {
            BackLogs = new ObservableCollection<Task>()
            {
                new Task
                {
                    Title = "Update ABC",
                    Assignee = "Hoai Hai",
                    Id = "OM-121",
                },
                new Task
                {
                    Title = "Add ABC",
                    Assignee = "Minh Ngoc",
                    Id = "OM-122",
                },
                new Task
                {
                    Title = "Delete ABC",
                    Assignee = "Hoai Nhan",
                    Id = "OM-123",
                },
            };
        }
    }
}
