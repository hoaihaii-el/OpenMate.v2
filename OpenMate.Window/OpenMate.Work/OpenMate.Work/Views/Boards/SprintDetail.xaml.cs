using OpenMate.Work.Model;
using OpenMate.Work.ViewModel.Boards;
using System.Windows;
using System.Windows.Input;

namespace OpenMate.Work.Views.Boards
{
    /// <summary>
    /// Interaction logic for SprintDetail.xaml
    /// </summary>
    public partial class SprintDetail : Window
    {
        public SprintDetail()
        {
            InitializeComponent();
        }

        private void PowerOff_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
