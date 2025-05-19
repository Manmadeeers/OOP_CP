using Models;
using PMSystem.Helpers;
using PMSystem.View;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace PMSystem.ViewModel
{
    public class UserMoreViewModel
    {

        private UserModel _currentUser = new UserModel();
        private UserMoreView _view;
        public UserModel CurrentUser
        {
            get=> _currentUser;
            set
            {
                _currentUser = value;
                OnPropertyChanged(nameof(CurrentUser));
            }
        }
        public UserMoreViewModel(UserModel user,UserMoreView view)
        {
            _view = view;
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

        

        private ICommand _saveCommand;
        public ICommand SaveCommand => _saveCommand ??= new RelayCommand(Save,CanSave);
        private void Save(object parameter)
        {
            UserModel updUser = new UserModel(UserName, Email, Password, CurrentUser.IsAdmin);
            updUser.UserRole = CurrentUser.UserRole;
            if (App.repository.UpdateUser(updUser,CurrentUser.UserId))
            {
                MessageBox.Show("User was sucessfully updated!","Success",MessageBoxButton.OK,MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Something went wrong","Fail",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private bool CanSave(object parameter)
        {
            if (UserName != null&&Email != null && Password != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private ICommand _deleteCommand;
        public ICommand DeleteCommand => _deleteCommand ??= new RelayCommand(Delete,CanDelete);

        private void Delete(object parameter)
        {
            if (App.repository.DeleteUser(CurrentUser.UserId))
            {
                MessageBox.Show("User was deleted!","Success",MessageBoxButton.OK,MessageBoxImage.Information) ;
            }
            else
            { 
                MessageBox.Show("Something went wrong!","Fail",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }

        private bool CanDelete(object parameter)
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
