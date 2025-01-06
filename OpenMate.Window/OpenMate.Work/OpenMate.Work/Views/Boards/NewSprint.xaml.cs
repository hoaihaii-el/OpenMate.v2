using OpenMate.Work.ViewModel.Boards;
using System.Windows;
using System.Windows.Input;

namespace OpenMate.Work.Views.Boards
{
    /// <summary>
    /// Interaction logic for NewSprint.xaml
    /// </summary>
    public partial class NewSprint : Window
    {
        public NewSprint()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as BoardVM;
            if (vm != null)
            {
                vm.AddSprint();
            }
            this.Close();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
