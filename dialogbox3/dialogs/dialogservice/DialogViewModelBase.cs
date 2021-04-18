using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace dialogbox3.dialogs.dialogservice
{
    public abstract class DialogViewModelBase
    {
        public DialogResult UserDialogResult { get; private set; }

        public void CloseDialogWithResults(Window win, DialogResult rs)
        {
            UserDialogResult = rs;
            if (win != null)
            {
                win.DialogResult = true;
            }
        }
    }
}
