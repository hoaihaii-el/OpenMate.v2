using System.Windows;
using System.Windows.Controls;

namespace OpenMate.Work.Views
{
    /// <summary>
    /// Interaction logic for BoardContent.xaml
    /// </summary>
    public partial class BoardContent : UserControl
    {
        public BoardContent()
        {
            InitializeComponent();
        }

        private void NavigateButton_Checked(object sender, RoutedEventArgs e)
        {
            var radButton = sender as RadioButton;
            var buttonContent = radButton.Name.ToString();

            if (Board == null || SprintList == null)
            {
                return;
            }

            switch (buttonContent)
            {
                case "ActiveSprint":
                    Board.Visibility = Visibility.Visible;
                    SprintList.Visibility = Visibility.Hidden;
                    ProjectDetail.Visibility = Visibility.Hidden;
                    BackLogs.Visibility = Visibility.Hidden;
                    break;
                case "Sprints":
                    Board.Visibility = Visibility.Hidden;
                    SprintList.Visibility = Visibility.Visible;
                    ProjectDetail.Visibility = Visibility.Hidden;
                    BackLogs.Visibility = Visibility.Hidden;
                    break;
                case "Information":
                    Board.Visibility = Visibility.Hidden;
                    SprintList.Visibility = Visibility.Hidden;
                    ProjectDetail.Visibility = Visibility.Visible;
                    BackLogs.Visibility = Visibility.Hidden;
                    break;
                case "BackLog":
                    Board.Visibility = Visibility.Hidden;
                    SprintList.Visibility = Visibility.Hidden;
                    ProjectDetail.Visibility = Visibility.Hidden;
                    BackLogs.Visibility = Visibility.Visible;
                    break;
            }
        }
    }
}
