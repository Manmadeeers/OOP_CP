using Models;
using PMSystem.Helpers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace PMSystem.ViewModel
{
    public class AddNewTaskViewModel
    {

        private ObservableCollection<string>_statuses = new ObservableCollection<string>();
        public ObservableCollection<string> Statuses
        {
            get=> _statuses;
            set => _statuses = value;
        }

        private ObservableCollection<ProjectModel>_projects = new ObservableCollection<ProjectModel>();
        public ObservableCollection<ProjectModel> Projects
        {
            get=> _projects;
            set => _projects = value;
        }

        private ProjectModel _selectedProject;
        public ProjectModel SelectedProject
        {
            get=> _selectedProject;
            set
            {
                _selectedProject = value;
                OnPropertyChanged(nameof(SelectedProject));
            }
        }

        private ObservableCollection<UserModel>_users = new ObservableCollection<UserModel>();
        public ObservableCollection<UserModel> Users
        {
            get => _users;
            set
            {
                _users = value;
                OnPropertyChanged(nameof(Users));
            }
        }

        private UserModel _selectedUser;
        public UserModel SelectedUser
        {
            get => _selectedUser;
            set
            {
                _selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }


        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if (_name != value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                if(_description != value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
            }
        }

        private string _note;
        public string Note
        {
            get => _note;
            set
            {
                if( _note != value)
                {
                    _note = value;
                    OnPropertyChanged(nameof(Note));
                }
            }
        }

        private string _status;
        public string Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        public AddNewTaskViewModel()
        {
            Statuses.Add("Not Started");
            Statuses.Add("In Progress");
            Statuses.Add("Finished");
            Projects = App.repository.GetAllProjects();
            Users = App.repository.GetAllUsers();
        }

        private ICommand _addCommand;
        public ICommand AddCommand => _addCommand ??= new RelayCommand(Add,CanAdd);
        private void Add(object parameter)
        {
            TaskModel newTask = new TaskModel(Name,Status,Description,Note,SelectedProject.ProjectId,SelectedUser.UserId);
            if (App.repository.AddTask(newTask))
            {
                MessageBox.Show("Task added!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Something went wrong","Fail",MessageBoxButton.OK,MessageBoxImage.Error);
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
