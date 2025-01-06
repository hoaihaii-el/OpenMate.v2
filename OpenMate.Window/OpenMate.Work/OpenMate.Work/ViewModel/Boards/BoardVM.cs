using OpenMate.Work.Helpers;
using OpenMate.Work.Model;
using OpenMate.Work.Resources.Uitilities;
using OpenMate.Work.Services;
using OpenMate.Work.Views.Boards;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace OpenMate.Work.ViewModel.Boards
{
    public partial class BoardVM : BaseViewModel
    {
        private ProjectService projectService = new ProjectService();

        private ObservableCollection<Sprint> _SprintCol;
        public ObservableCollection<Sprint> SprintCol
        {
            get => _SprintCol;
            set => SetProperty(ref _SprintCol, value);
        }

        private ObservableCollection<Project> _Projects;
        public ObservableCollection<Project> Projects
        {
            get => _Projects;
            set => SetProperty(ref _Projects, value);
        }

        private Project _SelectedProject;
        public Project SelectedProject
        {
            get => _SelectedProject;
            set
            {
                _SelectedProject = value;
                OnPropertyChanged(nameof(SelectedProject));
                InitializeSprintData();
            }
        }

        private Project _NewProject;
        public Project NewProject
        {
            get => _NewProject;
            set => SetProperty(ref _NewProject, value);
        }

        private ObservableCollection<Attendee> _Suggestions = new ObservableCollection<Attendee>();

        public ObservableCollection<Attendee> Suggestions
        {
            get => _Suggestions;
            set => SetProperty(ref _Suggestions, value);
        }

        private string _NewMember;
        public string NewMember
        {
            get => _NewMember;
            set
            {
                _NewMember = value;
                if (!string.IsNullOrEmpty(value))
                {
                    Suggestions = new ObservableCollection<Attendee>
                        (Helper.Attendees
                            .Where(p => p.Name.ToLower().Contains(value.ToLower()) || p.ID.Contains(value))
                            .ToList()
                        );
                }
                else
                {
                    Suggestions.Clear();
                }
                OnPropertyChanged(nameof(NewMember));
                OnPropertyChanged(nameof(Suggestions));
            }
        }

        private ObservableCollection<Log> _Logs;
        public ObservableCollection<Log> Logs
        {
            get => _Logs;
            set => SetProperty(ref _Logs, value);
        }

        public ICommand SprintItemClickCM { get; set; }
        public ICommand CardItemClickCM { get; set; }
        public ICommand OpenNewProjectCM { get; set; }
        public ICommand AddNewProjectCM { get; set; }
        public ICommand AddBackLogCM { get; set; }
        public ICommand UpdateProjectCM { get; set; }
        public ICommand OpenNewSprintCM { get; set; }
        public ICommand OpenAddMemberCM { get; set; }

        public BoardVM()
        {
            ManageCommand();
            GetProjects();
        }

        public async void GetProjects()
        {
            Projects = new ObservableCollection<Project>(await projectService.GetProjects(Helper.CurrentUserId));
            if (Projects.Count > 0)
            {
                SelectedProject = Projects[0];
            }
        }

        public async void AddProject()
        {
            NewProject.ProjectManager = new Attendee
            {
                ID = "24006",
                Name = "Hoài An"
            };
            await projectService.AddProject(NewProject);
            GetProjects();
        } 
        

        private void OpenSprintDetail(Sprint spr)
        {
            var detailSprint = new SprintDetail();
            detailSprint.DataContext = this;
            SelectedSprint = spr;
            LoadStoryPointStatistics(spr);
            detailSprint.ShowDialog();
        }

        public void OpenTicketDetail(TaskOM task)
        {
            Logs = new ObservableCollection<Log>
            {
                new Log
                {
                    LogOwner = "Hoài Nhân",
                    Comment = "Development done. Ready for test."
                },
                new Log
                {
                    LogOwner = "Hoài Hải",
                    Comment = "Bug nè. Xem OM-120 nhé.",
                    IsFromSender = true,
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/b/b4/Abstract_Kanban_Board.svg/1200px-Abstract_Kanban_Board.svg.png"
                },
            };

            var newBackLog = new AddBackLog();
            newBackLog.DataContext = this;
            newBackLog.ShowDialog();
        }

        public void ManageCommand()
        {
            SprintItemClickCM = new RelayCommand<Sprint>((p) => true, (p) =>
            {
                OpenSprintDetail(p);
            });

            CardItemClickCM = new RelayCommand<object>((p) => true, (p) =>
            {
                var newBackLog = new AddBackLog();
                newBackLog.DataContext = this;
                newBackLog.ShowDialog();
            });

            OpenNewProjectCM = new RelayCommand<object>((p) => true, (p) =>
            {
                var newProject = new NewProject();
                NewProject = new Project();
                newProject.DataContext = this;
                newProject.ShowDialog();
            });

            AddBackLogCM = new RelayCommand<object>((p) => true, (p) =>
            {
                var newBackLog = new AddBackLog();
                newBackLog.DataContext = this;
                newBackLog.ShowDialog();
            });

            UpdateProjectCM = new RelayCommand<object>((p) => true, async (p) =>
            {
                await projectService.UpdateProject(SelectedProject);
                GetProjects();
            });

            OpenNewSprintCM = new RelayCommand<object>((p) => true, (p) =>
            {
                var newSprint = new NewSprint();
                newSprint.DataContext = this;
                newSprint.ShowDialog();
            });

            OpenAddMemberCM = new RelayCommand<object>((p) => true, (p) =>
            {
                var addMember = new AddMember();
                addMember.DataContext = this;
                addMember.ShowDialog();
            });
        }
    }
}
