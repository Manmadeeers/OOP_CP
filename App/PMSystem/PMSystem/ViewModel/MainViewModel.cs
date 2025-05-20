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

        private ObservableCollection<ProjectModel> _allProjects = new ObservableCollection<ProjectModel>();
        public ObservableCollection <ProjectModel> AllProjects
        {
            get => _allProjects;
            set
            {
                _allProjects = value;
                OnPropertyChanged(nameof(AllProjects));
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

        private ObservableCollection<TaskModel> _allTasks = new ObservableCollection<TaskModel>();
        public ObservableCollection<TaskModel> AllTasks
        {
            get => _allTasks;
            set
            {
                _allTasks = value;
                OnPropertyChanged(nameof(AllTasks));
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

        private ObservableCollection<UserModel>_allUsers = new ObservableCollection<UserModel>();
        public ObservableCollection<UserModel> AllUsers
        {
            get => _allUsers;
            set
            {
                _allUsers = value;
                OnPropertyChanged(nameof(AllUsers));
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
            if (ProjectsToShow.Count != 0)
            {
                Debug.WriteLine($"Loaded {ProjectsToShow.Count}. Name of first: {ProjectsToShow[0].ProjectName}");
            }
            else
            {
                Debug.WriteLine("Loaded 0 Projects.No name of first");
            }
            foreach(var project in ProjectsToShow)
            {
                AllProjects.Add(project);
            }
            this.MainView.SearchBlock.Visibility = Visibility.Visible;
            this.MainView.MainTitle.Visibility = Visibility.Collapsed;
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
                AllTasks.Add(task);
            }

            Debug.WriteLine($"Loaded tasks: {TasksToShow.Count}");
            this.MainView.SearchBlock.Visibility = Visibility.Visible;
            this.MainView.MainTitle.Visibility = Visibility.Collapsed;
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
                AllUsers.Add(user);
            }
            Debug.WriteLine($"Finally got {UsersToShow.Count} users");
            if (User.IsAdmin)
            {
                this.MainView.SearchBlock.Visibility = Visibility.Visible;
            }
            this.MainView.MainTitle.Visibility = Visibility.Collapsed;
            this.MainView.scroll.Visibility = Visibility.Visible;
            this.MainView.ContentControl.ItemsSource = UsersToShow;
        }
        private bool CanShowUsers(object parameter)
        {
            return true;
        }


        private string _filterText;
        public string FilterText
        {
            get => _filterText;
            set
            {
                if (_filterText != value)
                {
                    _filterText = value;
                    OnPropertyChanged(nameof(FilterText));
                }
            }
        }


        private ICommand _searchCommand;
        public ICommand SearchCommand => _searchCommand ??= new RelayCommand(Search,CanSearch);
        private void Search(object parameter)
        {

            if (this.MainView.ContentControl.ItemsSource == ProjectsToShow)
            {
                if (string.IsNullOrWhiteSpace(FilterText))
                {
                    ProjectsToShow.Clear();
                    foreach(var project in AllProjects)
                    {
                        ProjectsToShow.Add(project);
                    }
                }
                else
                {
                    ObservableCollection<ProjectModel> filteredProjects = new ObservableCollection<ProjectModel>(ProjectsToShow.Where(p => p.ProjectName.Contains(FilterText)).ToList());
                    ProjectsToShow.Clear();
                    foreach (var project in filteredProjects)
                    {
                        ProjectsToShow.Add(project);
                    }
                }
            }
            else if (this.MainView.ContentControl.ItemsSource == TasksToShow)
            {
                if (string.IsNullOrWhiteSpace(FilterText))
                {
                    TasksToShow.Clear();
                    foreach(var task in AllTasks)
                    {
                        TasksToShow.Add(task);
                    }
                }
                else
                {
                    ObservableCollection<TaskModel> filteredTasks = new ObservableCollection<TaskModel>(TasksToShow.Where(t=>t.TaskName.Contains(FilterText)).ToList());
                    TasksToShow.Clear();    
                    foreach(var task in filteredTasks)
                    {
                        TasksToShow.Add(task);
                    }
                }
                
            }
            else if (this.MainView.ContentControl.ItemsSource == UsersToShow)
            {
                if (string.IsNullOrWhiteSpace(FilterText))
                {
                    UsersToShow.Clear();
                    foreach(var user in AllUsers)
                    {
                        UsersToShow.Add(user);
                    }
                }
                else
                {
                    ObservableCollection<UserModel> filteredUsers = new ObservableCollection<UserModel>(UsersToShow.Where(u=>u.UserName.Contains(FilterText)).ToList());
                    UsersToShow.Clear();
                    foreach(var user in filteredUsers)
                    {
                        UsersToShow.Add(user);
                    }
                }
            }

           
        }
        private bool CanSearch(object parameter)
        {
            return true;
        }


        private ICommand _showTaskDetailsCommand;
        public ICommand ShowTaskDetailsCommand => _showTaskDetailsCommand ??= new GenericRelayCommand<TaskModel>(ShowTaskDetails, CanShowTaskDetails);
        private void ShowTaskDetails(TaskModel task)
        {
                TaskMoreView taskDetails = new TaskMoreView(User.IsAdmin);
                taskDetails.DataContext = new TaskMoreViewModel(task,User.IsAdmin);
                taskDetails.ShowDialog();
            
        }
        private bool CanShowTaskDetails(TaskModel task)
        {
            return true;
           
        }

        private ICommand _showDetailedUser;
        public ICommand ShowDetailedUser => _showDetailedUser ??= new GenericRelayCommand<UserModel>(ShowUserDetails,CanShowUserDetails);
        private void ShowUserDetails(UserModel user)
        {
            UserMoreView userView = new UserMoreView(User);
            userView.DataContext = new UserMoreViewModel(user,userView);
            userView.ShowDialog();
        }
        private bool CanShowUserDetails(UserModel user)
        {
            return true;
        }


        private ICommand _addNewProjectCommand;
        public ICommand AddNewProjectCommand => _addNewProjectCommand ??= new RelayCommand(ShowAddView,CanShowAddView);
        private void ShowAddView(object parameter)
        {
            AddNewProject addProjView = new AddNewProject();
            addProjView.ShowDialog();
        }
        private bool CanShowAddView(object parameter)
        {
            return true;
        }


        private ICommand _showAddTask;
        public ICommand ShowAddTaskCommand => _showAddTask ??= new RelayCommand(ShowAddTask,CanShowAddTask);
        private void ShowAddTask(object parameter)
        {
            AddNewTaskView addTaskView = new AddNewTaskView();
            addTaskView.DataContext = new AddNewTaskViewModel();
            addTaskView.ShowDialog();
        }
        private bool CanShowAddTask(object parameter)
        {
            return true;
        }


        private ICommand _showProjectInterCommand;
        public ICommand ShowProjectInterCommand => _showProjectInterCommand ??= new GenericRelayCommand<ProjectModel>(ShowProhectInter,CanShowProjectInter);
        private void ShowProhectInter(ProjectModel projectModel)
        {
            ProjectInterractionView projectView = new ProjectInterractionView(User);
            projectView.DataContext = new ProjectInterractionViewModel(User,projectModel,projectView);
            projectView.Show();
            MainView.Close();
        }
        private bool CanShowProjectInter(ProjectModel projectModel)
        {
            return true;
        }

        private ICommand _showaddUser;
        public ICommand ShowAddUser => _showaddUser ??= new RelayCommand(ShowUserAddition,CanShowUserAddition);

        private void ShowUserAddition(object parameter)
        {
            AddUserView addUserView = new AddUserView();
            addUserView.DataContext = new AddUserViewModel();
            addUserView.ShowDialog();
        }

        private bool CanShowUserAddition(object parameter)
        {
            return true;
        }


        private ICommand _statisticsCommand;
        public ICommand StatisticsCommand => _statisticsCommand ??= new RelayCommand(ShowStatistics,CanShowStatistics);

        private void ShowStatistics(object parameter)
        {
            StatisticsView stat = new StatisticsView(User);
            stat.DataContext = new StatisticsViewModel(User);
            stat.ShowDialog();
        }
        private bool CanShowStatistics(object parameter)
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
