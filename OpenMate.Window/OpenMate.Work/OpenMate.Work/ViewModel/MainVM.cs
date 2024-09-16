using OpenMate.Work.Model;
using OpenMate.Work.Resources.Uitilities;
using System.Collections.ObjectModel;

namespace OpenMate.Work.ViewModel
{
    public class MainVM : BaseViewModel
    {
        private ObservableCollection<User> _Users = new ObservableCollection<User>();
        public ObservableCollection<User> Users
        {
            get => _Users;
            set => SetProperty(ref _Users, value);
        }

        public MainVM()
        {
            Users = new ObservableCollection<User>()
            {
                new User()
                {
                    Id = 1,
                    Name = "Test 1",
                    IsSelected = true,
                },
                new User()
                {
                    Id = 1,
                    Name = "Hoai Hai"
                },
                new User()
                {
                    Id = 1,
                    Name = "Van Hau"
                },
                new User()
                {
                    Id = 1,
                    Name = "Test 2"
                },
            };
        }
    }
}
