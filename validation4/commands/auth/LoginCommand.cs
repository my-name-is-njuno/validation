using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using validation4.states.auth;
using validation4.states.nav;
using validation4.viewmodels;

namespace validation4.commands.auth
{
    public class LoginCommand : BaseAsyncCommand
    {
        private LoginVM _loginVM;
        private IAuth _auth;
        private IRenav renav;

        public LoginCommand(LoginVM loginVM, IAuth auth, IRenav renav)
        {
            _loginVM = loginVM;
            _auth = auth;
            this.renav = renav;
            _loginVM.PropertyChanged += _loginVM_PropertyChanged;
        }

        private void _loginVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_loginVM.CanLogin))
            {
                OnCanExcuteChanged();
            }
        }


        public override bool CanExecute(object parameter)
        {
            return _loginVM.CanLogin && base.CanExecute(parameter);
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            var results = await _auth.Login(_loginVM.Email, _loginVM.Password);
            if (!results)
            {
                _loginVM.Msg.Error = "Wrong Email / Password combination";
            }
            else
            {
                renav.Renavigate();
            }
            
        }
    }
}
