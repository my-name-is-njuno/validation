using dialogmvvm.commands;
using dialogmvvm.services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace dialogmvvm.vm
{
    public class MainVM
    {
        public ICommand ShowWindowCommand { get; set; }
        private readonly IDialogService dialogService;

        public MainVM(IDialogService dialogService)
        {
            ShowWindowCommand = new ShowWindowCommand(this);
            this.dialogService = dialogService;
        }


        public void DisplayDialog()
        {
            var vm = new DialogVM();
            bool? result = dialogService.ShowDialog(vm);

        }
    }
}
