using dialogbox.vwm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace dialogbox.commands
{
    public class OkCommand : ICommand
    {
        private readonly DialogVM _dialog;

        public OkCommand(DialogVM dialog)
        {
            _dialog = dialog;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _dialog.OkResponse();
        }
    }
}
