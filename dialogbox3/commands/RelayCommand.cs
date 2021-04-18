using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace dialogbox3.commands
{
    public class RelayCommand : ICommand
    {
        Action<object> _method_to_execute;
        Func<object, bool> _if_can_execute;

        public RelayCommand(Action<object> method_to_execute, Func<object, bool> if_can_execute = null)
        {
            _method_to_execute = method_to_execute;
            _if_can_execute = if_can_execute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _if_can_execute == null ? true : _if_can_execute(parameter);
        }

        public void Execute(object parameter)
        {
            _method_to_execute(parameter);
        }


    }
}
