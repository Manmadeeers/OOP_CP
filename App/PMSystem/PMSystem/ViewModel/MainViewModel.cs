using Models;
using PMSystem.Helpers;
using System.Windows.Input;
using PMSystem.View;


namespace PMSystem.ViewModel
{
    public class MainViewModel
    {

        public UserModel User { get; set; }
        public MainView MainView { get; set; }

        public MainViewModel(UserModel loggedUser,MainView mainView) 
        {
            User = loggedUser;
            MainView = mainView;
        }


        private ICommand _exitcommand;
        public ICommand ExitCommand => _exitcommand ??= new RelayCommand(Exit,CanExit);


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


    }
}
