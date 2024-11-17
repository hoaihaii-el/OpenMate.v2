using System.Windows;
using System.Windows.Input;

namespace OpenMate.Work.Views.Boards
{
    /// <summary>
    /// Interaction logic for AddBackLog.xaml
    /// </summary>
    public partial class AddBackLog : Window
    {
        public AddBackLog()
        {
            InitializeComponent();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
