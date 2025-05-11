using PMSystem.Helpers;
using PMSystem.View;
using PMSystem.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;

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
            bool success = true;
            UserModel loggedUser = new UserModel();
            // Реальная логика авторизации должна быть здесь
            if (Username == "admin" && Password == "1234")
            {
                success = true;
                loggedUser = new UserModel(666, Username, $"{Username}@gmail.com", Password, true);
                MessageBox.Show($"Welcome, {Username}!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else if (Username == "user" && Password == "0987")
            {
                success = true;
                loggedUser = new UserModel(1, Username, $"{Username}@gmail.com", Password, false);
                MessageBox.Show($"Welcome, {Username}!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                success = false;
                MessageBox.Show("Incorrect username or password", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Password = string.Empty;
            }


            Username = string.Empty;
            Password = string.Empty;

            if (success)
            {
                if (loggedUser.IsAdmin)
                {
                    loggedUser.Role = "Admin";
                }
                else
                {
                    loggedUser.Role = "User";
                }
                

                _loginView.Close();
            }

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

