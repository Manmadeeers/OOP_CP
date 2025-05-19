using Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PMSystem.ViewModel
{
    public class ProjectInterractionViewModel
    {
        private UserModel _user = new UserModel();
        public UserModel User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        private ProjectModel _currentProject = new ProjectModel();
        public ProjectModel CurrentProject
        {
            get=>_currentProject;
            set
            {
                _currentProject = value;
                OnPropertyChanged(nameof(CurrentProject));
            }
        }


        private ObservableCollection<TaskModel>_notStartedTasks = new ObservableCollection<TaskModel>();    
        public ObservableCollection<TaskModel> NotStartedTasks
        {
            get => _notStartedTasks;
            set
            {
                _notStartedTasks = value;
                OnPropertyChanged(nameof(NotStartedTasks));
            }
        }

        private ObservableCollection<TaskModel>_inProgressTasks = new ObservableCollection<TaskModel>();
        public ObservableCollection<TaskModel> InProgressTasks
        {
            get => _inProgressTasks;
            set
            {
                _inProgressTasks = value;
                OnPropertyChanged(nameof(InProgressTasks));
            }
        }

        private ObservableCollection<TaskModel> _finishedTasks = new ObservableCollection<TaskModel>();
        public ObservableCollection <TaskModel> FinishedTasks
        {
            get => _finishedTasks;
            set
            {
                _finishedTasks = value;
                OnPropertyChanged(nameof(FinishedTasks));
            }
        }









        public ProjectInterractionViewModel(UserModel user, ProjectModel project)
        {
            User = user;
            CurrentProject = project;
            NotStartedTasks = App.repository.GetAllUsersNotStartedTasks(User.UserId);
            InProgressTasks = App.repository.GetAllUsersInProgressTasks(User.UserId);
            FinishedTasks = App.repository.GetAllUsersCompletedTasks(User.UserId);
        }



        public event PropertyChangedEventHandler PropertyChanged;



        protected virtual void OnPropertyChanged(string propertyName)

        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
