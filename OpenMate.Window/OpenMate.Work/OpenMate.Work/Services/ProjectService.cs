using Newtonsoft.Json;
using OpenMate.Work.Model;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace OpenMate.Work.Services
{
    public class ProjectService
    {
        private HttpClient httpClient;

        public ProjectService()
        {
            httpClient = new HttpClient();
        }

        public async Task<List<Project>> GetProjects(string userId)
        {
            try
            {
                var response = await httpClient.GetAsync($"https://localhost:5000/board/projects/{userId}");
                if (!response.IsSuccessStatusCode)
                {
                    throw new System.Exception("Cannot get projects");
                }

                var content = await response.Content.ReadAsStringAsync();
                var projects = JsonConvert.DeserializeObject<List<Project>>(content);

                return projects;
            }
            catch
            {
                return new List<Project>();
            }
        }

        public async Task AddProject(Project project)
        {
            var content = new StringContent(JsonConvert.SerializeObject(project), Encoding.UTF8, "application/json");
            await httpClient.PostAsync("https://localhost:5000/board/project", content);
        }

        public async Task UpdateProject(Project project)
        {
            var content = new StringContent(JsonConvert.SerializeObject(project), Encoding.UTF8, "application/json");
            await httpClient.PutAsync("https://localhost:5000/board/project", content);
        }

        public async Task<List<TaskOM>> GetTasks(int sprintId)
        {
            try
            {
                var response = await httpClient.GetAsync($"https://localhost:5000/board/tasks/{sprintId}");
                if (!response.IsSuccessStatusCode)
                {
                    throw new System.Exception("Cannot get tasks");
                }

                var content = await response.Content.ReadAsStringAsync();
                var tasks = JsonConvert.DeserializeObject<List<TaskOM>>(content);

                return tasks;
            }
            catch
            {
                return new List<TaskOM>();
            }
        }

        public async void AddTask(TaskOM task)
        {
            var content = new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json");
            await httpClient.PostAsync("https://localhost:5000/board/task", content);
        }

        public async void UpdateTask(TaskOM task)
        {
            var content = new StringContent(JsonConvert.SerializeObject(task), Encoding.UTF8, "application/json");
            await httpClient.PutAsync("https://localhost:5000/board/task", content);
        }

        public async Task<List<Sprint>> GetSprints(string projectId)
        {
            var response = await httpClient.GetAsync($"https://localhost:5000/board/sprints/{projectId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new System.Exception("Cannot get sprints");
            }

            var content = await response.Content.ReadAsStringAsync();
            var sprints = JsonConvert.DeserializeObject<List<Sprint>>(content);
            return sprints;
        }

        public async void AddSprint(Sprint sprint)
        {
            var content = new StringContent(JsonConvert.SerializeObject(sprint), Encoding.UTF8, "application/json");
            await httpClient.PostAsync("https://localhost:5000/board/sprint", content);
        }

        public async Task<SprintStat> GetSprintStats(int sprintId)
        {
            var response = await httpClient.GetAsync($"https://localhost:5000/board/sprintstat/{sprintId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new System.Exception("Cannot get sprint stat");
            }

            var content = await response.Content.ReadAsStringAsync();
            var sprintStat = JsonConvert.DeserializeObject<SprintStat>(content);
            return sprintStat;
        }
    }
}
