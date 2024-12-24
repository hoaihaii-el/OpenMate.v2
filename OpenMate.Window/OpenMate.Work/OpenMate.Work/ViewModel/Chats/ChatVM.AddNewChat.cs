using OpenMate.Work.Resources.Uitilities;
using OpenMate.Work.Views.Chats;
using System.Collections.ObjectModel;
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
                if (Suggestions.Contains(_NewParticipant))
                {
                    Participants.Add(_NewParticipant);
                }
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> _Participants;
        public ObservableCollection<string> Participants
        {
            get => _Participants;
            set => SetProperty(ref _Participants, value);
        }

        private ObservableCollection<string> _Suggestions;
        public ObservableCollection<string> Suggestions
        {
            get => _Suggestions;
            set => SetProperty(ref _Suggestions, value);
        }

        public ICommand OpenAddNewChatCM { get; set; }
        public ICommand RemoveParticipantCM { get; set; }
        public ICommand AddNewChatCM { get; set; }

        public void HanldeAddNewChat()
        {
            Suggestions = new ObservableCollection<string>()
            {
                "3912_Hoài Hải",
                "3098_Hải Đăng"
            };

            OpenAddNewChatCM = new RelayCommand<object>((p) => true, (p) =>
            {
                var newChat = new NewConversation();
                newChat.DataContext = this;
                Participants = new ObservableCollection<string>();
                newChat.ShowDialog();
            });

            RemoveParticipantCM = new RelayCommand<string>((p) => true, (p) =>
            {
                if (Participants.Contains(p))
                {
                    Participants.Remove(p);
                }
            });
        }

        public void AddNewParticipant()
        {
            if (!string.IsNullOrEmpty(NewParticipant))
            {
                Participants.Add(NewParticipant);
            }
            NewParticipant = "";
        }
    }
}
