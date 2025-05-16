using Models;
using PMSystem.Helpers;
using PMSystem.View;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;


namespace PMSystem.ViewModel
{
    public class MainViewModel
    {

        public UserModel User { get; set; }
        public MainView MainView { get; set; }

        public List<ProjectModel> ProjectsToShow { get; set; } = new List<ProjectModel>();

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
            var projects = User.IsAdmin ? App.repository.GetAllProjects() : App.repository.GetAllProjectsByUserId(User.UserId);

            foreach (var project in projects)
            {
                ProjectsToShow.Add(project);
            }

            Debug.WriteLine($"Loaded {ProjectsToShow.Count}. Name of first: {ProjectsToShow[0].ProjectName}");
            this.MainView.MainTitle.Visibility = Visibility.Hidden;
            this.MainView.scroll.Visibility = Visibility.Visible;
        }
        private bool CanShowProjects(object parameter)
        {
            return true;
        }


    }
}
