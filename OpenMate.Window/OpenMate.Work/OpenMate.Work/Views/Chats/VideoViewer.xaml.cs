using System;
using System.Windows;
using System.Windows.Input;

namespace OpenMate.Work.Views.Chats
{
    /// <summary>
    /// Interaction logic for VideoViewer.xaml
    /// </summary>
    public partial class VideoViewer : Window
    {
        public VideoViewer()
        {
            InitializeComponent();
        }

        public VideoViewer(string url)
        {
            InitializeComponent();
            mediaElement.Source = new Uri(url);
            mediaElement.Play();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            mediaElement.Pause();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            mediaElement.Position = TimeSpan.Zero;
        }
    }
}
