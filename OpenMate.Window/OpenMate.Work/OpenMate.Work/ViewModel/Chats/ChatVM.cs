using Microsoft.Win32;
using OpenMate.Work.Helpers;
using OpenMate.Work.Model;
using OpenMate.Work.Requests;
using OpenMate.Work.Resources.Uitilities;
using OpenMate.Work.Services;
using OpenMate.Work.Views.Chats;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
            set
            {
                _Messages = value;
                OnPropertyChanged(nameof(Messages));
                OnPropertyChanged(nameof(Images));
                OnPropertyChanged(nameof(PinnedMessages));
            }
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
        public ICommand OpenFileUrlCM { get; set; }
        public ICommand PinMessageCM { get; set; }

        public ChatVM()
        {
            HanldeAddNewChat();
            HandleChatDetail();

            Spaces = new ObservableCollection<Room>()
            {
                new Room()
                {
                    Id = -1,
                    Title = "GENERAL"
                },
                new Room()
                {
                    Id = -2,
                    Title = "ACTIVITIES"
                },
                new Room()
                {
                    Id = -3,
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

            OpenFileUrlCM = new RelayCommand<Message>((p) => true, (p) =>
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = p.MediaUrl,
                    UseShellExecute = true
                });
            });

            //PinMessageCM = new RelayCommand<object>((p) => true, (p) =>
            //{
            //    p.IsPinned = !p.IsPinned;
            //    OnPropertyChanged(nameof(Messages));
            //});
        }

        public async void GetRooms()
        {
            try
            {
                Rooms = new ObservableCollection<Room>(await chatService.GetRooms(Helper.CurrentUserId));

                if (Rooms.Count > 0)
                {
                    SelectedBox = Rooms[0];
                }
            }
            catch
            {
                return;
            }
        }

        public async void GetMessages(int roomId)
        {
            if (roomId == -1)
            {
                Messages = new ObservableCollection<Message>()
                {
                    new Message()
                    {
                        Id = 1,
                        SenderId = "24001",
                        Text = "Hello",
                        Sender = "Hoài Hải",
                    },
                    new Message()
                    {
                        Id = 1,
                        SenderId = "24002",
                        Text = "Đặt trà sữa mọi người ới",
                        Sender = "Hoài Nhân",
                    },
                    new Message()
                    {
                        Id = 1,
                        SenderId = "24004",
                        Text = "Oke kkkk",
                        Sender = "Minh Ngọc",
                    },
                    new Message()
                    {
                        Id = 1,
                        SenderId = "24001",
                        Text = "=))))))))",
                        Sender = "Hoài Hải",
                    },
                };
            }
            else
            if (roomId == -2)
            {
                Messages = new ObservableCollection<Message>()
                {
                    new Message()
                    {
                        Id = 1,
                        SenderId = "24006",
                        Text = "Chiều nay 6h ra sân nha mọi người",
                        Sender = "Hoài An",
                    },
                    new Message()
                    {
                        Id = 1,
                        SenderId = "24002",
                        Text = "Sân nào vậy ta",
                        Sender = "Hoài Nhân",
                    },
                    new Message()
                    {
                        Id = 1,
                        SenderId = "24001",
                        Text = "Sân Chảo Lửa gần sân bay á chú",
                        MediaUrl = "https://sanbanh.com/wp-content/uploads/2024/12/san-banh-chao-lua.jpg",
                        MediaType = "Image",
                        Sender = "Hoài Hải",
                    },
                    new Message()
                    {
                        Id = 1,
                        SenderId = "24008",
                        Text = "Ra sân ăn mừng Việt Nam vô địch =)))))",
                        Sender = "Thanh Bảo",
                    },
                };
            }
            else 
            if (roomId == -3)
            {
                Messages = new ObservableCollection<Message>()
                {
                    new Message()
                    {
                        Id = 1,
                        SenderId = "24001",
                        Text = "Mọi người ơi, làm sao để kết nối API trong WPF vậy?",
                        Sender = "Hoài Hải",
                    },
                    new Message()
                    {
                        Id = 2,
                        SenderId = "24002",
                        Text = "Cậu có thể dùng HttpClient. Tớ có ví dụ nè, để tớ gửi cho.",
                        Sender = "Hoài Nhân",
                    },
                    new Message()
                    {
                        Id = 3,
                        SenderId = "24004",
                        Text = "Đúng rồi, HttpClient tốt lắm. Nhớ bắt lỗi trường hợp API không phản hồi nữa nhé!",
                        Sender = "Minh Ngọc",
                    },
                    new Message()
                    {
                        Id = 4,
                        SenderId = "24001",
                        Text = "Cảm ơn mọi người! Tớ sẽ thử ngay. Có gì không hiểu tớ hỏi tiếp nhé!",
                        Sender = "Hoài Hải",
                    },
                };

            }
            else
            {
                Messages = new ObservableCollection<Message>(await chatService.GetMessages(roomId));
            }
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
                    Text = ofd.FileName,
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
