using System.Collections.Generic;
using System;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows.Documents;
using OpenMate.Work.Model;
using System.Net.Http;
using OpenMate.Work.Requests;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace OpenMate.Work.Helpers
{
    public class Helper
    {
        private static HttpClient _HttpClient = new HttpClient();

        public static double CeelWidth = 164.857;

        public static string CurrentUserId = "24001";

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

        public static async Task<Message> GetMessageFromRichTextBox(RichTextBox richTextBox)
        {
            string text = "";
            string imageUrl = "";
            foreach (var block in richTextBox.Document.Blocks)
            {
                if (block is Paragraph para)
                {
                    foreach (var inline in para.Inlines)
                    {
                        if (inline is Run run)
                        {
                            text += run.Text + "\n";
                        }
                    }
                }
                else if (block is BlockUIContainer blockUI)
                {
                    var image = blockUI.Child as Image;

                    if (image == null)
                    {
                        continue;
                    }

                    var bitmapSrc = image.Source as BitmapSource;

                    if (bitmapSrc != null)
                    {
                        var base64 = Helper.ConvertImageToBase64(bitmapSrc);
                        imageUrl = await GetFileUrl(new FileReq() 
                        {
                            Base64 = base64,
                            FileName = Guid.NewGuid().ToString()
                        });
                    }
                }
            }

            return new Message()
            {
                Text = text.Trim(),
                MediaUrl = imageUrl,
                MediaType = imageUrl.Length > 0 ? "Image" : "",
                SenderId = CurrentUserId,
            };
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

        public static async Task<string> GetFileUrl(FileReq file)
        {
            try
            {
                var content = new StringContent(JsonConvert.SerializeObject(file), Encoding.UTF8, "application/json");
                var response = await _HttpClient.PostAsync("https://localhost:5000/chat/file", content);
                var imageUrl = await response.Content.ReadAsStringAsync();
                return imageUrl;
            }
            catch
            {
                return "";
            }
        }

        public static List<Attendee> Attendees = new List<Attendee>()
        {
            new Attendee()
            {
                ID = "24001",
                Name = "Hoài Hải"
            },
            new Attendee()
            {
                ID = "24002",
                Name = "Hoài Nhân"
            },
            new Attendee()
            {
                ID = "24003",
                Name = "Hải Đăng"
            },
            new Attendee()
            {
                ID = "24004",
                Name = "Minh Ngọc"
            },
            new Attendee()
            {
                ID = "24005",
                Name = "Khải Hoàn"
            },
            new Attendee()
            {
                ID = "24006",
                Name = "Hoài An"
            },
            new Attendee()
            {
                ID = "24007",
                Name = "Tú Quỳnh"
            },
            new Attendee()
            {
                ID = "24008",
                Name = "Thanh Bảo"
            },
            new Attendee()
            {
                ID = "24009",
                Name = "Hồng Nhung"
            },
            new Attendee()
            {
                ID = "24010",
                Name = "Xuân Son"
            },
            new Attendee()
            {
                ID = "24011",
                Name = "Khởi Nghĩa"
            },
        };
    }
}
