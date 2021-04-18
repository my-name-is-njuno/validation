using System;
using System.Collections.Generic;
using System.Text;
using validation4.states.nav;

namespace validation4.commands.nav
{
    public class RenavCommand : BaseSyncCommand
    {
        private IRenav _renav;

        public RenavCommand(IRenav renav)
        {
            _renav = renav;
        }

        protected override void ExecuteSync(object parameter)
        {
            _renav.Renavigate();
        }
    }
}
