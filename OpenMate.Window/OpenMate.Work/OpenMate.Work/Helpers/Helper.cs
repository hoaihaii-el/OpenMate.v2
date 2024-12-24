using System.Collections.Generic;
using System;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Documents;

namespace OpenMate.Work.Helpers
{
    public class Helper
    {
        public static double CeelWidth = 164.857;

        public static Dictionary<DayOfWeek, double> DayOfWeekWidth = new Dictionary<DayOfWeek, double>
        {
            { DayOfWeek.Sunday,  0},
            { DayOfWeek.Monday, CeelWidth },
            { DayOfWeek.Tuesday, 2 * CeelWidth },
            { DayOfWeek.Wednesday, 3 * CeelWidth },
            { DayOfWeek.Thursday, 4 * CeelWidth },
            { DayOfWeek.Friday, 5 * CeelWidth },
            { DayOfWeek.Saturday, 6 * CeelWidth }
        };

        public static string ConvertImageToBase64(BitmapSource bitmapSource)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                BitmapEncoder encoder = new PngBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bitmapSource));
                encoder.Save(stream);

                return Convert.ToBase64String(stream.ToArray());
            }
        }

        public static void ResizeImage(RichTextBox richTxtBox, double maxWidth)
        {
            foreach (var block in richTxtBox.Document.Blocks)
            {
                if (block is BlockUIContainer blockUI && blockUI.Child is Image image)
                {
                    var rate = image.Height / image.Width;
                    image.MaxWidth = maxWidth;
                    image.MaxHeight = rate * image.MaxWidth;
                }
            }
        }
    }
}
