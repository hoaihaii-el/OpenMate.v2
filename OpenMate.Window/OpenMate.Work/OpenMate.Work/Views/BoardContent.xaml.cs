using OpenMate.Work.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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

        private Point _StartPoint;
        private bool _IsDragging = false;

        private void ListBox_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            _StartPoint = e.GetPosition(null);
            _IsDragging = false;
        }

        private void ListBox_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            var list = sender as ListBox;

            if (list.SelectedItem == null)
            {
                return;
            }

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                var curPoint = e.GetPosition(null);
                var vector = _StartPoint - curPoint;

                if (Math.Abs(vector.X) > SystemParameters.MinimumHorizontalDragDistance
                 || Math.Abs(vector.Y) > SystemParameters.MinimumVerticalDragDistance)
                {
                    _IsDragging = true;
                    DragDrop.DoDragDrop(list, list.SelectedItem, DragDropEffects.Move);
                }
            }
        }

        private void ListBox_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!_IsDragging)
            {
                // open task detail
            }
        }

        private void ListBox_Drop(object sender, DragEventArgs e)
        {
            _IsDragging = false;
        }

        private void ListBoxItem_Drop(object sender, DragEventArgs e)
        {
            _IsDragging = false;
            var vm = this.DataContext as BoardVM;
        }

        private string GetTaskStatus(ListBoxItem item)
        {
            if (item)
        }
    }
}
