using OpenMate.API.Domain.DTOs;
using OpenMate.API.Domain.Entities.Board;

namespace OpenMate.API.Domain.Interfaces
{
    public interface IBoardService
    {
        Task<IEnumerable<Project>> GetProjects(string userId);
        Task<Project> GetProject(string id);
        Task CreateProject(ProjectDto projectDto);
        Task DeleteProject(string id);
        Task UpdateProject(string id, ProjectDto projectDto);
        Task<IEnumerable<Sprint>> GetSprints(string projectId);
        Task CreateSprint(string projectID, int order);
        Task<IEnumerable<TaskOM>> GetTaskOMs(int sprintId);
        Task CreateTaskOM(TaskDto taskDto);
        Task AddTaskDescription(TaskDesDto taskDesDto);
    }
}
