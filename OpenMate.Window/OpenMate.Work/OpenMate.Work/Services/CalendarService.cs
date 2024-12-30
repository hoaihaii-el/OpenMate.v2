using Newtonsoft.Json;
using OpenMate.Work.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace OpenMate.Work.Services
{
    public class CalendarService
    {
        private HttpClient _httpClient;

        public CalendarService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Event>> GetEventsData()
        {
            var response = await _httpClient.GetAsync("https://localhost:5000/calendar");
            var content = await response.Content.ReadAsStringAsync();
            var events = JsonConvert.DeserializeObject<List<Event>>(content);
            return events;
        }
    }
}
