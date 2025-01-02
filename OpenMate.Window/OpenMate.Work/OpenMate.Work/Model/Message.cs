using OpenMate.Work.Helpers;
using OpenMate.Work.Resources.Uitilities;
using System;

namespace OpenMate.Work.Model
{
    public class Message : BaseViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }

        private string _SenderId;
        public string SenderId
        {
            get => _SenderId;
            set
            {
                _SenderId = value;
                OnPropertyChanged(nameof(SenderId));
                OnPropertyChanged(nameof(IsFromUser));
            }
        }

        private string _Sender;
        public string Sender
        {
            get => _Sender;
            set => SetProperty(ref _Sender, value);
        }
        public string MediaUrl { get; set; }
        public string MediaType { get; set; }

        public bool IsFromUser
        {
            get => SenderId == Helper.CurrentUserId;
        }

        private bool _IsPinned;
        public bool IsPinned
        {
            get => _IsPinned;
            set => SetProperty(ref _IsPinned, value);
        }
        public int RoomId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
