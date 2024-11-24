using OpenMate.Work.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace OpenMate.Work.Views
{
    /// <summary>
    /// Interaction logic for CalendarContent.xaml
    /// </summary>
    public partial class CalendarContent : UserControl
    {
        public CalendarContent()
        {
            InitializeComponent();
            _Timer = new DispatcherTimer();
            _Timer.Interval = TimeSpan.FromSeconds(60);
            _Timer.Tick += _Timer_Tick;
            _Timer.Start();
            Canvas.SetTop(TimeLine, DateTime.Now.Hour * 60 + DateTime.Now.Minute);
        }

        private void _Timer_Tick(object sender, EventArgs e)
        {
            Canvas.SetTop(TimeLine, DateTime.Now.Hour * 60 + DateTime.Now.Minute);
        }

        private DispatcherTimer _Timer;

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var clickedPosition = e.GetPosition((IInputElement)sender);

            double rowHeight = 60;
            double columnWidth = ((Label)sender).ActualWidth / 7;

            int dayIndex = (int)(clickedPosition.X / columnWidth);
            int hourIndex = (int)(clickedPosition.Y / rowHeight);
            double minute = (clickedPosition.Y % rowHeight) / rowHeight * 60;

            if (minute > 15 && minute <= 45)
            {
                minute = 30;
            }
            else
            {
                minute = 0;
            }

            var vm = this.DataContext as CalendarVM;
            vm.AddEvent(dayIndex, hourIndex, (int) minute);
        }

        private void PrevWeek_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var vm = this.DataContext as CalendarVM;
            var dt = vm.PrevWeek();

            if (dt.Month != Calendar.DisplayDate.Month)
            {
                Calendar.DisplayDate = Calendar.DisplayDate.AddMonths(-1);
            }
        }

        private void NextWeek_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var vm = this.DataContext as CalendarVM;
            var dt = vm.NextWeek();

            if (dt.Month != Calendar.DisplayDate.Month)
            {
                Calendar.DisplayDate = Calendar.DisplayDate.AddMonths(1);
            }
        }
    }
}
