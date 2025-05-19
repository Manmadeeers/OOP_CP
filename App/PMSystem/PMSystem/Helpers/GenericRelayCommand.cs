using System.Windows.Input;

namespace PMSystem.Helpers
{
    public class GenericRelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute; // Action to execute

        private readonly Predicate<T> _canExecute; // Predicate to check if action can execute

        public event EventHandler CanExecuteChanged; // Event to notify change in CanExecute status

        // Constructor

        public GenericRelayCommand(Action<T> execute, Predicate<T> canExecute = null)

        {

            _execute = execute ?? throw new ArgumentNullException(nameof(execute));

            _canExecute = canExecute;

        }

        // Determines if the command can execute

        public bool CanExecute(object parameter)

        {

            return _canExecute == null || _canExecute((T)parameter);

        }

        // Executes the command action

        public void Execute(object parameter)

        {

            _execute((T)parameter);

        }

        // Method to raise CanExecuteChanged event

        public void RaiseCanExecuteChanged()

        {

            CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        }
    }
}
