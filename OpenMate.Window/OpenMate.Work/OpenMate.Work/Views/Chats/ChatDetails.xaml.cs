using System.Windows;
using System.Windows.Input;

namespace OpenMate.Work.Views.Chats
{
    /// <summary>
    /// Interaction logic for ChatDetails.xaml
    /// </summary>
    public partial class ChatDetails : Window
    {
        public ChatDetails()
        {
            InitializeComponent();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ImagesScrollViewer.ScrollToEnd();
            PinnedMessagesScrollViewer.ScrollToEnd();
        }
    }
}
