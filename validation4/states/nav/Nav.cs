using System;
using System.Collections.Generic;
using System.Text;
using validation4.notifiers;
using validation4.viewmodels;

namespace validation4.states.nav
{
    public class Nav : ChangeNotifier, INav
    {
       
        private BaseVM baseVM;

        public BaseVM CurrentVM
        {
            get { return baseVM; }
            set { baseVM = value; OnPropertyChanged(); }
        }



        private BaseVM _currentVMDialog;

        public BaseVM CurrentVMDialog
        {
            get { return _currentVMDialog; }
            set { _currentVMDialog = value; OnPropertyChanged(); }
        }


    }
}
