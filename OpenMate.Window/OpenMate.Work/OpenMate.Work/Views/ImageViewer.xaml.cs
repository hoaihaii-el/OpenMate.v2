using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OpenMate.Work.Views
{
    /// <summary>
    /// Interaction logic for ImageViewer.xaml
    /// </summary>
    public partial class ImageViewer : Window
    {
        public ImageViewer()
        {
            InitializeComponent();
        }

        private bool _IsClickImage = false;
        private const double _MaxWidthMinValue = 1000;
        private const double _MaxWidthMaxValue = 1400;
        public ImageViewer(Image image)
        {
            InitializeComponent();
            try
            {
                Preview.Source = image.Source;
                var rate = image.Width / image.Height;
                Preview.MaxWidth = _MaxWidthMinValue;
                Preview.MaxHeight = rate * Preview.MaxWidth;
            }
            catch
            {
                return;
            }
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (_IsClickImage)
            {
                _IsClickImage = false;
                return;
            }
            this.Close();
        }

        private void Preview_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Preview.MaxWidth = Preview.MaxWidth == _MaxWidthMinValue ? _MaxWidthMaxValue : _MaxWidthMinValue;
            _IsClickImage = true;
        }
    }
}
