using Models;
using PMSystem.Helpers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace PMSystem.ViewModel
{
    public class AddUserViewModel
    {

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if(_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));    
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


        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                if(_email!= value)
                {
                    _email = value;
                    OnPropertyChanged(nameof(Email));
                }
            }
        }

        private ObservableCollection<string>_roles = new ObservableCollection<string>();
        public ObservableCollection<string> Roles
        {
            get=> _roles;
            set
            {
                _roles = value;
                OnPropertyChanged(nameof(Roles));
            }
        }


        private string _selectedRole;
        public string SelectedRole
        {
            get => _selectedRole;
            set
            {
                _selectedRole = value;
                OnPropertyChanged(nameof(SelectedRole));
            }
        }


        private ICommand _addCommand;
        public ICommand AddCommand => _addCommand ??= new RelayCommand(Add,CanAdd);
        private void Add(object parameter)
        {
            if (SelectedRole != null && Name != null && Email != null && Password != null)
            {
                bool admin;
                if (SelectedRole == "Admin")
                {
                    admin = true;
                }
                else
                {
                    admin= false;
                }
                UserModel user = new UserModel(Name, Email, Password, admin);
                user.UserRole = SelectedRole;
                if (App.repository.AddUser(user))
                {
                    MessageBox.Show("User Added!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Something went wrong!","Fail",MessageBoxButton.OK,MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Not All Fields are filled!","Fail",MessageBoxButton.OK,MessageBoxImage.Error);
            }
        }
        private bool CanAdd(object parameter)
        {
            return true;
        }


        public AddUserViewModel()
        {
            Roles.Add("Admin");
            Roles.Add("User");
            Roles.Add("Trainee");
            Roles.Add("Developer");
        }

        public event PropertyChangedEventHandler PropertyChanged;



        protected virtual void OnPropertyChanged(string propertyName)

        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
