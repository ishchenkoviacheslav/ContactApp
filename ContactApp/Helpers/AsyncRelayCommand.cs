using System;
using System.Windows.Input;

namespace ContactApp.Helpers
{
    public class AsyncRelayCommand : ICommand
    {
        private Func<object, Task> _execute;
        private Func<object, bool> _canExecute;

        private bool _isExecuting;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public AsyncRelayCommand(Func<object, Task> execute, Func<object, bool> canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public async void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                _isExecuting = true;
                try
                {
                    await _execute(parameter);
                }
                finally
                {
                    _isExecuting = false;
                }
            }
        }
    }
}
