using Models;
using System.ComponentModel;

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
        public TaskMoreViewModel(TaskModel taskModel)
        {
            TaskMod = taskModel;
        }







        public event PropertyChangedEventHandler PropertyChanged;



        protected virtual void OnPropertyChanged(string propertyName)

        {

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }
}
