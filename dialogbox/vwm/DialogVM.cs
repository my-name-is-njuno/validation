using dialogbox.commands;
using dialogbox.dialogservices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace dialogbox.vwm
{
    public class DialogVM : IDialogRequestClose
    {
        public ICommand OkCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        public DialogVM()
        {
            OkCommand = new OkCommand(this);
            CancelCommand = new CancelCommand(this);
        }

        public void OkResponse()
        {

        }

        public void CancelResponse()
        {

        }

        public event EventHandler<DialogCloseRequestedEventArgs> CloseRequested;
    }
}
