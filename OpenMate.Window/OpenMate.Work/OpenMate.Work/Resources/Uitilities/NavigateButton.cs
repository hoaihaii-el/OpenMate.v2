using System.Windows;
using System.Windows.Controls;

namespace OpenMate.Work.Resources.Uitilities
{
    class NavigateButton : RadioButton
    {
        static NavigateButton()
        {
            DefaultStyleKeyProperty
                .OverrideMetadata(
                    typeof(NavigateButton),
                    new FrameworkPropertyMetadata(typeof(NavigateButton))
                );
        }
    }
}
