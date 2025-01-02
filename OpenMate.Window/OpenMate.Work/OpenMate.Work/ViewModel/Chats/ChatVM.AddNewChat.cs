using OpenMate.Work.Helpers;
using OpenMate.Work.Model;
using OpenMate.Work.Requests;
using OpenMate.Work.Resources.Uitilities;
using OpenMate.Work.Views.Chats;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace OpenMate.Work.ViewModel.Chats
{
    public partial class ChatVM : BaseViewModel
    {
        private string _NewChatName;
        public string NewChatName
        {
            get => _NewChatName;
            set => SetProperty(ref _NewChatName, value);
        }

        private string _NewParticipant;
        public string NewParticipant
        {
            get => _NewParticipant;
            set
            {
                _NewParticipant = value;
                if (!string.IsNullOrEmpty(value))
                {
                    Suggestions = new ObservableCollection<Attendee>
                        (Helper.Attendees
                            .Where(p => p.Name.ToLower().Contains(value.ToLower()) || p.ID.Contains(value))
                            .ToList()
                        );
                }
                else
                {
                    Suggestions.Clear();
                }
                OnPropertyChanged(nameof(NewParticipant));
                OnPropertyChanged(nameof(Suggestions));
                OnPropertyChanged();
            }
        }

        private ObservableCollection<Attendee> _Participants;
        public ObservableCollection<Attendee> Participants
        {
            get => _Participants;
            set => SetProperty(ref _Participants, value);
        }

        private ObservableCollection<Attendee> _Suggestions = new ObservableCollection<Attendee>();
        public ObservableCollection<Attendee> Suggestions
        {
            get => _Suggestions;
            set => SetProperty(ref _Suggestions, value);
        }

        public ICommand OpenAddNewChatCM { get; set; }
        public ICommand RemoveParticipantCM { get; set; }
        public ICommand AddNewChatCM { get; set; }

        public void HanldeAddNewChat()
        {
            OpenAddNewChatCM = new RelayCommand<object>((p) => true, (p) =>
            {
                var newChat = new NewConversation();
                newChat.DataContext = this;
                Participants = new ObservableCollection<Attendee>();
                newChat.ShowDialog();
            });

            RemoveParticipantCM = new RelayCommand<Attendee>((p) => true, (p) =>
            {
                if (Participants.Contains(p))
                {
                    Participants.Remove(p);
                }
            });
        }

        public void AddNewChat()
        {
            chatService.AddRoom(new RoomReq()
            {
                Title = NewChatName,
                CreatedBy = Helper.CurrentUserId,
                Participants = Participants.ToList()
            });
        }
    }
}
