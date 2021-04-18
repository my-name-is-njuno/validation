using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using validation.viewmodels;

namespace validation.commands
{
    public class CreateCommand : ICommand
    {
        private readonly ProductViewModel _productViewModel;

        public CreateCommand(ProductViewModel productViewModel)
        {
            _productViewModel = productViewModel;
        }

        public event EventHandler CanExecuteChanged;


        public bool CanExecute(object parameter)
        {
            throw new NotImplementedException();
        }

        public void Execute(object parameter)
        {
            throw new NotImplementedException();
        }
    }
}
