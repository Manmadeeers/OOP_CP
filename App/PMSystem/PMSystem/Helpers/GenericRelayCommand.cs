using System.Windows.Input;

namespace PMSystem.Helpers
{
    public class GenericRelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute; // Use the generic type T for Execute

        private readonly Predicate<T> _canExecute; // Use the generic type T for CanExecute

        public event EventHandler CanExecuteChanged;

        // Constructor requiring execute action, can optionally take canExecute predicate

        public GenericRelayCommand(Action<T> execute, Predicate<T> canExecute = null)

        {

            _execute = execute ?? throw new ArgumentNullException(nameof(execute));

            _canExecute = canExecute; // Assign the canExecute predicate

        }

        // Determines if the command can execute

        public bool CanExecute(object parameter)

        {

            // Cast parameter to T and call the predicate

            return _canExecute == null || _canExecute((T)parameter);

        }

        // Executes the command action

        public void Execute(object parameter)

        {

            // Cast the parameter to type T and invoke the execute action

            _execute((T)parameter);

        }

        // Raises the CanExecuteChanged event to notify UI of state change

        public void RaiseCanExecuteChanged()

        {

            CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        }
    }
}
