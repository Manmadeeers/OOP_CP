using Models;
using System.ComponentModel;
using System.Windows.Input;
using PMSystem.Helpers;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Windows;
using PMSystem.View;
using System.Collections.ObjectModel;

namespace PMSystem.ViewModel
{
    public class TaskMoreViewModel
    {
        private TaskModel _taskModel;
        public TaskModel TaskMod
        {
            get => _taskModel;
            set
            {
                _taskModel = value;
                OnPropertyChanged(nameof(TaskMod));

            }
        }

        private bool _granted;
        public TaskMoreViewModel(TaskModel taskModel,bool granted)
        {
            ResponsibleUser = App.repository.GetUserAssignedOnTask(taskModel.TaskId);
            TaskMod = taskModel;
            Note = TaskMod.Notes;
            _granted = granted;
            Name = TaskMod.TaskName;
            Description = TaskMod.TaskDescription;
            Status = TaskMod.TaskStatus;
            Stats.Add("In Progress");
            Stats.Add("Not Started");
            Stats.Add("Finished");
        }

        private string _note;
        public string Note
        {
            get => _note;
            set
            {
                if(_note!= value)
                {
                    _note = value;
                    OnPropertyChanged(nameof(Note));
                }
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                if(_description!= value)
                {
                    _description = value;
                    OnPropertyChanged(nameof(Description));
                }
              
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                if(_name!= value)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        private string _status;
        public string Status
        {
            get => _status;
            set
            {
                if(_status!= value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        private ObservableCollection<string>_stats = new ObservableCollection<string>();
        public ObservableCollection<string> Stats
        {
            get=> _stats;
            set
            {
                _stats = value;
                OnPropertyChanged(nameof(Stats));   

            }
        }

        private UserModel _responsibleUser = new UserModel();
        public UserModel ResponsibleUser
        {
            get => _responsibleUser;
            set
            {
                _responsibleUser = value;
                OnPropertyChanged(nameof(ResponsibleUser));
            }
        }

        private ICommand _saveCommand;
        public ICommand SaveCommand => _saveCommand ??= new RelayCommand(Save,CanSave);
        private void Save(object parameter)
        {
            if (Note != null && Name != null && Status != null && Description != null)
            {
                if (_granted)
                {
                    TaskMod.TaskName = Name;
                    TaskMod.TaskDescription = Description;
                    TaskMod.Notes = Note;
                    TaskMod.TaskStatus = Status;
                    App.repository.UpdateTaskInfo(TaskMod,TaskMod.TaskId);
                }
                else
                {
                    App.repository.UpdateTaskNotes(Note, TaskMod.TaskId);
                }
               
                MessageBox.Show("Changes Successfully applied!", "Success!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("FUCK");
            }
           
        }
           
        private bool CanSave(object parameter)
        {
            return true;
        }


        private ICommand _deleteCommand;
        public ICommand DeleteCommand => _deleteCommand ??= new RelayCommand(DeleteTask,CanDeleteTask);
        private void DeleteTask(object parameter)
        {
            // MessageBox.Show("Are you sure?", "Confirm Action", MessageBoxButton.OKCancel, MessageBoxImage.Warning);
            if (App.repository.DeleteTask(TaskMod.TaskId))
            {
                MessageBox.Show("Task Deleted!","Success",MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                MessageBox.Show("Something went wrong", "Fail", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }
        private bool CanDeleteTask(object parameter)
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
