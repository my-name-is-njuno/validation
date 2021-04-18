using System;
using System.Collections.Generic;
using System.Text;
using validation4.states.nav;

namespace validation4.viewmodels
{
    public class DialogVM : BaseVM
    {
        public DialogVM(INav navigatorOnDialog)
        {
            NavigatorOnDialog = navigatorOnDialog;
        }

        public INav NavigatorOnDialog { get; set; }
    }
}
