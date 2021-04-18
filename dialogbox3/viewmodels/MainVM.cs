using dialogbox3.commands;
using dialogbox3.dialogs.dialogservice;
using dialogbox3.dialogs.dialogyesandno;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace dialogbox3.viewmodels
{
    public class MainVM
    {
        public ICommand OpenDialog { get; set; }

        public MainVM()
        {
            OpenDialog = new RelayCommand(OnOpenDialog);
        }

        private void OnOpenDialog(object parameter)
        {
            DialogViewModelBase dialogViewModelBase = new DialogYesNoVM();
            DialogResult result = DialogService.OpenDialog(dialogViewModelBase);
        }
    }
}
