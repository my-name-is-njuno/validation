using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using validation4.factory;
using validation4.states.nav;
using validation4.viewmodels;

namespace validation4.commands.dialogs
{
    public class ShowProviderCommand : BaseSyncCommand
    {
        private readonly INav _nav;
        private readonly IVmFactory _vmf;

        public ShowProviderCommand(INav nav, IVmFactory vmf)
        {
            _nav = nav;
            _vmf = vmf;
        }

        protected override void ExecuteSync(object parameter)
        {
          
            if (parameter is ViewType)
            {
                var vt = (ViewType)parameter;
                _nav.CurrentVMDialog = _vmf.CreateViewModel(vt);
            }
           
        }
    }
}
