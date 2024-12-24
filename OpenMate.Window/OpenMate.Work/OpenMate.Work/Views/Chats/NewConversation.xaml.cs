using System.Windows;
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
    }
}
