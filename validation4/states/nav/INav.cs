using System;
using System.Collections.Generic;
using System.Text;
using validation4.viewmodels;

namespace validation4.states.nav
{
    public interface INav
    {
        BaseVM CurrentVM { get; set; }
        BaseVM CurrentVMDialog { get; set; }

       
    }
}
