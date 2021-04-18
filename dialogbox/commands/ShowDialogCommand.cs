using dialogbox.vwm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace dialogbox.commands
{
    public class ShowDialogCommand : ICommand
    {
        private readonly MainVM _mvm;

        public ShowDialogCommand(MainVM mvm)
        {
            _mvm = mvm;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _mvm.ShowDialog();
        }
    }
}
