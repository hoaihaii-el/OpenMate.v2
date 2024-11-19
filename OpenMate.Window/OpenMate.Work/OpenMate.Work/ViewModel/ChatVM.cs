using OpenMate.Work.Model;
using OpenMate.Work.Resources.Uitilities;
using System.Collections.ObjectModel;

namespace OpenMate.Work.ViewModel
{
    public class ChatVM : BaseViewModel
    {
        private ObservableCollection<User> _Users = new ObservableCollection<User>();
        public ObservableCollection<User> Users
        {
            get => _Users;
            set => SetProperty(ref _Users, value);
        }

        private ObservableCollection<User> _Spaces = new ObservableCollection<User>();
        public ObservableCollection<User> Spaces
        {
            get => _Spaces;
            set => SetProperty(ref _Spaces, value);
        }

        private ObservableCollection<Message> _Messages = new ObservableCollection<Message>();
        public ObservableCollection<Message> Messages
        {
            get => _Messages;
            set => SetProperty(ref _Messages, value);
        }

        private User _SelectedBox;
        public User SelectedBox
        {
            get => _SelectedBox;
            set
            {
                if (_SelectedBox != null)
                {
                    _SelectedBox.IsSelected = false;
                }
                value.IsSelected = true;
                _SelectedBox = value;
                OnPropertyChanged(nameof(SelectedBox));
            }
        }

        public ChatVM()
        {
            Users = new ObservableCollection<User>()
            {
                new User()
                {
                    Id = 1,
                    Name = "Hoai Hai",
                    IsSelected = true,
                },
                new User()
                {
                    Id = 1,
                    Name = "Khai Hoan"
                },
                new User()
                {
                    Id = 1,
                    Name = "Cong Phuong"
                },
            };
            SelectedBox = Users[0];

            Spaces = new ObservableCollection<User>()
            {
                new User()
                {
                    Id = 1,
                    Name = "General",
                },
                new User()
                {
                    Id = 1,
                    Name = "Activities"
                },
                new User()
                {
                    Id = 1,
                    Name = "Knowledge"
                }
            };

            Messages = new ObservableCollection<Message>
            {
                new Message()
                {
                    IsFromUser = false,
                    Text = "Task YUN-019 sao rồi chú??",
                    Sender = "Sếp"
                },
                new Message()
                {
                    IsFromUser = true,
                    Text = "Dạ em bắt đầu start từ chiều hôm qua rồi ạ",
                    Sender = "Culi"
                },
                new Message()
                {
                    IsFromUser = false,
                    Text = "Thế có blocker gì không ???",
                    Sender = "Sếp",
                    ImageUrl = "https://kenh14cdn.com/2017/images685542-a-1489655177057.jpg"
                },
                new Message()
                {
                    IsFromUser = true,
                    Text = "Dạ đang ổn anh ơi, có gì em báo ngay ạ",
                    Sender = "Culi"
                },
            };
        }
    }
}
