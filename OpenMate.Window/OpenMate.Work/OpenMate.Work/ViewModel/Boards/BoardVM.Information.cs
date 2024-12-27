using OpenMate.Work.Model;
using OpenMate.Work.Resources.Uitilities;
using System.Collections.ObjectModel;

namespace OpenMate.Work.ViewModel.Boards
{
    public partial class BoardVM : BaseViewModel
    {
        private ObservableCollection<ProjectMember> _Members;
        public ObservableCollection<ProjectMember> Members
        {
            get => _Members;
            set => SetProperty(ref _Members, value);
        }

        public void HandleProjectMember()
        {
            Members = new ObservableCollection<ProjectMember>
            {
                new ProjectMember
                {
                    Name = "Hoai Hai",
                    Effort = 0.5
                },
                new ProjectMember
                {
                    Name = "Hoai Nhan",
                    Effort = 1
                },
            };
        }
    }
}
