using OpenMate.Work.Model;
using OpenMate.Work.Resources.Uitilities;
using OpenMate.Work.Views.Boards;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace OpenMate.Work.ViewModel.Boards
{
    public partial class BoardVM : BaseViewModel
    {
        private ObservableCollection<Task> _Log;
        public ObservableCollection<Task> Log
        {
            get => _Log;
            set => SetProperty(ref _Log, value);
        }

        private ObservableCollection<Task> _Doing;
        public ObservableCollection<Task> Doing
        {
            get => _Doing;
            set => SetProperty(ref _Doing, value);
        }

        private ObservableCollection<Task> _Review;
        public ObservableCollection<Task> Review
        {
            get => _Review;
            set => SetProperty(ref _Review, value);
        }

        private ObservableCollection<Task> _Finish;
        public ObservableCollection<Task> Finish
        {
            get => _Finish;
            set => SetProperty(ref _Finish, value);
        }

        private ObservableCollection<Sprint> _SprintCol;
        public ObservableCollection<Sprint> SprintCol
        {
            get => _SprintCol;
            set => SetProperty(ref _SprintCol, value);
        }

        private ObservableCollection<Log> _Logs;
        public ObservableCollection<Log> Logs
        {
            get => _Logs;
            set => SetProperty(ref _Logs, value);
        }

        public ICommand SprintItemClickCM { get; set; }
        public ICommand CardItemClickCM { get; set; }
        public ICommand NewProjectCM { get; set; }
        public ICommand AddBackLogCM { get; set; }

        public BoardVM()
        {
            HandleProjectMember();
            InitBackLog();

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

            NewProjectCM = new RelayCommand<object>((p) => true, (p) =>
            {
                var newProject = new NewProject();
                newProject.DataContext = this;
                newProject.ShowDialog();
            });

            AddBackLogCM = new RelayCommand<object>((p) => true, (p) =>
            {
                var newBackLog = new AddBackLog();
                newBackLog.DataContext = this;
                newBackLog.ShowDialog();
            });

            Log = new ObservableCollection<Task>
            {
                new Task()
                {
                    Title = "Task1",
                    Status = "Log"
                },
                new Task()
                {
                    Title = "Task2",
                    Status = "Log"
                },
                new Task()
                {
                    Title = "Task1",
                    Status = "Log"
                }
            };
            Doing = new ObservableCollection<Task>
            {
                new Task()
                {
                    Title = "Task1",
                    Status = "Doing"
                },
                new Task()
                {
                    Title = "Task1",
                    Status = "Doing"
                }
            };
            Review = new ObservableCollection<Task>
            {
                new Task()
                {
                    Title = "Task1",
                    Status = "Review"
                },
                new Task()
                {
                    Title = "Task2",
                    Status = "Review"
                },
                new Task()
                {
                    Title = "Task3",
                    Status = "Review"
                }
            };
            Finish = new ObservableCollection<Task>
            {
                new Task()
                {
                    Title = "Task1",
                    Status = "Finish"
                },
                new Task()
                {
                    Title = "Task2",
                    Status = "Finish"
                },
                new Task()
                {
                    Title = "Task3",
                    Status = "Finish"
                },
                new Task()
                {
                    Title = "Task4",
                    Status = "Finish"
                }
            };

            SprintCol = new ObservableCollection<Sprint>
            {
                new Sprint()
                {
                    SprintName = "Sprint 1",
                    StartDate = "1/1/2024",
                    EndDate = "10/2/2024",
                    Status = "Complete"
                },
                new Sprint()
                {
                    SprintName = "Sprint 2",
                    StartDate = "1/1/2024",
                    EndDate = "10/2/2024",
                    Status = "Complete"
                },
                new Sprint()
                {
                    SprintName = "Sprint 3",
                    StartDate = "1/1/2024",
                    EndDate = "10/2/2024",
                    Status = "Complete"
                },
                new Sprint()
                {
                    SprintName = "Sprint 4",
                    StartDate = "1/1/2024",
                    EndDate = "10/2/2024",
                    Status = "Active"
                },
                new Sprint()
                {
                    SprintName = "Sprint 5",
                    StartDate = "1/1/2024",
                    EndDate = "10/2/2024",
                    Status = "Not Start"
                },
                new Sprint()
                {
                    SprintName = "Sprint 6",
                    StartDate = "1/1/2024",
                    EndDate = "10/2/2024",
                    Status = "Not Start"
                },
                new Sprint()
                {
                    SprintName = "Sprint 7",
                    StartDate = "1/1/2024",
                    EndDate = "10/2/2024",
                    Status = "Not Start"
                }
            };

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
        }

        private void OpenSprintDetail(Sprint spr)
        {
            var detailSprint = new SprintDetail();
            detailSprint.DataContext = this;
            SelectedSprint = spr;
            LoadStoryPointStatistics();
            detailSprint.ShowDialog();
        }

        public void OpenTicketDetail(Task task)
        {
            var newBackLog = new AddBackLog();
            newBackLog.DataContext = this;
            newBackLog.ShowDialog();
        }
    }
}
