using OpenMate.Work.Resources.Uitilities;
using OpenMate.Work.Views.Chats;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace OpenMate.Work.ViewModel.Chats
{
    public partial class ChatVM : BaseViewModel
    {
        private ObservableCollection<string> _Images;
        public ObservableCollection<string> Images
        {
            get => _Images;
            set => SetProperty(ref _Images, value);
        }

        public ICommand OpenChatDetailCM { get; set; }
        public ICommand RemoveCurParticipantCM { get; set; }

        private ObservableCollection<string> _PinnedMessages;
        public ObservableCollection<string> PinnedMessages
        {
            get => _PinnedMessages;
            set => SetProperty(ref _PinnedMessages, value);
        }

        private ObservableCollection<string> _CurParticipants;
        public ObservableCollection<string> CurParticipants
        {
            get => _CurParticipants;
            set => SetProperty(ref _CurParticipants, value);
        }

        public void HandleChatDetail()
        {
            OpenChatDetailCM = new RelayCommand<object>((p) => true, (p) =>
            {
                Images = new ObservableCollection<string>()
                {
                    "https://images8.alphacoders.com/133/1336966.jpeg",
                    "https://images8.alphacoders.com/133/1336966.jpeg",
                    "https://images8.alphacoders.com/133/1336966.jpeg"
                };
                PinnedMessages = new ObservableCollection<string>()
                {
                    "Real Madrid",
                    "Li Europan lingues es membres del sam familie. Lor separat existentie es un myth.",
                    "Li Europan lingues es membres del sam familie. Lor separat existentie es un myth.",
                    "Li Europan lingues es membres del sam familie. Lor separat existentie es un myth.",
                };
                CurParticipants = new ObservableCollection<string>()
                {
                    "Bray",
                    "YoungH",
                    "Dlow",
                };

                var chatDetail = new ChatDetails();
                chatDetail.DataContext = this;
                chatDetail.ShowDialog();
            });

            RemoveCurParticipantCM = new RelayCommand<string>((p) => true, (p) =>
            {
                if (CurParticipants.Contains(p))
                {
                    CurParticipants.Remove(p);
                }
            });
        }
    }
}
