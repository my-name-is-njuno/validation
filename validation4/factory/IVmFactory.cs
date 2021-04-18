using System;
using System.Collections.Generic;
using System.Text;
using validation4.states.nav;
using validation4.viewmodels;

namespace validation4.factory
{
    public interface IVmFactory
    {
        BaseVM CreateViewModel(ViewType vt);
    }
}
