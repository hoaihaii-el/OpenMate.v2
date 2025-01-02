using OpenMate.Work.Model;
using OpenMate.Work.ViewModel.Chats;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OpenMate.Work.Views.Chats
{
    /// <summary>
    /// Interaction logic for NewConversation.xaml
    /// </summary>
    public partial class NewConversation : Window
    {
        public NewConversation()
        {
            InitializeComponent();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox.SelectedItem == null)
            {
                return;
            }

            var vm = this.DataContext as ChatVM;
            vm.Participants.Add(listBox.SelectedItem as Attendee);
            vm.NewParticipant = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as ChatVM;
            vm.AddNewChat();
            this.Close();
        }
    }
}
