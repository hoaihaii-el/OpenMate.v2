using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OpenMate.API.Domain.DTOs;
using OpenMate.API.Domain.Interfaces;

namespace OpenMate.API.BoardService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardController(IBoardService service) : ControllerBase
    {
        [HttpGet("projects")]
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

        [HttpPut("project/{id}")]
        public async Task<IActionResult> UpdateProject(string id, ProjectDto projectDto)
        {
            await service.UpdateProject(id, projectDto);
            return Ok();
        }

        [HttpGet("sprints/{projectId}")]
        public async Task<IActionResult> GetSprints(string projectId)
        {
            var sprints = await service.GetSprints(projectId);
            return Ok(sprints);
        }

        [HttpPost("sprint")]
        public async Task<IActionResult> CreateSprint(string projectID, int order)
        {
            await service.CreateSprint(projectID, order);
            return Ok();
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

        [HttpPost("task/description")]
        public async Task<IActionResult> AddTaskDescription(TaskDesDto taskDesDto)
        {
            await service.AddTaskDescription(taskDesDto);
            return Ok();
        }
    }
}
