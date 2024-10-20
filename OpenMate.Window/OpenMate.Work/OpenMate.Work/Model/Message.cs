using OpenMate.Work.Resources.Uitilities;
using System;

namespace OpenMate.Work.Model
{
    public class Message : BaseViewModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int SenderId { get; set; }

        public string SenderUrl { get; set; }

        private bool _IsFromUser;
        public bool IsFromUser
        {
            get => _IsFromUser;
            set => SetProperty(ref _IsFromUser, value);
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
