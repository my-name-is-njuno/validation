using dialogbox.commands;
using dialogbox.dialogs;
using dialogbox.dialogservices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace dialogbox.vwm
{
    public class MainVM
    {
        public ICommand ShowDialogCommand { get; set; }
        private readonly IDialogService dialogService;
        public MainVM(IDialogService dialogService)
        {
            ShowDialogCommand = new ShowDialogCommand(this);
            this.dialogService = dialogService;
        }


        public void ShowDialog()
        {
            var vm = new DialogVM();
            bool? result = dialogService.ShowDialog(vm);
            if (result.HasValue)
            {
                if (result.Value)
                {

                }
                else
                {

                }
            }
        }
    }
}
