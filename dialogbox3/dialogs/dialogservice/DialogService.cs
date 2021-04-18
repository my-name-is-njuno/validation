using System;
using System.Collections.Generic;
using System.Text;

namespace dialogbox3.dialogs.dialogservice
{
    public static class DialogService 
    {
        public static DialogResult OpenDialog(DialogViewModelBase dialogViewModelBase)
        {
            DialogWindow dialogWindow = new DialogWindow();
            dialogWindow.ShowDialog();
            return DialogResult.Undefined;
        }
    }
}
