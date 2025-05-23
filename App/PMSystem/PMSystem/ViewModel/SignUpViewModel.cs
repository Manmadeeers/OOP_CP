﻿using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows;
using PMSystem.View;
using PMSystem.Helpers;
using Models;
using System.Collections.ObjectModel;

namespace PMSystem.ViewModel
{
    public class SignUpViewModel:INotifyPropertyChanged
    {
        private string _username;
        private string _email;
        private string _password;
        public event PropertyChangedEventHandler PropertyChanged;
        public SignUpView SignUpView { get; private set; }
        public SignUpViewModel(SignUpView view)
        {
            SignUpView = view;
        }

        public string Username
        {
            get => _username;
            set
            {
                if (_username != value)
                {
                    _username = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                if (_email != value)
                {
                    _email = value;
                    OnPropertyChanged();
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
                
                    ((RelayCommand)SignUpCommand).RaiseCanExecuteChanged();
                }
            }
        }

        private ICommand _signUpCommand;
        public ICommand SignUpCommand => _signUpCommand ??= new RelayCommand(SignUp, CanSignUp);

        private ICommand _goToLoginCommand;
        public ICommand GoToLoginCommand => _goToLoginCommand ??= new RelayCommand(GoToLogInPage, CanTransferToPage);

        private bool CanSignUp(object parameter)
        {
            return !string.IsNullOrWhiteSpace(Username)
                && !string.IsNullOrWhiteSpace(Email)
                && !string.IsNullOrWhiteSpace(Password);
        }


        private void SignUp(object parameter)
        {
            // Логика регистрации
            if (!IsValidEmail(Email))
            {
                MessageBox.Show("Incorrect email!", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }


          
            
            ObservableCollection<UserModel> allUsers = App.repository.GetAllUsers();
            int lastId = allUsers.Last().UserId + 1;

            UserModel freshlySignedUser = new UserModel( Username, Email, Password, false);
            freshlySignedUser.UserRole = "User";
            
            if(allUsers.FirstOrDefault(u=>u.UserName==Username) is not null)
            {
                MessageBox.Show("Can't sign up! Such username already exists","Fail",MessageBoxButton.OK,MessageBoxImage.Error);
            }
            if(allUsers.FirstOrDefault(u=>u.UserEmail==Email) is not null)
            {
                MessageBox.Show("Can's sign up! Such email already exists", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            if (!App.repository.AddUser(freshlySignedUser))
            {
                MessageBox.Show("Something went wrong", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }

           //clean the form
            Username = string.Empty;
            Email = string.Empty;
            Password = string.Empty;

        
            MainView mainPage = new MainView(freshlySignedUser);
            mainPage.Show();
            SignUpView.Close();

        }


        private void GoToLogInPage(object sender)
        {
            var loginWindow = new LogInView();
            loginWindow.Show();
            SignUpView.Close();

        }

        private bool CanTransferToPage(object parameter)
        {
            return true;
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email); 
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (propertyName == nameof(Username) || propertyName == nameof(Email) || propertyName == nameof(Password))
            {
                ((RelayCommand)SignUpCommand).RaiseCanExecuteChanged();
            }
        }

    }
}
