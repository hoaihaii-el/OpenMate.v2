using OpenMate.Work.Model;
using System.Collections.Generic;

namespace OpenMate.Work.Requests
{
    public class RoomReq
    {
        public string Title { get; set; }
        public string CreatedBy { get; set; }
        public List<Attendee> Participants { get; set; }
    }
}
