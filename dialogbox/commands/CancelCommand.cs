using dialogbox.vwm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace dialogbox.commands
{
    public class CancelCommand : ICommand
    {
        private readonly DialogVM _dialogVM;

        public CancelCommand(DialogVM dialogVM)
        {
            _dialogVM = dialogVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _dialogVM.CancelResponse();
        }
    }
}
