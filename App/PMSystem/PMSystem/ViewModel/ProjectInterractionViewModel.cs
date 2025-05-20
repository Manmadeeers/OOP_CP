using Models;
using PMSystem.Helpers;
using PMSystem.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace PMSystem.ViewModel
{
    public class ProjectInterractionViewModel
    {
        private ProjectInterractionView _view;
        public ProjectInterractionView View
        {
            get => _view;
            set => _view = value;
        }
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



        private ObservableCollection<string> _stats = new ObservableCollection<string>();
        public ObservableCollection<string> Stats
        {
            get => _stats;
            set
            {
                _stats = value;
                OnPropertyChanged(nameof(Stats));
            }
        }



        private void RefreshData()
        {
            NotStartedTasks = new ObservableCollection<TaskModel>(App.repository.GetAllUsersNotStartedTasks(User.UserId).Where(t => t.ProjectId == CurrentProject.ProjectId).ToList());
            InProgressTasks = new ObservableCollection<TaskModel>(App.repository.GetAllUsersInProgressTasks(User.UserId).Where(t => t.ProjectId == CurrentProject.ProjectId).ToList());
            FinishedTasks = new ObservableCollection<TaskModel>(App.repository.GetAllUsersCompletedTasks(User.UserId).Where(t => t.ProjectId == CurrentProject.ProjectId).ToList());
        }


        public ProjectInterractionViewModel(UserModel user, ProjectModel project,ProjectInterractionView view)
        {
            User = user;
            CurrentProject = project;
            RefreshData();
            Stats.Add("Not Started");
            Stats.Add("In Progress");
            Stats.Add("Finished");
            View = view;
            View.NotStartedTasks.DataContext = this;
        }


        private ICommand _goCommand;
        public ICommand GoCommand => _goCommand ??= new GenericRelayCommand<TaskModel>(Go,CanGo);
        private void Go(TaskModel task)
        {
            if (task.TaskStatus == "Not Started")
            {
                App.repository.UpdateTaskStatus("In Progress",task.TaskId);
                RefreshData();
            }
            else if(task.TaskStatus =="In progress")
            {
                App.repository.UpdateTaskStatus("Finished", task.TaskId);
                RefreshData();
            }
            else
            {
                MessageBox.Show("Ну куда дальше то?");
            }
        }
        private bool CanGo(TaskModel task)
        {
            return true;
        }



        public event PropertyChangedEventHandler PropertyChanged;



        protected virtual void OnPropertyChanged(string propertyName)

        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
