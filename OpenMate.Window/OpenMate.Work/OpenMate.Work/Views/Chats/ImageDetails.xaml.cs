using System.Windows;
using System.Windows.Input;

namespace OpenMate.Work.Views.Chats
{
    /// <summary>
    /// Interaction logic for ImageDetails.xaml
    /// </summary>
    public partial class ImageDetails : Window
    {
        public ImageDetails()
        {
            InitializeComponent();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void ImagesScrollViewer_Loaded(object sender, RoutedEventArgs e)
        {
            ImagesScrollViewer.ScrollToEnd();
        }
    }
}
