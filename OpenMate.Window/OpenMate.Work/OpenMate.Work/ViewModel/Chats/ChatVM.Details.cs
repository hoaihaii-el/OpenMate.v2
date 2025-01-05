using OpenMate.Work.Model;
using OpenMate.Work.Resources.Uitilities;
using OpenMate.Work.Views.Chats;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace OpenMate.Work.ViewModel.Chats
{
    public partial class ChatVM : BaseViewModel
    {
        public ObservableCollection<Message> Images
        {
            get => new ObservableCollection<Message>(Messages.Where(m => m.MediaType == "Image"));
        }

        public ICommand OpenChatDetailCM { get; set; }
        public ICommand RemoveCurParticipantCM { get; set; }

        public ObservableCollection<Message> PinnedMessages
        {
            get => new ObservableCollection<Message>(Messages.Where(m => m.IsPinned));
        }

        public void HandleChatDetail()
        {
            OpenChatDetailCM = new RelayCommand<object>((p) => true, (p) =>
            {
                var chatDetail = new ChatDetails();
                chatDetail.DataContext = this;
                chatDetail.ShowDialog();
            });

            RemoveCurParticipantCM = new RelayCommand<Attendee>((p) => true, (p) =>
            {
                if (SelectedBox.Participants.Contains(p))
                {
                    SelectedBox.Participants.Remove(p);
                }
            });
        }
    }
}
