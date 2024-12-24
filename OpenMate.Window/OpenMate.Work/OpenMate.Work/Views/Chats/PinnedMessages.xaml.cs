using System.Windows;
using System.Windows.Input;

namespace OpenMate.Work.Views.Chats
{
    /// <summary>
    /// Interaction logic for PinnedMessages.xaml
    /// </summary>
    public partial class PinnedMessages : Window
    {
        public PinnedMessages()
        {
            InitializeComponent();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void PinnedMessagesScrollViewer_Loaded(object sender, RoutedEventArgs e)
        {
            PinnedMessagesScrollViewer.ScrollToEnd();
        }
    }
}
