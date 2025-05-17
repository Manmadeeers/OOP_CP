using PMSystem.Helpers;
using PMSystem.View;
using Models;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;
using System.Collections.ObjectModel;

namespace PMSystem.ViewModel
{
    internal class LogInViewModel:INotifyPropertyChanged
    {
        private string _username;
        private string _password;

        private LogInView _loginView;
        public LogInViewModel(LogInView loginView)
        {
            _loginView = loginView;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged();
                    LoginCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                if (_password != value)
                {
                    _password = value;
                    OnPropertyChanged();
                    LoginCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private RelayCommand _loginCommand;
        public RelayCommand LoginCommand => _loginCommand ??= new RelayCommand(Login, CanLogin);


        private ICommand _goToSignUpCommand;
        public ICommand GoToSignUpCommand => _goToSignUpCommand ??= new RelayCommand(GoToSignUpPage, CanGoToSignUp);

        private bool CanLogin(object parameter)
        {
            return !string.IsNullOrWhiteSpace(Username) && !string.IsNullOrWhiteSpace(Password);
        }

        private void Login(object parameter)
        {
            //bool success = true;

            UserModel loggedUser = new UserModel();
            
            ObservableCollection<UserModel> admins = App.repository.GetUsersWithRole("Admin");
           
            ObservableCollection<UserModel> allUsers = App.repository.GetAllUsers();
            bool found = false;
            foreach(var user in allUsers)
            {
                if (user.UserName == this.Username && user.UserPassword == this.Password)
                {
                    found = true;
                    loggedUser = user;
                    break;
                }
            }
            if(!found)
            {

                throw new LogInException("User Not Found");
                
            }


            Username = string.Empty;
            Password = string.Empty;


            MainView mainPage = new MainView(loggedUser);
            mainPage.Show();

            _loginView.Close();


            //if (success)
            //{
            //    if (loggedUser.IsAdmin)
            //    {
            //        loggedUser.UserRole = "Admin";
            //    }
            //    else
            //    {
            //        loggedUser.UserRole = "User";
            //    }


            //}

        }

        private bool CanGoToSignUp(object parameter) => true;
        private void GoToSignUpPage(object sender)
        {
            SignUpView signUpPage = new SignUpView();
            signUpPage.Show();
            _loginView.Close();
        }



        protected void OnPropertyChanged([CallerMemberName] string propName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}

