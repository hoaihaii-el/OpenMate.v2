using OpenMate.Work.Model;
using OpenMate.Work.ViewModel;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OpenMate.Work.Views.Boards
{
    /// <summary>
    /// Interaction logic for KanbanBoard.xaml
    /// </summary>
    public partial class KanbanBoard : UserControl
    {
        public KanbanBoard()
        {
            InitializeComponent();
        }

        private Point _StartPoint;
        private bool _IsDragging = false;
        private Task _SourceTask;

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
                    _SourceTask = list.SelectedItem as Task;
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
            HandleDropTask(sender);
        }

        private void ListBoxItem_Drop(object sender, DragEventArgs e)
        {
            HandleDropTask(sender);
        }

        private void HandleDropTask(object sender)
        {
            if (!_IsDragging)
            {
                return;
            }

            _IsDragging = false;
            var vm = this.DataContext as BoardVM;

            if (vm == null)
            {
                return;
            }

            var destination = GetTaskStatus(sender);
            if (_SourceTask == null || destination == null)
            {
                return;
            }

            AssignNewStatus(_SourceTask, destination, GetListBoxItemIndex(sender));
        }

        private void AssignNewStatus(Task task, string newStatus, int index)
        {
            var vm = this.DataContext as BoardVM;

            if (vm == null)
            {
                return;
            }

            switch (task.Status)
            {
                case "Log":
                    vm.Log.Remove(task);
                    break;
                case "Doing":
                    vm.Doing.Remove(task);
                    break;
                case "Review":
                    vm.Review.Remove(task);
                    break;
                case "Finish":
                    vm.Finish.Remove(task);
                    break;
            }

            task.Status = newStatus;
            switch (newStatus)
            {
                case "Log":
                    vm.Log.Insert(index == -1 ? vm.Log.Count : index, task);
                    break;
                case "Doing":
                    vm.Doing.Insert(index == -1 ? vm.Doing.Count : index, task);
                    break;
                case "Review":
                    vm.Review.Insert(index == -1 ? vm.Review.Count : index, task);
                    break;
                case "Finish":
                    vm.Finish.Insert(index == -1 ? vm.Finish.Count : index, task);
                    break;
            }
        }

        private string GetTaskStatus(object obj)
        {
            var item = obj as ListBoxItem;
            if (item == null)
            {
                var list = obj as ListBox;
                return list.Name.Substring(0, list.Name.IndexOf("Column"));
            }

            var task = item.DataContext as Task;
            if (task == null)
            {
                return null;
            }

            return task.Status;
        }

        private int GetListBoxItemIndex(object sender)
        {
            var listBoxItem = sender as ListBoxItem;

            if (listBoxItem != null)
            {
                var parentListBox = ItemsControl.ItemsControlFromItemContainer(listBoxItem) as ListBox;

                if (parentListBox != null)
                {
                    return parentListBox.ItemContainerGenerator.IndexFromContainer(listBoxItem);
                }
            }
            return -1;
        }
    }
}
