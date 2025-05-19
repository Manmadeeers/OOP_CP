using Models;
using System.ComponentModel;

namespace PMSystem.ViewModel
{
    public class UserMoreViewModel
    {

        private UserModel _currentUser = new UserModel();
        public UserModel CurrentUser
        {
            get=> _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }
        public UserMoreViewModel(UserModel user)
        {
            CurrentUser = user;
            Email = CurrentUser.UserEmail;
            Password = CurrentUser.UserPassword;
            UserName = CurrentUser.UserName;
        }


        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                if(_email != value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }


        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                if(_password != value)
                {
                    _password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }

        private string _username;
        public string UserName
        {
            get=>_username;
            set
            {
                if(_username != value)
                {
                    _username = value;
                    OnPropertyChanged(nameof(UserName));
                }
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;



        protected virtual void OnPropertyChanged(string propertyName)

        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
