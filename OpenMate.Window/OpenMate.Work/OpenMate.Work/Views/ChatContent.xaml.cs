using OpenMate.Work.Helpers;
using OpenMate.Work.ViewModel.Chats;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace OpenMate.Work.Views
{
    /// <summary>
    /// Interaction logic for ChatContent.xaml
    /// </summary>
    public partial class ChatContent : UserControl
    {
        public ChatContent()
        {
            InitializeComponent();
        }

        private void InputRichTextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                Helper.ResizeImage(InputRichTextBox, 200);
            }));
        }

        private async void InputRichTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key != Key.Enter)
            {
                return;
            }

            var vm = this.DataContext as ChatVM;
            vm.SendMessage(await Helper.GetMessageFromRichTextBox(InputRichTextBox));
            InputRichTextBox.Document.Blocks.Clear();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            var vm = this.DataContext as ChatVM;
            vm.SendMessage(await Helper.GetMessageFromRichTextBox(InputRichTextBox));
            InputRichTextBox.Document.Blocks.Clear();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //ListBoxChat.ScrollIntoView(ListBoxChat.Items[ListBoxChat.Items.Count - 1]);
        }

        private void ListBoxChat_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (ListBoxChat.Items.Count > 0)
            {
                ListBoxChat.ScrollIntoView(ListBoxChat.Items[ListBoxChat.Items.Count - 1]);
            }
        }
    }
}
