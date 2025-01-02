using Microsoft.Win32;
using OpenMate.Work.Helpers;
using OpenMate.Work.Model;
using OpenMate.Work.Requests;
using OpenMate.Work.Resources.Uitilities;
using OpenMate.Work.Services;
using OpenMate.Work.Views.Chats;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows.Input;

namespace OpenMate.Work.ViewModel.Chats
{
    public partial class ChatVM : BaseViewModel
    {
        private ChatService chatService = new ChatService();

        private ObservableCollection<Room> _Rooms = new ObservableCollection<Room>();
        public ObservableCollection<Room> Rooms
        {
            get => _Rooms;
            set => SetProperty(ref _Rooms, value);
        }

        private ObservableCollection<Room> _Spaces = new ObservableCollection<Room>();
        public ObservableCollection<Room> Spaces
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

        private Room _SelectedBox;
        public Room SelectedBox
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

                GetMessages(value.Id);
                OnPropertyChanged(nameof(Messages));
                OnPropertyChanged(nameof(SelectedBox));
            }
        }

        public ICommand UploadFileCM { get; set; }
        public ICommand OpenVideoViewerCM { get; set; }

        public ChatVM()
        {
            HanldeAddNewChat();
            HandleChatDetail();

            Spaces = new ObservableCollection<Room>()
            {
                new Room()
                {
                    Id = 1,
                    Title = "GENERAL"
                },
                new Room()
                {
                    Id = 2,
                    Title = "ACTIVITIES"
                },
                new Room()
                {
                    Id = 3,
                    Title = "Q & A"
                },
            };

            GetRooms();

            UploadFileCM = new RelayCommand<object>((p) => true, (p) =>
            {
                UploadFile();
            });

            OpenVideoViewerCM = new RelayCommand<Message>((p) => true, (p) =>
            {
                var videoViewer = new VideoViewer(p.MediaUrl);
                videoViewer.ShowDialog();
            });
        }

        public async void GetRooms()
        {
            Rooms = new ObservableCollection<Room>(await chatService.GetRooms("24001"));

            if (Rooms.Count > 0)
            {
                SelectedBox = Rooms[0];
            }
        }

        public async void GetMessages(int roomId)
        {
            Messages = new ObservableCollection<Message>(await chatService.GetMessages(roomId));
        }

        public void SendMessage(Message msg)
        {
            msg.RoomId = SelectedBox.Id;
            chatService.SendMessage(msg);
            GetMessages(SelectedBox.Id);
        }

        public async void UploadFile()
        {
            var ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == true)
            {
                byte[] fileBytes = File.ReadAllBytes(ofd.FileName);
                string base64String = Convert.ToBase64String(fileBytes);

                var fileUrl = await Helper.GetFileUrl(new FileReq
                {
                    Base64 = base64String,
                    FileName = Path.GetFileName(ofd.FileName),
                    FileType = IsVideo(ofd.FileName) ? "Video" : "File"
                });

                var msg = new Message()
                {
                    SenderId = Helper.CurrentUserId,
                    RoomId = SelectedBox.Id,
                    MediaType = IsVideo(ofd.FileName) ? "Video" : "File",
                    MediaUrl = fileUrl,
                };
                chatService.SendMessage(msg);
                GetMessages(SelectedBox.Id);
            }
        }

        public bool IsVideo(string fileName)
        {
            var ext = Path.GetExtension(fileName).ToLower();
            return ext == ".mp4" || ext == ".avi" || ext == ".mov" || ext == ".wmv";
        }
    }
}
