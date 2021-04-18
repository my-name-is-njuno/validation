using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using validation4.commands.providers;
using validation4.services.services;
using validation4.states.msg;

namespace validation4.viewmodels
{
    public class ShowProviderVM : BaseVM
    {
        public ShowProviderVM(IGetHospitals providerServices, IUpdateProvider providerUpdate, IMsg messager)
        {
            ProviderServices = providerServices;
            ProviderUpdate = providerUpdate;
            UpdateProviderCommand = new UpdateProviderCommand(ProviderUpdate, this);
            Messager = messager;
        }

        public IGetHospitals ProviderServices { get; set; }
        public IUpdateProvider ProviderUpdate { get; set; }
        public IMsg Messager { get; set; }
        public ICommand UpdateProviderCommand { get; }



        public bool CanUpdate => true;


       

    }
}
