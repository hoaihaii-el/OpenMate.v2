using OpenMate.API.Domain.DTOs;
using OpenMate.API.Domain.Entities.Board;

namespace OpenMate.API.Domain.Interfaces
{
    public interface IBoardService
    {
        Task<IEnumerable<ProjectDto>> GetProjects(string userId);
        Task<Project> GetProject(string id);
        Task CreateProject(ProjectDto projectDto);
        Task DeleteProject(string id);
        Task UpdateProject(ProjectDto projectDto);
        Task<IEnumerable<Sprint>> GetSprints(string projectId);
        Task CreateSprint(SprintDto dto);
        Task UpdateSprint(SprintDto dto);
        Task<IEnumerable<TaskDto>> GetTaskOMs(int sprintId);
        Task CreateTaskOM(TaskDto taskDto);
        Task UpdateTask(TaskDto taskDto);
        Task AddTaskDescription(List<TaskDesDto> taskDesDto);
        Task<IEnumerable<TaskDesDto>> GetDescriptions(string taskId);
        Task<SprintStatisticsDto> GetSprintStatistics(int sprintId);
    }
}
