using System;
using System.Windows.Input;

namespace Hospital.ViewModels
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<object> execute)
        {
            this.execute = execute;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            execute(parameter);
        }
    }
}
