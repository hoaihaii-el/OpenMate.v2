using Newtonsoft.Json;
using OpenMate.Work.Model;
using OpenMate.Work.Requests;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenMate.Work.Services
{
    public class ChatService
    {
        private HttpClient _httpClient;

        public ChatService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Room>> GetRooms(string userId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://localhost:5000/chat/rooms/{userId}");
                var content = await response.Content.ReadAsStringAsync();
                var rooms = JsonConvert.DeserializeObject<List<Room>>(content);

                return rooms;
            }
            catch
            {
                return new List<Room>()
                {
                    new Room()
                    {
                        Id = 1,
                        Title = "BOARD"
                    },
                    new Room()
                    {
                        Id = 1,
                        Title = "CALENDAR"
                    },
                    new Room()
                    {
                        Id = 1,
                        Title = "Hoài Nhân"
                    },
                };
            }
        }

        public async Task<List<Message>> GetMessages(int roomId)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://localhost:5000/chat/messages/{roomId}");
                var content = await response.Content.ReadAsStringAsync();
                var messages = JsonConvert.DeserializeObject<List<Message>>(content);
                return messages;
            }
            catch
            {
                return new List<Message>
                {
                    new Message()
                    {
                        Text = "Task YUN-019 sao rồi chú??",
                        Sender = "Sếp"
                    },
                    new Message()
                    {
                        Text = "Dạ em bắt đầu start từ chiều hôm qua rồi ạ",
                        Sender = "Culi",
                        SenderId = "24001"
                    },
                    new Message()
                    {
                        Sender = "Sếp",
                        MediaUrl = "https://kenh14cdn.com/2017/images685542-a-1489655177057.jpg"
                    },
                    new Message()
                    {
                        Text = "Dạ đang ổn anh ơi, có gì em báo ngay ạ",
                        Sender = "Culi",
                        SenderId = "24001"
                    },
                };
            }
        }

        public async void SendMessage(Message message)
        {
            var content = new StringContent(JsonConvert.SerializeObject(message), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:5000/chat/message", content);
        }

        public async void AddRoom(RoomReq room)
        {
            var content = new StringContent(JsonConvert.SerializeObject(room), Encoding.UTF8, "application/json");
            await _httpClient.PostAsync("https://localhost:5000/chat/room", content);
        }
    }
}
