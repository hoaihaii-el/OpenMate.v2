using OpenMate.Work.Model;
using OpenMate.Work.Resources.Uitilities;

namespace OpenMate.Work.ViewModel.Boards
{
    public class BoardDetailVM : BaseViewModel
    {
        private Sprint _Sprint;
        public Sprint Sprint
        {
            get => _Sprint;
            set => SetProperty(ref _Sprint, value);
        }

        public BoardDetailVM(Sprint sprint)
        {
            Sprint = sprint;
        }
    }
}
