using Models;
using PMSystem.Helpers;
using PMSystem.View;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;


namespace PMSystem.ViewModel
{
    public class MainViewModel:INotifyPropertyChanged
    {

        public UserModel User { get; set; }
        public MainView MainView { get; set; }
       
        private ObservableCollection<ProjectModel> _projectsToShow = new ObservableCollection<ProjectModel>();

        public ObservableCollection<ProjectModel> ProjectsToShow
        {
            get => _projectsToShow;
            set
            {
                _projectsToShow = value;
                OnPropertyChanged(nameof(ProjectsToShow));
            }
        }

        private ObservableCollection<TaskModel>_tasksToShow = new ObservableCollection<TaskModel>();
        public ObservableCollection<TaskModel> TasksToShow
        {
            get => _tasksToShow;
            set
            {
                _tasksToShow = value;
                OnPropertyChanged(nameof(TasksToShow));
            }
        }

        private ObservableCollection<UserModel>_usersToShow = new ObservableCollection<UserModel>();
        public ObservableCollection<UserModel> UsersToShow
        {
            get => _usersToShow;
            set
            {
                _usersToShow = value;
                OnPropertyChanged(nameof(UsersToShow));
            }
        }
        public MainViewModel(UserModel loggedUser, MainView mainView)
        {
            User = loggedUser;
            MainView = mainView;
        }


        private ICommand _exitcommand;
        public ICommand ExitCommand => _exitcommand ??= new RelayCommand(Exit, CanExit);


        private void Exit(object parameter)
        {
            LogInView logInPage = new LogInView();
            MainView.Close();
            logInPage.Show();
        }

        private bool CanExit(object parameter)
        {
            return true;
        }


        private ICommand _showProjectsCommand;

        public ICommand ShowProjectsCommand => _showProjectsCommand ??= new RelayCommand(ShowProjects, CanShowProjects);


        private void ShowProjects(object parameter)
        {
            ProjectsToShow.Clear();
            ObservableCollection<ProjectModel> projects = User.IsAdmin ? App.repository.GetAllProjects() : App.repository.GetAllProjectsByUserId(User.UserId);
            Debug.WriteLine($"Projects loaded: {projects.Count}");
            foreach (var project in projects)
            {
                ProjectsToShow.Add(project);
            }

            Debug.WriteLine($"Loaded {ProjectsToShow.Count}. Name of first: {ProjectsToShow[0].ProjectName}");
            this.MainView.MainTitle.Visibility = Visibility.Hidden;
            this.MainView.scroll.Visibility = Visibility.Visible;
            this.MainView.ContentControl.ItemsSource = ProjectsToShow;
        }
        private bool CanShowProjects(object parameter)
        {
            return true;
        }


        private ICommand _showTasksCommand;
        public ICommand ShowTasksCommand => _showTasksCommand ??= new RelayCommand(ShowTasks,CanShowTasks);
        private void ShowTasks(object parameter)
        {
            TasksToShow.Clear();
            var tasks = User.IsAdmin?App.repository.GetAllTasks():App.repository.GetAllTasksByUserId(User.UserId);
            Debug.WriteLine($"Tasks: {tasks}");
            foreach(var task in tasks)
            {
                TasksToShow.Add(task);
            }
            Debug.WriteLine($"Loaded tasks: {TasksToShow.Count}");
            this.MainView.MainTitle.Visibility = Visibility.Hidden;
            this.MainView.scroll.Visibility = Visibility.Visible;
            this.MainView.ContentControl.ItemsSource = TasksToShow;
        }
        private bool CanShowTasks(object parameter)
        {
            return true;
        }

        private ICommand _showUsersCommand;
        public ICommand ShowUsersCommand => _showUsersCommand ??= new RelayCommand(ShowUsers,CanShowUsers);
        private void ShowUsers(object parameter)
        {
            UsersToShow.Clear();
            var users = App.repository.GetAllUsers();
            Debug.WriteLine($"Got {users.Count} users");
            foreach(var user in users)
            {
                UsersToShow.Add(user);
            }
            Debug.WriteLine($"Finally got {UsersToShow.Count} users");
            this.MainView.MainTitle.Visibility = Visibility.Hidden;
            this.MainView.scroll.Visibility = Visibility.Visible;
            this.MainView.ContentControl.ItemsSource = UsersToShow;
        }
        private bool CanShowUsers(object parameter)
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
