using validation4.factory;
using validation4.states.nav;

namespace validation4.commands.nav
{
    public class NavCommand : BaseSyncCommand
    {
        private INav _nav;
        private IVmFactory _vmf;

        public NavCommand(INav nav, IVmFactory vmf)
        {
            _nav = nav;
            _vmf = vmf;
        }

        protected override void ExecuteSync(object parameter)
        {
            if (parameter is ViewType)
            {
                var vt = (ViewType)parameter;
                _nav.CurrentVM = _vmf.CreateViewModel(vt);
            }
        }
    }
}
