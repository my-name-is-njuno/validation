using pagination.pg;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using validation4.commands.dialogs;
using validation4.factory;
using validation4.services.services;
using validation4.states.nav;

namespace validation4.viewmodels
{
    public class HomeVM : BaseVM
    {
        
        public IGetHospitals ProviderServices { get; set; }
        public ICommand ShowProviderCommand { get; }

        private readonly IVmFactory _vmf;
        private readonly INav _nav;

        public HomeVM(IGetHospitals providerServices, IVmFactory vmf, INav nav)
        {
            ProviderServices = providerServices;
            _vmf = vmf;
            _nav = nav;
            ShowProviderCommand = new ShowProviderCommand(_nav, _vmf);
        }





    }
}
