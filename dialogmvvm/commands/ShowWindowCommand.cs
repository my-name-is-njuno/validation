using dialogmvvm.vm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace dialogmvvm.commands
{
    public class ShowWindowCommand : ICommand
    {
        private MainVM _mainVM;

        public ShowWindowCommand(MainVM mainVM)
        {
            _mainVM = mainVM;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _mainVM.DisplayDialog();
        }
    }
}
