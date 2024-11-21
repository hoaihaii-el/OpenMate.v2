using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;

namespace OpenMate.Work.Views.Boards
{
    /// <summary>
    /// Interaction logic for AddBackLog.xaml
    /// </summary>
    public partial class AddBackLog : Window
    {
        public AddBackLog()
        {
            InitializeComponent();
        }

        private void Label_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void Bold_Click(object sender, RoutedEventArgs e)
        {
            var selection = richTextBox.Selection;
            try
            {
                if ((FontWeight)selection.GetPropertyValue(TextElement.FontWeightProperty) == FontWeights.Bold)
                {
                    selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Normal);
                }
                else
                {
                    selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
                }
            }
            catch
            {
                selection.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            }
        }

        private void Italic_Click(object sender, RoutedEventArgs e)
        {
            var selection = richTextBox.Selection;
            try
            {
                if ((FontStyle)selection.GetPropertyValue(TextElement.FontStyleProperty) == FontStyles.Italic)
                {
                    selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Normal);
                }
                else
                {
                    selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
                }
            }
            catch
            {
                selection.ApplyPropertyValue(TextElement.FontStyleProperty, FontStyles.Italic);
            }
        }

        private void Underline_Click(object sender, RoutedEventArgs e)
        {
            var selection = richTextBox.Selection;
            try
            {
                if (selection.GetPropertyValue(Inline.TextDecorationsProperty) == TextDecorations.Underline)
                {
                    selection.ApplyPropertyValue(Inline.TextDecorationsProperty, null);
                }
                else
                {
                    selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
                }
            }
            catch
            {
                selection.ApplyPropertyValue(Inline.TextDecorationsProperty, TextDecorations.Underline);
            }
        }
    }
}
