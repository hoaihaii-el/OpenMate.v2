using OpenMate.Work.Helpers;
using System;
using System.Windows.Controls;

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

        private void InputRichTextBox_Pasting(object sender, System.Windows.DataObjectPastingEventArgs e)
        {
            Dispatcher.BeginInvoke(new Action(() =>
            {
                Helper.ResizeImage(InputRichTextBox, 100);
            }));
        }
    }
}
