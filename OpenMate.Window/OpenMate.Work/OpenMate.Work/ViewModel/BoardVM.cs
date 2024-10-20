using OpenMate.Work.Model;
using OpenMate.Work.Resources.Uitilities;
using System.Collections.ObjectModel;

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

        public BoardVM()
        {
            Log = new ObservableCollection<Task>
            {
                new Task()
                {
                    Name = "Task1"
                },
                new Task()
                {
                    Name = "Task2"
                },
                new Task()
                {
                    Name = "Task1"
                }
            };
            Doing = new ObservableCollection<Task>
            {
                new Task()
                {
                    Name = "Task1"
                },
                new Task()
                {
                    Name = "Task1"
                }
            };
            Review = new ObservableCollection<Task>
            {
                new Task()
                {
                    Name = "Task1"
                },
                new Task()
                {
                    Name = "Task2"
                },
                new Task()
                {
                    Name = "Task3"
                }
            };
            Finish = new ObservableCollection<Task>
            {
                new Task()
                {
                    Name = "Task1"
                },
                new Task()
                {
                    Name = "Task2"
                },
                new Task()
                {
                    Name = "Task3"
                },
                new Task()
                {
                    Name = "Task4"
                }
            };
        }
    }
}
