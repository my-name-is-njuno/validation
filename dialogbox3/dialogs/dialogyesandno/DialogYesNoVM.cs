using dialogbox3.commands;
using dialogbox3.dialogs.dialogservice;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Input;

namespace dialogbox3.dialogs.dialogyesandno
{
    public class DialogYesNoVM : DialogViewModelBase
    {
        public ICommand YesCommand { get; set; }
        public ICommand NoCommand { get; set; }

        public DialogYesNoVM()
        {
            YesCommand = new RelayCommand(YesMethod);
            NoCommand = new RelayCommand(NoMethod);
        }

        private void YesMethod(object parameter)
        {
            this.CloseDialogWithResults(parameter as Window, DialogResult.Yes);
        }

        private void NoMethod(object parameter)
        {
            this.CloseDialogWithResults(parameter as Window, DialogResult.No);
        }
    }
}
