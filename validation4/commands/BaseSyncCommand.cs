
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace validation4.commands
{
    public abstract class BaseSyncCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ExecuteSync(parameter);
        }

        protected abstract void ExecuteSync(object parameter);
    }
}
