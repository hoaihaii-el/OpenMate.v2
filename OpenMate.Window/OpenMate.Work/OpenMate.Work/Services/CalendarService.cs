using Newtonsoft.Json;
using OpenMate.Work.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Task = System.Threading.Tasks.Task;

namespace OpenMate.Work.Services
{
    public class CalendarService
    {
        private HttpClient _httpClient;

        public CalendarService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Event>> GetEventsData(DateTime start, DateTime end)
        {
            try
            {
                var response = await _httpClient.GetAsync($"https://localhost:5000/calendar?start={start}&end={end}");
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var events = JsonConvert.DeserializeObject<List<Event>>(content);
                    return events;
                }

                return new List<Event>()
                {
                    new Event()
                    {
                        Title = "Checking todo list",
                        StartTime = new DateTime(2024, 11, 20, 7, 00, 0),
                        EndTime = new DateTime(2024, 11, 20, 7, 30, 0),
                        Attendees = new ObservableCollection<Attendee>
                        {
                            new Attendee()
                            {
                                ID = "1",
                                Name = "Alex"
                            },
                            new Attendee()
                            {
                                ID = "2",
                                Name = "Hoai Hai"
                            }
                        }
                    },
                    new Event()
                    {
                        Title = "Weekly grooming",
                        StartTime = new DateTime(2024, 11, 21, 10, 0, 0),
                        EndTime = new DateTime(2024, 11, 21, 11, 0, 0)
                    },
                    new Event()
                    {
                        Title = "Daily meeting",
                        StartTime = new DateTime(2024, 11, 22, 9, 0, 0),
                        EndTime = new DateTime(2024, 11, 22, 9, 30, 0)
                    }
                };
            }
            catch
            {
                return new List<Event>()
                {
                    new Event()
                    {
                        Title = "Checking todo list",
                        StartTime = new DateTime(2024, 11, 20, 7, 00, 0),
                        EndTime = new DateTime(2024, 11, 20, 7, 30, 0),
                        Attendees = new ObservableCollection<Attendee>
                        {
                            new Attendee()
                            {
                                ID = "1",
                                Name = "Alex"
                            },
                            new Attendee()
                            {
                                ID = "2",
                                Name = "Hoai Hai"
                            }
                        }
                    },
                    new Event()
                    {
                        Title = "Weekly grooming",
                        StartTime = new DateTime(2024, 11, 21, 10, 0, 0),
                        EndTime = new DateTime(2024, 11, 21, 11, 0, 0)
                    },
                    new Event()
                    {
                        Title = "Daily meeting",
                        StartTime = new DateTime(2024, 11, 22, 9, 0, 0),
                        EndTime = new DateTime(2024, 11, 22, 9, 30, 0)
                    }
                };
            }
        }

        public async Task AddEvent(Event newEvent)
        {
            var content = new StringContent(JsonConvert.SerializeObject(newEvent), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://localhost:5000/calendar", content);
        }

        public async Task DeleteEvent(string evtId)
        {
            await _httpClient.DeleteAsync($"https://localhost:5000/calendar/{evtId}");
        }

        public async Task UpdateEvent(Event evt)
        {
            var content = new StringContent(JsonConvert.SerializeObject(evt), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"https://localhost:5000/calendar/{evt.ID}", content);
        }
    }
}
