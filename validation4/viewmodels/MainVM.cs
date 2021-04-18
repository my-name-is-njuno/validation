using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using validation4.commands.nav;
using validation4.factory;
using validation4.states.auth;
using validation4.states.nav;

namespace validation4.viewmodels
{
    public class MainVM : BaseVM
    {
        

        public INav Nav { get; set; }
        public ICommand NavCommand { get; set; }
        public IAuth AuthService { get; set; }

        public MainVM(INav nav, IVmFactory _vmf, IAuth _auth)
        {
            Nav = nav;
            AuthService = _auth;
            NavCommand = new NavCommand(nav, _vmf);
            NavCommand.Execute(ViewType.Login);
        }


        
    }
}
