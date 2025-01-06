using OpenMate.Work.Model;
using OpenMate.Work.ViewModel.Boards;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OpenMate.Work.Views.Boards
{
    /// <summary>
    /// Interaction logic for NewProject.xaml
    /// </summary>
    public partial class NewProject : Window
    {
        public NewProject()
        {
            InitializeComponent();
        }


        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var vm = this.DataContext as BoardVM;
            if (vm == null)
            {
                return;
            }

            var listBox = sender as ListBox;
            if (listBox.SelectedItem == null)
            {
                return;
            }
            var att = listBox.SelectedItem as Attendee;

            vm.NewProject.Members.Add(new ProjectMember
            {
                Id = att.ID,
                Name = att.Name,
                Role = "",
                Effort = 0
            });
            vm.NewMember = "";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as BoardVM;
            if (vm == null)
            {
                return;
            }

            vm.AddProject();
            this.Close();
        }
    }
}
