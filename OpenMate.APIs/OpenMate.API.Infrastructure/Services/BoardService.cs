using Microsoft.EntityFrameworkCore;
using OpenMate.API.Domain.DTOs;
using OpenMate.API.Domain.Entities.Board;
using OpenMate.API.Domain.Interfaces;
using OpenMate.API.Infrastructure.Data;

namespace OpenMate.API.Infrastructure.Services
{
    public class BoardService(DataContext context) : IBoardService
    {
        public Task AddTaskDescription(TaskDesDto taskDesDto)
        {
            throw new NotImplementedException();
        }

        public async Task CreateProject(ProjectDto projectDto)
        {
            var project = new Project
            {
                Id = GetProjectPrefix(projectDto.Name!) + Guid.NewGuid().ToString().Substring(0, 4),
                Name = projectDto.Name,
                Description = projectDto.Description,
                CustomerName = projectDto.CustomerName,
                StartDate = projectDto.StartDate,
                EndDate = projectDto.EndDate,
                ProductType = projectDto.ProductType,
                ProjectManager = projectDto.ProjectManager,
                Status = projectDto.Status
            };

            context.Projects.Add(project);
            await context.SaveChangesAsync();
        }

        public async Task CreateSprint(string projectID, int order)
        {
            var sprint = new Sprint
            {
                ProjectID = projectID,
                Order = order,
                Status = "Not Start"
            };

            context.Sprints.Add(sprint);
            await context.SaveChangesAsync();
        }

        public async Task CreateTaskOM(TaskDto taskDto)
        {
            var sprint = await context.Sprints.FindAsync(taskDto.SprintID);

            if (sprint == null)
            {
                throw new Exception("Sprint not found");
            }

            var project = await context.Projects.FindAsync(sprint.ProjectID);
            if (project == null)
            {
                throw new Exception("Project not found");
            }

            var newTask = new TaskOM
            {
                Id = project.Id + sprint.Id + Guid.NewGuid().ToString().Substring(0, 4),
                SprintID = taskDto.SprintID,
                Title = taskDto.Title,
                OwnerID = taskDto.OwnerID,
                AssigneeID = taskDto.AssigneeID,
                ReviewerID = taskDto.ReviewerID,
                TesterID = taskDto.TesterID,
                StartDate = taskDto.StartDate,
                EndDate = taskDto.EndDate,
                TicketType = taskDto.TicketType,
                Priority = taskDto.Priority,
                StoryPoint = taskDto.StoryPoint,
                Status = taskDto.Status,
                MoveFromSprint = -1
            };
        }

        public async Task DeleteProject(string id)
        {
            var project = await context.Projects.FindAsync(id);
            if (project == null)
            {
                throw new Exception("Project not found");
            }

            context.Projects.Remove(project);
            await context.SaveChangesAsync();
        }

        public async Task<Project> GetProject(string id)
        {
            var project = await context.Projects.FindAsync(id);
            if (project == null)
            {
                throw new Exception("Project not found");
            }
            return project;
        }

        public async Task<IEnumerable<Project>> GetProjects(string userId)
        {
            var projectsInvolved = await context.Members
                .Where(pm => pm.MemberID == userId)
                .Select(pm => pm.ProjectID)
                .ToListAsync();

            return await context.Projects
                .Where(p => projectsInvolved.Contains(p.Id))
                .ToListAsync();
        }

        public async Task<IEnumerable<Sprint>> GetSprints(string projectId)
        {
            return await context.Sprints
                .Where(s => s.ProjectID == projectId)
                .OrderBy(s => s.Order)
                .ToListAsync();
        }

        public async Task<IEnumerable<TaskOM>> GetTaskOMs(int sprintId)
        {
            return await context.Tasks
                .Where(t => t.SprintID == sprintId)
                .ToListAsync();
        }

        public async Task UpdateProject(string id, ProjectDto projectDto)
        {
            var project= await context.Projects.FindAsync(id);

            if (project != null)
            {
                project.Name = projectDto.Name;
                project.Description = projectDto.Description;
                project.CustomerName = projectDto.CustomerName;
                project.StartDate = projectDto.StartDate;
                project.EndDate = projectDto.EndDate;
                project.ProductType = projectDto.ProductType;
                project.ProjectManager = projectDto.ProjectManager;
                project.Status = projectDto.Status;

                await context.SaveChangesAsync();
            }
        }

        public string GetProjectPrefix(string projectName)
        {
            var words = projectName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return string.Concat(words.Select(word => char.ToUpper(word[0])));
        }
    }
}
