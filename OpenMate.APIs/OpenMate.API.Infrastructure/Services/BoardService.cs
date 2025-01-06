using Microsoft.EntityFrameworkCore;
using OpenMate.API.Domain.DTOs;
using OpenMate.API.Domain.Entities.Board;
using OpenMate.API.Domain.Interfaces;
using OpenMate.API.Domain.Responses;
using OpenMate.API.Infrastructure.Data;

namespace OpenMate.API.Infrastructure.Services
{
    public class BoardService(DataContext context) : IBoardService
    {
        public async Task AddTaskDescription(List<TaskDesDto> taskDesDto)
        {
            int order = 1;
            foreach (var des in taskDesDto)
            {
                var taskDes = new TaskDescription
                {
                    TaskID = des.TaskID,
                    Order = order,
                    IsImage = des.IsImage,
                    Xaml = des.Xaml,
                    ImageUrl = des.ImageUrl
                };

                context.TaskDescriptions.Add(taskDes);
                order++;
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TaskDesDto>> GetDescriptions(string taskId)
        {
            var descriptions = await context.TaskDescriptions
                .Where(d => d.TaskID == taskId)
                .OrderBy(d => d.Order)
                .Select(d => new TaskDesDto
                {
                    TaskID = d.TaskID,
                    Order = d.Order,
                    IsImage = d.IsImage,
                    Xaml = d.Xaml,
                    ImageUrl = d.ImageUrl
                })
                .ToListAsync();

            return descriptions;
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
                ProjectManager = projectDto.ProjectManager!.ID,
                Status = projectDto.Status
            };

            context.Projects.Add(project);
            await context.SaveChangesAsync();

            if (projectDto.Members != null)
            {
                foreach (var member in projectDto.Members)
                {
                    var newMember = new Member
                    {
                        ProjectID = project.Id,
                        MemberID = member.ID,
                        Role = member.Role,
                        Effort = member.Effort
                    };

                    context.Members.Add(newMember);
                }

                await context.SaveChangesAsync();
            }
        }

        public async Task CreateSprint(SprintDto dto)
        {
            var lastestSprint = await context.Sprints
                .Where(s => s.ProjectID == dto.ProjectID)
                .OrderByDescending(s => s.Order)
                .FirstOrDefaultAsync();

            var newSprint = new Sprint
            {
                ProjectID = dto.ProjectID,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Status = "Not Started",
                Order = lastestSprint == null ? 1 : lastestSprint.Order + 1
            };

            context.Sprints.Add(newSprint);
            await context.SaveChangesAsync();
        }

        public async Task UpdateSprint(SprintDto dto)
        {
            var sprint = await context.Sprints.FindAsync(dto.Id);
            sprint!.Status = dto.Status;
            sprint.StartDate = dto.StartDate;
            sprint.EndDate = dto.EndDate;

            context.Sprints.Update(sprint);
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
                Id = project.Id + Guid.NewGuid().ToString().Substring(0, 4),
                SprintID = taskDto.SprintID,
                Title = taskDto.Title,
                OwnerID = taskDto.Owner!.ID,
                AssigneeID = taskDto.Assignee!.ID,
                ReviewerID = taskDto.Reviewer!.ID,
                TesterID = taskDto.Tester!.ID,
                StartDate = taskDto.StartDate,
                EndDate = taskDto.EndDate,
                TicketType = taskDto.TicketType,
                Priority = taskDto.Priority,
                StoryPoint = taskDto.StoryPoint,
                Status = "To do",
                MoveFromSprint = -1
            };

            context.Tasks.Add(newTask);
            await context.SaveChangesAsync();

            UpdateSprintDetail(newTask.SprintID);
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

        public async Task<IEnumerable<ProjectDto>> GetProjects(string userId)
        {
            var projectsInvolved = await context.Members
                .Where(pm => pm.MemberID == userId)
                .Select(pm => pm.ProjectID)
                .ToListAsync();

            var projects = await context.Projects
                .Where(p => projectsInvolved.Contains(p.Id))
                .Select(p => new ProjectDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    CustomerName = p.CustomerName,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate,
                    ProductType = p.ProductType,
                    ProjectManager = new AttendeeRes
                    {
                        ID = p.ProjectManager,
                    },
                    Status = p.Status
                })
                .ToListAsync();

            foreach (var pr in projects)
            {
                pr.ProjectManager!.Name = (await context.Users.FindAsync(pr.ProjectManager.ID))!.Name;
                var members = await context.Members
                    .Where(m => m.ProjectID == pr.Id)
                    .Select(m => new MemberRes
                    {
                        ID = m.MemberID,
                        Role = m.Role,
                        Effort = m.Effort
                    })
                    .ToListAsync();

                foreach (var member in members)
                {
                    member.Name = (await context.Users.FindAsync(member.ID))!.Name;
                }

                pr.Members = members;
            }

            return projects;
        }

        public async Task<IEnumerable<Sprint>> GetSprints(string projectId)
        {
            return await context.Sprints
                .Where(s => s.ProjectID == projectId)
                .OrderBy(s => s.Order)
                .ToListAsync();
        }

        public async Task<IEnumerable<TaskDto>> GetTaskOMs(int sprintId)
        {
            var tasks = await context.Tasks
                .Where(t => t.SprintID == sprintId)
                .Select(t => new TaskDto
                {
                    Id = t.Id,
                    SprintID = t.SprintID,
                    Title = t.Title,
                    Owner = new AttendeeRes
                    {
                        ID = t.OwnerID
                    },
                    Assignee = new AttendeeRes
                    {
                        ID = t.AssigneeID
                    },
                    Reviewer = new AttendeeRes
                    {
                        ID = t.ReviewerID
                    },
                    Tester = new AttendeeRes
                    {
                        ID = t.TesterID
                    },
                    StartDate = t.StartDate,
                    EndDate = t.EndDate,
                    TicketType = t.TicketType,
                    Priority = t.Priority,
                    StoryPoint = t.StoryPoint,
                    Status = t.Status,
                    MoveFromSprint = t.MoveFromSprint
                })
                .ToListAsync();

            foreach (var task in tasks)
            {
                task.Owner!.Name = (await context.Users.FindAsync(task.Owner.ID))!.Name;
                task.Assignee!.Name = (await context.Users.FindAsync(task.Assignee.ID))!.Name;
                task.Reviewer!.Name = (await context.Users.FindAsync(task.Reviewer.ID))!.Name;
                task.Tester!.Name = (await context.Users.FindAsync(task.Tester.ID))!.Name;
            }

            return tasks;
        }

        public async Task UpdateProject(ProjectDto projectDto)
        {
            var project= await context.Projects.FindAsync(projectDto.Id);

            if (project != null)
            {
                project.Name = projectDto.Name;
                project.Description = projectDto.Description;
                project.CustomerName = projectDto.CustomerName;
                project.StartDate = projectDto.StartDate;
                project.EndDate = projectDto.EndDate;
                project.ProductType = projectDto.ProductType;
                project.ProjectManager = projectDto.ProjectManager!.ID;
                project.Status = projectDto.Status;

                await context.SaveChangesAsync();
            }

            if (projectDto.Members != null)
            {
                foreach (var member in projectDto.Members)
                {
                    var memberInDb = await context.Members
                        .Where(m => m.ProjectID == project!.Id && m.MemberID == member.ID)
                        .FirstOrDefaultAsync();

                    memberInDb!.Role = member.Role;
                    memberInDb.Effort = member.Effort;
                }

                await context.SaveChangesAsync();
            }
        }

        public string GetProjectPrefix(string projectName)
        {
            var words = projectName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            return string.Concat(words.Select(word => char.ToUpper(word[0])));
        }

        public async Task UpdateTask(TaskDto taskDto)
        {
            var task = await context.Tasks.FindAsync(taskDto.Id);

            if (task != null)
            {
                task.Title = taskDto.Title;
                task.OwnerID = taskDto.Owner!.ID;
                task.AssigneeID = taskDto.Assignee!.ID;
                task.ReviewerID = taskDto.Reviewer!.ID;
                task.TesterID = taskDto.Tester!.ID;
                task.StartDate = taskDto.StartDate;
                task.EndDate = taskDto.EndDate;
                task.TicketType = taskDto.TicketType;
                task.Priority = taskDto.Priority;
                task.StoryPoint = taskDto.StoryPoint;
                task.Status = taskDto.Status;
                task.MoveFromSprint = taskDto.MoveFromSprint;

                await context.SaveChangesAsync();

                UpdateSprintDetail(task!.SprintID);
            }
        }

        public async void UpdateSprintDetail(int? sprintId)
        {
            var sprint = await context.Sprints.FindAsync(sprintId);
            var tasks = await context.Tasks
                .Where(t => t.SprintID == sprint!.Id)
                .ToListAsync();

            sprint!.Todo = tasks.Count(t => t.Status == "To do");
            sprint.Doing = tasks.Count(t => t.Status == "Doing");
            sprint.Review = tasks.Count(t => t.Status == "Review");
            sprint.Finish = tasks.Count(t => t.Status == "Finish");

            context.Sprints.Update(sprint);
            await context.SaveChangesAsync();
        }

        public async Task<SprintStatisticsDto> GetSprintStatistics(int sprintId)
        {
            var stats = new SprintStatisticsDto();

            var sprint = await context.Sprints.FindAsync(sprintId);
            var sprints = await context.Sprints
                .Where(s => s.ProjectID == sprint!.ProjectID)
                .OrderBy(s => s.Order)
                .ToListAsync();

            foreach (var sp in sprints)
            {
                if (sp.Order > sprint!.Order)
                {
                    break;
                }

                stats.StoryPoints.Add(await context.Tasks
                    .Where(t => t.SprintID == sp.Id)
                    .SumAsync(t => t.StoryPoint));
            }

            var defects = await context.Tasks
                .Where(t => t.TicketType == "Bug")
                .GroupBy(t => t.OwnerID)
                .Select(g => new
                {
                    OwnerID = g.Key,
                    Count = g.Count()
                })
                .ToListAsync();

            foreach (var defect in defects)
            {
                var owner = await context.Users.FindAsync(defect.OwnerID);
                stats.Defects.Add((owner!.Name, defect.Count)!);
            }

            return stats;
        }
    }
}
