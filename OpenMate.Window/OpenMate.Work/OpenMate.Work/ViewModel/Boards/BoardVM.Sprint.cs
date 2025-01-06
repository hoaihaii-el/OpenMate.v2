using OpenMate.Work.Model;
using OpenMate.Work.Resources.Uitilities;
using System.Collections.ObjectModel;
using System.Linq;

namespace OpenMate.Work.ViewModel.Boards
{
    public partial class BoardVM : BaseViewModel
    {
        private ObservableCollection<TaskOM> _Todo;
        public ObservableCollection<TaskOM> Todo
        {
            get => _Todo;
            set => SetProperty(ref _Todo, value);
        }

        private ObservableCollection<TaskOM> _Doing;
        public ObservableCollection<TaskOM> Doing
        {
            get => _Doing;
            set => SetProperty(ref _Doing, value);
        }

        private ObservableCollection<TaskOM> _Review;
        public ObservableCollection<TaskOM> Review
        {
            get => _Review;
            set => SetProperty(ref _Review, value);
        }

        private ObservableCollection<TaskOM> _Finish;
        public ObservableCollection<TaskOM> Finish
        {
            get => _Finish;
            set => SetProperty(ref _Finish, value);
        }

        private Sprint _NewSprint = new Sprint();
        public Sprint NewSprint
        {
            get => _NewSprint;
            set => SetProperty(ref _NewSprint, value);
        }

        public async void InitializeSprintData()
        {
            try
            {
                SprintCol = new ObservableCollection<Sprint>(await projectService.GetSprints(SelectedProject.Id));
                if (SprintCol.Count > 0)
                {
                    SelectedSprint = SprintCol.Last();
                    GetTasks(SelectedSprint.Id);
                }
            }
            catch
            {
                Todo = new ObservableCollection<TaskOM>
                {
                    new TaskOM()
                    {
                        Title = "Task1",
                        Status = "Log"
                    },
                    new TaskOM()
                    {
                        Title = "Task2",
                        Status = "Log"
                    },
                    new TaskOM()
                    {
                        Title = "Task1",
                        Status = "Log"
                    }
                };
                Doing = new ObservableCollection<TaskOM>
                {
                    new TaskOM()
                    {
                        Title = "Task1",
                        Status = "Doing"
                    },
                    new TaskOM()
                    {
                        Title = "Task1",
                        Status = "Doing"
                    }
                };
                Review = new ObservableCollection<TaskOM>
                {
                    new TaskOM()
                    {
                        Title = "Task1",
                        Status = "Review"
                    },
                    new TaskOM()
                    {
                        Title = "Task2",
                        Status = "Review"
                    },
                    new TaskOM()
                    {
                        Title = "Task3",
                        Status = "Review"
                    }
                };
                Finish = new ObservableCollection<TaskOM>
                {
                    new TaskOM()
                    {
                        Title = "Task1",
                        Status = "Finish"
                    },
                    new TaskOM()
                    {
                        Title = "Task2",
                        Status = "Finish"
                    },
                    new TaskOM()
                    {
                        Title = "Task3",
                        Status = "Finish"
                    },
                    new TaskOM()
                    {
                        Title = "Task4",
                        Status = "Finish"
                    }
                };
            }
        }

        public async void GetTasks(int sprintId)
        {
            var tasks = await projectService.GetTasks(sprintId);

            Todo = new ObservableCollection<TaskOM>(tasks.Where(t => t.Status == "To do"));
            Doing = new ObservableCollection<TaskOM>(tasks.Where(t => t.Status == "Doing"));
            Review = new ObservableCollection<TaskOM>(tasks.Where(t => t.Status == "Review"));
            Finish = new ObservableCollection<TaskOM>(tasks.Where(t => t.Status == "Finish"));
        }

        public void AddSprint()
        {
            NewSprint.ProjectID = SelectedProject.Id;
            NewSprint.Status = "Not Started";
            projectService.AddSprint(NewSprint);
            SprintCol.Add(NewSprint);
        }
    }
}
