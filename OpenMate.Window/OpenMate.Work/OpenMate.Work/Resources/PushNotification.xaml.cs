using System;
using System.Windows;
using System.Windows.Threading;

namespace OpenMate.Work.Resources
{
    /// <summary>
    /// Interaction logic for PushNotification.xaml
    /// </summary>
    public partial class PushNotification : Window
    {
        public PushNotification()
        {
            InitializeComponent();
        }

        public PushNotification(string noti)
        {
            InitializeComponent();
            _Timer = new DispatcherTimer();
            _Timer.Interval = TimeSpan.FromSeconds(5);
            _Timer.Tick += _Timer_Tick;
            _Timer.Start();
            Notification.Text = noti;
            Top = SystemParameters.PrimaryScreenHeight - Height - 80;
            Left = SystemParameters.PrimaryScreenWidth - Width - 50;
        }

        private DispatcherTimer _Timer;

        private void _Timer_Tick(object sender, EventArgs e)
        {
            _Timer.Stop();
            this.Close();
        }

        private void Label_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _Timer.Stop();
        }

        private void Window_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _Timer.Start();
        }
    }
}
