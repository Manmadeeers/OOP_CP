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
            var allNotStarted  = new ObservableCollection<TaskModel>(App.repository.GetAllUsersNotStartedTasks(User.UserId).Where(t => t.ProjectId == CurrentProject.ProjectId).ToList());
            NotStartedTasks.Clear();
            foreach(var task in allNotStarted)
            {
                NotStartedTasks.Add(task);
            }
            var allinProgress = new ObservableCollection<TaskModel>(App.repository.GetAllUsersInProgressTasks(User.UserId).Where(t => t.ProjectId == CurrentProject.ProjectId).ToList());
            InProgressTasks.Clear();
            foreach(var task in allinProgress)
            {
                InProgressTasks.Add(task);
            }
            var allFinished = new ObservableCollection<TaskModel>(App.repository.GetAllUsersCompletedTasks(User.UserId).Where(t => t.ProjectId == CurrentProject.ProjectId).ToList());
            FinishedTasks.Clear();
            foreach(var task in allFinished)
            {
                FinishedTasks.Add(task);
            }
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
        public ICommand GoCommand =>_goCommand ??= new GenericRelayCommand<TaskModel>(Go, CanGo);
        private void Go(TaskModel task)
        {
            if (task.TaskStatus == "Not Started")
            {
                App.repository.UpdateTaskStatus("In Progress",task.TaskId);
                RefreshData();
            }
            else if(task.TaskStatus =="In Progress")
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


        private ICommand _showTaskDetailsCommand;
        public ICommand ShowTaskDetailsCommand => _showTaskDetailsCommand ??= new GenericRelayCommand<TaskModel>(ShowTaskDetails, CanShowTaskDetails);
        private void ShowTaskDetails(TaskModel task)
        {
            TaskMoreView taskDetails = new TaskMoreView(User.IsAdmin);
            taskDetails.DataContext = new TaskMoreViewModel(task, User.IsAdmin);
            taskDetails.ShowDialog();
            RefreshData();
        }
        private bool CanShowTaskDetails(TaskModel task)
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
