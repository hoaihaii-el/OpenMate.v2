using OpenMate.Work.Model;
using OpenMate.Work.Resources.Uitilities;
using OpenMate.Work.Views.Boards;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace OpenMate.Work.ViewModel
{
    public class BoardVM : BaseViewModel
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

        public ICommand SprintItemClickCM { get; set; }

        public BoardVM()
        {
            SprintItemClickCM = new RelayCommand<Sprint>((p) => true, (p) =>
            {
                OpenSprintDetail(p);
            });

            Log = new ObservableCollection<Task>
            {
                new Task()
                {
                    Name = "Task1",
                    Status = "Log"
                },
                new Task()
                {
                    Name = "Task2",
                    Status = "Log"
                },
                new Task()
                {
                    Name = "Task1",
                    Status = "Log"
                }
            };
            Doing = new ObservableCollection<Task>
            {
                new Task()
                {
                    Name = "Task1",
                    Status = "Doing"
                },
                new Task()
                {
                    Name = "Task1",
                    Status = "Doing"
                }
            };
            Review = new ObservableCollection<Task>
            {
                new Task()
                {
                    Name = "Task1",
                    Status = "Review"
                },
                new Task()
                {
                    Name = "Task2",
                    Status = "Review"
                },
                new Task()
                {
                    Name = "Task3",
                    Status = "Review"
                }
            };
            Finish = new ObservableCollection<Task>
            {
                new Task()
                {
                    Name = "Task1",
                    Status = "Finish"
                },
                new Task()
                {
                    Name = "Task2",
                    Status = "Finish"
                },
                new Task()
                {
                    Name = "Task3",
                    Status = "Finish"
                },
                new Task()
                {
                    Name = "Task4",
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
        }

        private void OpenSprintDetail(Sprint spr)
        {
            var detailSprint = new SprintDetail(spr);
            detailSprint.ShowDialog();
        }
    }
}
