using OpenMate.Work.Resources.Uitilities;
using OpenMate.Work.Views.Chats;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace OpenMate.Work.ViewModel.Chats
{
    public partial class ChatVM : BaseViewModel
    {
        public ICommand OpenImageDetailCM { get; set; }

        private ObservableCollection<string> _Images;
        public ObservableCollection<string> Images
        {
            get => _Images;
            set => SetProperty(ref _Images, value);
        }


        public ICommand OpenPinnedMessagesCM { get; set; }

        private ObservableCollection<string> _PinnedMessages;
        public ObservableCollection<string> PinnedMessages
        {
            get => _PinnedMessages;
            set => SetProperty(ref _PinnedMessages, value);
        }

        public void HandleImageDetail()
        {
            OpenImageDetailCM = new RelayCommand<object>((p) => true, (p) =>
            {
                var imageDetail = new ImageDetails();
                Images = new ObservableCollection<string>()
                {
                    "https://images8.alphacoders.com/133/1336966.jpeg",
                    "https://images8.alphacoders.com/133/1336966.jpeg",
                    "https://images8.alphacoders.com/133/1336966.jpeg"
                };
                imageDetail.DataContext = this;
                imageDetail.ShowDialog();
            });
        }

        public void HandlePinnedMessages()
        {
            OpenPinnedMessagesCM = new RelayCommand<object>((p) => true, (p) =>
            {
                var pinnedMessages = new PinnedMessages();
                PinnedMessages = new ObservableCollection<string>()
                {
                    "Real Madrid",
                    "Li Europan lingues es membres del sam familie. Lor separat existentie es un myth.",
                    "Li Europan lingues es membres del sam familie. Lor separat existentie es un myth.",
                    "Li Europan lingues es membres del sam familie. Lor separat existentie es un myth.",
                };
                pinnedMessages.DataContext = this;
                pinnedMessages.ShowDialog();
            });
        }
    }
}
