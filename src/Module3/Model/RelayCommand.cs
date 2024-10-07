using System;
using System.Windows.Input;

namespace Module3.Model
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> executeWithParam;
        private readonly Func<object, bool> canExecute;

        // Конструктор для команд без параметров
        public RelayCommand(Action execute, Func<bool> canExecute = null)
            : this(execute != null ? (param => execute()) : null, canExecute != null ? (param => canExecute()) : null)
        {
        }

        // Конструктор для команд с параметрами
        public RelayCommand(Action<object> executeWithParam, Func<object, bool> canExecute = null)
        {
            this.executeWithParam = executeWithParam;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            executeWithParam?.Invoke(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
