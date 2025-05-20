using Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PMSystem.ViewModel
{
    public class StatisticsViewModel
    {
        private UserModel _user = new UserModel();
        private ObservableCollection<ProjectModel> _adminProjects = new ObservableCollection<ProjectModel>();
        public ObservableCollection<ProjectModel> AdminProjects
        {
            get => _adminProjects;
            set
            {
                _adminProjects = value;
                OnPropertyChanged(nameof(AdminProjects));
            }
        }

        private int _adminProjAmount;
        public int AdminProjAmount
        {
            get => _adminProjAmount;
            set
            {
                _adminProjAmount = value;
                OnPropertyChanged(nameof(AdminProjAmount));
            }
        }

        public StatisticsViewModel(UserModel user)
        {
            _user = user;
            AdminProjects = App.repository.GetAllProjects();
            AdminProjAmount = AdminProjects.Count();
            AdminUsers = App.repository.GetAllUsers();
            AdminUserCount = AdminUsers.Count();
            AdminTasks = App.repository.GetAllTasks();
            AdminTasksCount = AdminTasks.Count();
            UserCompletedTasks = new ObservableCollection<TaskModel>(App.repository.GetAllUsersCompletedTasks(_user.UserId).Where(t => t.UserId == _user.UserId).ToList());
            AmountCompletedTasks = UserCompletedTasks.Count;
            UserProgTasks = new ObservableCollection<TaskModel>(App.repository.GetAllUsersInProgressTasks(_user.UserId).Where(t => t.UserId == _user.UserId).ToList());
            AmountProgTasks = UserProgTasks.Count;
            UserNotTasks = new ObservableCollection<TaskModel>(App.repository.GetAllUsersNotStartedTasks(_user.UserId).Where(t => t.UserId == _user.UserId).ToList());
            AmountNotTasks = UserNotTasks.Count;
            AllTasks = AmountProgTasks + AmountNotTasks + AmountCompletedTasks;
            if (AllTasks != 0)
            {
                CompletionPercentage = AmountCompletedTasks / AllTasks;
            }
            else
            {
                CompletionPercentage=0;
            }
           
        }


        private ObservableCollection<UserModel> _adminUsers = new ObservableCollection<UserModel>();

        public ObservableCollection<UserModel> AdminUsers
        {
            get => _adminUsers;
            set
            {
                _adminUsers = value;
                OnPropertyChanged(nameof(AdminUsers));
            }
        }

        private int _adminUserCount;
        public int AdminUserCount
        {
            get => _adminUserCount;
            set
            {
                _adminUserCount = value;
                OnPropertyChanged(nameof(AdminUserCount));
            }
        }


        private ObservableCollection<TaskModel>_adminTasks = new ObservableCollection<TaskModel>();
        public ObservableCollection<TaskModel> AdminTasks
        {
            get => _adminTasks;
            set
            {
                _adminTasks = value;
                OnPropertyChanged(nameof(AdminTasks));
            }
        }


        private int _adminTasksCount;
        public int AdminTasksCount
        {
            get=>_adminTasksCount;
            set
            {
                _adminTasksCount = value;
                OnPropertyChanged(nameof(AdminTasksCount));
            }
        }



        private ObservableCollection<TaskModel>_userCompletedTasks = new ObservableCollection<TaskModel>();
        public ObservableCollection<TaskModel> UserCompletedTasks
        {
            get => _userCompletedTasks;
            set
            {
                _userCompletedTasks = value;
                OnPropertyChanged(nameof(UserCompletedTasks));
            }
        }

        public int AmountCompletedTasks { get; set; }


        private ObservableCollection<TaskModel>_userProgTasks = new ObservableCollection<TaskModel>();
        public ObservableCollection<TaskModel> UserProgTasks
        {
            get=> _userProgTasks;
            set
            {
                _userProgTasks = value;
                OnPropertyChanged(nameof(UserProgTasks));
            }
        }

        public int AmountProgTasks { get; set; }


        private ObservableCollection<TaskModel> _userNotTasks = new ObservableCollection<TaskModel>();
        public ObservableCollection<TaskModel> UserNotTasks
        {
            get => _userNotTasks;
            set
            {
                _userNotTasks = value;
                OnPropertyChanged(nameof(UserNotTasks));
            }
        }

        public int AmountNotTasks { get; set; }


        public double AllTasks { get; set; }
        public double CompletionPercentage { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;



        protected virtual void OnPropertyChanged(string propertyName)

        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
