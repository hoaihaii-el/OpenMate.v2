using OpenMate.Work.Views;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OpenMate.Work.Behaviors
{
    public static class ImageBehavior
    {
        public static readonly DependencyProperty EnableImagePreviewProperty =
            DependencyProperty.RegisterAttached(
                "EnableImagePreview",
                typeof(bool),
                typeof(ImageBehavior),
                new PropertyMetadata(false, OnEnableImagePreviewChanged));

        public static bool GetEnableImagePreview(DependencyObject obj) => (bool)obj.GetValue(EnableImagePreviewProperty);

        public static void SetEnableImagePreview(DependencyObject obj, bool value) => obj.SetValue(EnableImagePreviewProperty, value);

        private static void OnEnableImagePreviewChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is Image image)
            {
                if ((bool)e.NewValue)
                {
                    image.MouseLeftButtonDown += Image_MouseLeftButtonDown;
                }
                else
                {
                    image.MouseLeftButtonDown -= Image_MouseLeftButtonDown;
                }
            }
        }

        private static void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (sender is Image image && image.Source != null)
            {
                var previewWindow = new ImageViewer(image);
                previewWindow.ShowDialog();
            }
        }
    }
}
