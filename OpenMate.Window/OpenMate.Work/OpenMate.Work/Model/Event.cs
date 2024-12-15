﻿using OpenMate.Work.Helpers;
using OpenMate.Work.Resources.Uitilities;
using OpenMate.Work.Views.Boards;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace OpenMate.Work.Model
{
    public class Event : BaseViewModel
    {
        public string ID { get; set; }

        private string _Title;
        public string Title
        {
            get => _Title;
            set => SetProperty(ref _Title, value);
        }

        private DateTime _StartTime;
        public DateTime StartTime
        {
            get => _StartTime;
            set
            {
                if (SetProperty(ref _StartTime, value))
                {
                    OnPropertyChanged(nameof(Top));
                    OnPropertyChanged(nameof(Left));
                    OnPropertyChanged(nameof(Time));
                    OnPropertyChanged(nameof(Height));
                }
            }
        }

        private DateTime _EndTime;
        public DateTime EndTime
        {
            get => _EndTime;
            set
            {
                if (SetProperty(ref _EndTime, value))
                {
                    OnPropertyChanged(nameof(Time));
                    OnPropertyChanged(nameof(Height));
                }
            }
        }

        private string _Location;
        public string Location
        {
            get => _Location;
            set => SetProperty(ref _Location, value);
        }

        private string _MeetingURL;
        public string MeetingURL
        {
            get => _MeetingURL; 
            set => SetProperty(ref _MeetingURL, value);
        }

        private ObservableCollection<Attendee> _Attendees;
        public ObservableCollection<Attendee> Attendees
        {
            get => _Attendees;
            set => SetProperty(ref _Attendees, value);
        }

        public ICommand RemoveAttendeeCM { get; set; }

        private string _EventType = "General";
        public string EventType
        {
            get => _EventType;
            set => SetProperty(ref _EventType, value);
        }
        public double Top
        {
            get => StartTime.Hour * 60 + StartTime.Minute;
        }
        public double Left
        {
            get => Helper.DayOfWeekWidth[StartTime.DayOfWeek];
        }

        public string Time
        {
            get => $"{StartTime.Hour}h{(StartTime.Minute > 0 ? StartTime.Minute.ToString() : String.Empty)}" +
                $" - {EndTime.Hour}h{(EndTime.Minute > 0 ? EndTime.Minute.ToString() : String.Empty)}";
        }

        public double Height
        {
            get
            {
                if ((EndTime.Hour * 60 + EndTime.Minute) - (StartTime.Hour * 60 + StartTime.Minute) - 5 < 0)
                {
                    return 55;
                }
                else
                {
                    return (EndTime.Hour * 60 + EndTime.Minute) - (StartTime.Hour * 60 + StartTime.Minute) - 5;
                }
            }
        }

        public Event()
        {
            RemoveAttendeeCM = new RelayCommand<Attendee>((p) => true, (p) =>
            {
                Attendees.Remove(p);
            });
        }
    }
}
