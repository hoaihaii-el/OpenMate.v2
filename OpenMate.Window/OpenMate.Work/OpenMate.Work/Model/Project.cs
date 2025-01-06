using System.Collections.Generic;
using System;
using System.Collections.ObjectModel;

namespace OpenMate.Work.Model
{
    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CustomerName { get; set; }
        public DateTime StartDate { get; set; } = DateTime.Today;
        public DateTime EndDate { get; set; } = DateTime.Today;
        public string ProductType { get; set; }
        public Attendee ProjectManager { get; set; }

        private ObservableCollection<ProjectMember> _Members = new ObservableCollection<ProjectMember>();
        public ObservableCollection<ProjectMember> Members
        {
            get => _Members;
            set => _Members = value;
        }
        public string Status { get; set; }
    }
}
