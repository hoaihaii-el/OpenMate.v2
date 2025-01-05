using OpenMate.Work.Resources.Uitilities;
using System.Collections.ObjectModel;

namespace OpenMate.Work.Model
{
    public class Room : BaseViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }

        private ObservableCollection<Attendee> _Participants;
        public ObservableCollection<Attendee> Participants
        {
            get => _Participants;
            set => SetProperty(ref _Participants, value);
        }

        private bool _IsSelected;
        public bool IsSelected
        {
            get => _IsSelected;
            set
            {
                _IsSelected = value;
                if (_IsSelected == true)
                {
                    IsRead = true;
                    OnPropertyChanged(nameof(IsRead));
                }
                OnPropertyChanged(nameof(IsSelected));
            }
        }

        private bool _IsRead;
        public bool IsRead
        {
            get => _IsRead;
            set => SetProperty(ref _IsRead, value);
        }
    }
}
