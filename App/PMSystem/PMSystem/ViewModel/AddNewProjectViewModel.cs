using Models;
using PMSystem.Helpers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;

namespace PMSystem.ViewModel
{
    public class AddNewProjectViewModel
    {

        private string _projectName;
        public string ProjectName
        {
            get => _projectName;
            set
            {
                if(_projectName != value)
                {
                    _projectName = value;
                    OnPropertyChanged(nameof(ProjectName));
                }
            }
        }

        private string _methodology;
        public string Methodology
        {
            get => _methodology;
            set
            {
                if(_methodology != value)
                {
                    _methodology = value;
                    OnPropertyChanged(nameof(Methodology));
                }
            }
        }

        private ObservableCollection<UserModel> _users = new ObservableCollection<UserModel>();
        public ObservableCollection<UserModel> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }
        private ObservableCollection<UserModel> _selectedUsers = new ObservableCollection<UserModel>();
        public ObservableCollection<UserModel> SelectedUsers
        {
            get=>_selectedUsers;
            set
            {
                _selectedUsers = value;
                OnPropertyChanged(nameof(SelectedUsers));
            }
        }
        public AddNewProjectViewModel()
        {
            this.Users = App.repository.GetAllUsers();
        }



        private ICommand _addCommand;
        public ICommand AddCommand => _addCommand ??= new RelayCommand(Add,CanAdd);
        private void Add(object parameter)
        {
            if (ProjectName != null && Methodology != null)
            {
                ProjectModel project = new ProjectModel(ProjectName, Methodology);
                foreach(var user in SelectedUsers)
                {
                    ProjectUser pu = new ProjectUser(project.ProjectId, user.UserId);
                    project.ProjectUsers.Add(pu);
                }
                if (App.repository.AddProject(project))
                {
                    MessageBox.Show("Project Added!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Something Went Wrong!", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                Debug.WriteLine(SelectedUsers.Count);
            }
            else
            {
                MessageBox.Show("Something Went Wrong!", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private bool CanAdd(object parameter)
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
