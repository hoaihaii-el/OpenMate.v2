using OpenMate.Work.ViewModel;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace OpenMate.Work
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainVM();
        }

        private Color _MainTabColor = (Color)ColorConverter.ConvertFromString("#134B70");
        private Color _TempTabColor = (Color)ColorConverter.ConvertFromString("#508C9B");

        private void ChatTab_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChatTab.Background = new SolidColorBrush(_MainTabColor);
            BoardTab.Background = new SolidColorBrush(_TempTabColor);
            ChatPanel.Visibility = Visibility.Visible;
            BoardPanel.Visibility = Visibility.Hidden;
        }
        private void BoardTab_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChatTab.Background = new SolidColorBrush(_TempTabColor);
            BoardTab.Background = new SolidColorBrush(_MainTabColor);
            ChatPanel.Visibility = Visibility.Hidden;
            BoardPanel.Visibility = Visibility.Visible;
        }
    }
}
