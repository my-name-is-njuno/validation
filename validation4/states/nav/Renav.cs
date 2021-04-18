using System;
using System.Collections.Generic;
using System.Text;
using validation4.viewmodels;

namespace validation4.states.nav
{
    public class Renav<T> : IRenav where T : BaseVM
    {
        private readonly CreateVM<T> _createVM;
        private readonly INav _nav;

        public Renav(CreateVM<T> createVM, INav nav)
        {
            _createVM = createVM;
            _nav = nav;
        }

        public void Renavigate()
        {
            _nav.CurrentVM = _createVM();
        }
    }
}
