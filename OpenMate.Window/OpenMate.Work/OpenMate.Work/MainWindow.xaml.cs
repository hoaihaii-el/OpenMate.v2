using OpenMate.Work.ViewModel;
using OpenMate.Work.ViewModel.Chats;
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
            this.PreviewMouseLeftButtonDown += MainWindow_PreviewMouseLeftButtonDown;
            ChatContent.DataContext = new ChatVM();
            BoardContent.DataContext = new BoardVM();
            CalendarContent.DataContext = new CalendarVM();
        }

        public static Point LastMouseClickPostition { get; private set; }

        private void MainWindow_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            LastMouseClickPostition = PointToScreen(e.GetPosition(this));
        }

        private Color _MainTabColor = (Color)ColorConverter.ConvertFromString("#e1e1e1");
        private Color _TempTabColor = (Color)ColorConverter.ConvertFromString("#fff");

        private void ChatTab_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChatTab.Background = new SolidColorBrush(_MainTabColor);
            BoardTab.Background = new SolidColorBrush(_TempTabColor);
            CalendarTab.Background = new SolidColorBrush(_TempTabColor);
            ChatContent.Visibility = Visibility.Visible;
            BoardContent.Visibility = Visibility.Hidden;
            CalendarContent.Visibility = Visibility.Hidden;
        }
        private void BoardTab_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChatTab.Background = new SolidColorBrush(_TempTabColor);
            BoardTab.Background = new SolidColorBrush(_MainTabColor);
            CalendarTab.Background = new SolidColorBrush(_TempTabColor);
            ChatContent.Visibility = Visibility.Hidden;
            BoardContent.Visibility = Visibility.Visible;
            CalendarContent.Visibility = Visibility.Hidden;
        }

        private void PowerOff_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void CalendarTab_MouseDown(object sender, MouseButtonEventArgs e)
        {
            ChatTab.Background = new SolidColorBrush(_TempTabColor);
            BoardTab.Background = new SolidColorBrush(_TempTabColor);
            CalendarTab.Background = new SolidColorBrush(_MainTabColor);
            ChatContent.Visibility = Visibility.Hidden;
            BoardContent.Visibility = Visibility.Hidden;
            CalendarContent.Visibility = Visibility.Visible;
        }
    }
}
