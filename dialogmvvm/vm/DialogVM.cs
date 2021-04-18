using dialogmvvm.commands;
using dialogmvvm.services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace dialogmvvm.vm
{
    public class DialogVM : IDialogRequestClose
    {
        public event EventHandler<DialogCloseRequestedArgs> CloseRequested;

        public DialogVM()
        {
            OkCommand = new DOkeyAndCancelCommand();
        }

        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }
    }
}
