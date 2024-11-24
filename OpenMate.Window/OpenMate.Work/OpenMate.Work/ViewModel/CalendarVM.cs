using OpenMate.Work.Model;
using OpenMate.Work.Resources.Uitilities;
using OpenMate.Work.Views.Calendars;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace OpenMate.Work.ViewModel
{
    public class CalendarVM : BaseViewModel
    {
        public ObservableCollection<string> Hours { get; set; } = new ObservableCollection<string>()
        {
            "1AM","2AM","3AM","4AM","5AM","6AM","7AM","8AM","9AM","10AM","11AM","12PM",
            "1PM","2PM","3PM","4PM","5PM","6PM","7PM","8PM","9PM","10PM","11PM",
        };
        public ObservableCollection<int> Days { get; set; } = new ObservableCollection<int>()
        {
            1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,
            1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,
            1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,
            1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,
            1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,
            1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,
            1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,
        };

        private ObservableCollection<Event> _Events = new ObservableCollection<Event>();
        public ObservableCollection<Event> Events
        {
            get => _Events;
            set => SetProperty(ref _Events, value);
        }

        private ObservableCollection<CustomDateTime> _CurrentWeek = new ObservableCollection<CustomDateTime>();
        public ObservableCollection<CustomDateTime> CurrentWeek
        {
            get => _CurrentWeek;
            set => SetProperty(ref _CurrentWeek, value);
        }

        public ICommand EventItemClickCM { get; set; }

        public CalendarVM()
        {
            Events.Add(new Event()
            {
                Title = "Checking todo list",
                StartTime = new DateTime(2024, 11, 20, 7, 00, 0),
                EndTime = new DateTime(2024, 11, 20, 7, 30, 0),
                EventType = "Personal"
            });
            Events.Add(new Event()
            {
                Title = "Weekly grooming",
                StartTime = new DateTime(2024, 11, 21, 10, 0, 0),
                EndTime = new DateTime(2024, 11, 21, 11, 0, 0)
            });
            Events.Add(new Event()
            {
                Title = "Daily meeting",
                StartTime = new DateTime(2024, 11, 22, 9, 0, 0),
                EndTime = new DateTime(2024, 11, 22, 9, 30, 0)
            });

            EventItemClickCM = new RelayCommand<Event>((p) => true, (p) =>
            {
                OpenEventDetail(p);
            });

            InitializeWeek();
        }

        public void OpenEventDetail(Event e)
        {
            var eventDetail = new EventDetail(e);
            eventDetail.Left = e.Left + 140;

            var screenHeight = SystemParameters.PrimaryScreenHeight;
            if (MainWindow.LastMouseClickPostition.Y + eventDetail.Height > screenHeight)
            {
                eventDetail.Top = MainWindow.LastMouseClickPostition.Y - 380;
            }
            else
            {
                eventDetail.Top = MainWindow.LastMouseClickPostition.Y;
            }
            eventDetail.ShowDialog();

            if (eventDetail.IsSave)
            {
                e.Title = eventDetail.EventSaved.Title;
                e.Location = eventDetail.EventSaved.Location;
                e.MeetingURL = eventDetail.EventSaved.MeetingURL;
                e.StartTime = eventDetail.EventSaved.StartTime;
                e.EndTime = eventDetail.EventSaved.EndTime;
            }
            else 
            if (eventDetail.IsDelete)
            {
                Events.Remove(e);
            }
        }

        public void InitializeWeek()
        {
            var firstDay = DateTime.Now;
            while (firstDay.DayOfWeek != DayOfWeek.Sunday)
            {
                firstDay = firstDay.AddDays(-1);
            }

            for (int i = 0; i < 7; i++)
            {
                CurrentWeek.Add(new CustomDateTime
                {
                    Date = firstDay.AddDays(i)
                });
            }
        }

        public void AddEvent(int dayIndex, int hour, int min)
        {
            var date = CurrentWeek[dayIndex].Date;

            Events.Add(new Event
            {
                StartTime = new DateTime(date.Year, date.Month, date.Day, hour, min, 0),
                EndTime = new DateTime(date.Year, date.Month, date.Day, hour + 1, min, 0),
            });

            OpenEventDetail(Events.LastOrDefault());
        }
        
        public DateTime PrevWeek()
        {
            var dt = CurrentWeek.FirstOrDefault().Date;
            CurrentWeek.Clear();

            for (int i = 1; i <= 7; i++)
            {
                CurrentWeek.Insert(0, new CustomDateTime
                {
                    Date = dt.AddDays(i * -1)
                });
            }

            return CurrentWeek.FirstOrDefault().Date;
        }

        public DateTime NextWeek()
        {
            var dt = CurrentWeek.LastOrDefault().Date;
            CurrentWeek.Clear();

            for (int i = 1; i <= 7; i++)
            {
                CurrentWeek.Add(new CustomDateTime
                {
                    Date = dt.AddDays(i)
                });
            }

            return CurrentWeek.FirstOrDefault().Date;
        }
    }
}
