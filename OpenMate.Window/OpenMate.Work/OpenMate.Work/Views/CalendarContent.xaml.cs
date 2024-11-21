using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OpenMate.Work.Views
{
    /// <summary>
    /// Interaction logic for CalendarContent.xaml
    /// </summary>
    public partial class CalendarContent : UserControl
    {
        public CalendarContent()
        {
            InitializeComponent();
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var clickedPosition = e.GetPosition((IInputElement)sender);

            double rowHeight = 60;
            double columnWidth = ((Grid)sender).ActualWidth / 7;

            int dayIndex = (int)(clickedPosition.X / columnWidth); 
            int hourIndex = (int)(clickedPosition.Y / rowHeight);
            double minute = (clickedPosition.Y % rowHeight) / rowHeight * 60;
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var clickedPosition = e.GetPosition((IInputElement)sender);

            double rowHeight = 60;
            double columnWidth = ((Label)sender).ActualWidth / 7;

            int dayIndex = (int)(clickedPosition.X / columnWidth);
            int hourIndex = (int)(clickedPosition.Y / rowHeight);
            double minute = (clickedPosition.Y % rowHeight) / rowHeight * 60;
        }
    }
}
