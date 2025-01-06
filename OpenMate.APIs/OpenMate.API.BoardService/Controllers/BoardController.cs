using Microsoft.AspNetCore.Mvc;
using OpenMate.API.Domain.DTOs;
using OpenMate.API.Domain.Interfaces;

namespace OpenMate.API.BoardService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController(IBoardService service) : ControllerBase
    {
        [HttpGet("projects/{userId}")]
        public async Task<IActionResult> GetProjects(string userId)
        {
            var projects = await service.GetProjects(userId);
            return Ok(projects);
        }

        [HttpGet("project/{id}")]
        public async Task<IActionResult> GetProject(string id)
        {
            var project = await service.GetProject(id);
            return Ok(project);
        }

        [HttpPost("project")]
        public async Task<IActionResult> CreateProject(ProjectDto projectDto)
        {
            await service.CreateProject(projectDto);
            return Ok();
        }

        [HttpDelete("project/{id}")]
        public async Task<IActionResult> DeleteProject(string id)
        {
            await service.DeleteProject(id);
            return Ok();
        }

        [HttpPut("project")]
        public async Task<IActionResult> UpdateProject(ProjectDto projectDto)
        {
            await service.UpdateProject(projectDto);
            return Ok();
        }

        [HttpGet("sprints/{projectId}")]
        public async Task<IActionResult> GetSprints(string projectId)
        {
            var sprints = await service.GetSprints(projectId);
            return Ok(sprints);
        }

        [HttpPost("sprint")]
        public async Task<IActionResult> CreateSprint(SprintDto dto)
        {
            await service.CreateSprint(dto);
            return Ok();
        }

        [HttpGet("sprint/stats/{sprintId}")]
        public async Task<IActionResult> GetSprintStatistics(int sprintId)
        {
            var stats = await service.GetSprintStatistics(sprintId);
            return Ok(stats);
        }

        [HttpGet("tasks/{sprintId}")]
        public async Task<IActionResult> GetTaskOMs(int sprintId)
        {
            var tasks = await service.GetTaskOMs(sprintId);
            return Ok(tasks);
        }

        [HttpPost("task")]
        public async Task<IActionResult> CreateTaskOM(TaskDto taskDto)
        {
            await service.CreateTaskOM(taskDto);
            return Ok();
        }

        [HttpPut("task")]
        public async Task<IActionResult> UpdateTask(TaskDto taskDto)
        {
            await service.UpdateTask(taskDto);
            return Ok();
        }

        [HttpPost("task/description")]
        public async Task<IActionResult> AddTaskDescription([FromBody] List<TaskDesDto> taskDesDto)
        {
            await service.AddTaskDescription(taskDesDto);
            return Ok();
        }

        [HttpGet("task/description/{taskId}")]
        public async Task<IActionResult> GetDescriptions(string taskId)
        {
            var descriptions = await service.GetDescriptions(taskId);
            return Ok(descriptions);
        }
    }
}
