using OpenMate.Work.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OpenMate.Work.Views.Calendars
{
    /// <summary>
    /// Interaction logic for EventDetail.xaml
    /// </summary>
    public partial class EventDetail : Window
    {
        public bool IsSave = false;
        public bool IsDelete = false;
        public Event EventSaved { get; set; }

        public EventDetail()
        {
            InitializeComponent();
        }

        public EventDetail(Event evt)
        {
            InitializeComponent();
            Title.Text = evt.Title;
            Location.Text = evt.Location;
            MeetingURL.Text = evt.MeetingURL;
            Start.SelectedTime = evt.StartTime;
            End.SelectedTime = evt.EndTime;
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            IsSave = true;
            EventSaved = new Event
            {
                Title = Title.Text,
                Location = Location.Text,
                MeetingURL = MeetingURL.Text,
                StartTime = Start.SelectedTime.Value,
                EndTime = End.SelectedTime.Value,
            };
            this.Close();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            IsDelete = true;
            this.Close();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            if (combo.SelectedItem == null)
            {
                return;
            }

            var vm = this.DataContext as Event;
            vm.Attendees.Add(new Attendee
            {
                ID = "1",
                Name = combo.SelectedItem.ToString()
            });

            vm.NewAttendee = "";
        }

        private void NewAttendee_TextChanged(object sender, TextChangedEventArgs e)
        {
            var txtBox = sender as TextBox;

            if (txtBox == null)
            {
                return;
            }

            if (txtBox.Text.Length > 0)
            {
                SuggestionCombo.IsDropDownOpen = true;
            }
            else
            {
                SuggestionCombo.IsDropDownOpen = false;
            }
        }
    }
}
