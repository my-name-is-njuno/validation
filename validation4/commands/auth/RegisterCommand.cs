using auth.enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using validation4.states.auth;
using validation4.states.nav;
using validation4.viewmodels;

namespace validation4.commands.auth
{
    public class RegisterCommand : BaseAsyncCommand
    {
        private RegisterVM _registerVM;
        private readonly IAuth _auth;
        private IRenav _renav;

        public RegisterCommand(RegisterVM registerVM, IAuth auth, IRenav renav)
        {
            _registerVM = registerVM;
            _auth = auth;
            _renav = renav;
            _registerVM.PropertyChanged += _registerVM_PropertyChanged;
        }

        private void _registerVM_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(_registerVM.CanRegister))
            {
                OnCanExcuteChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return _registerVM.CanRegister && base.CanExecute(parameter);
        }

        protected override async Task ExecuteAsync(object parameter)
        {
            var results = await _auth.Register(_registerVM.Name, _registerVM.Email, _registerVM.Password, _registerVM.ConfirmPassword, _registerVM.Provider);

            if (results == RegistrationResult.DbError)
            {
                _registerVM.Msg.Error = "User not registered, try again";
            }
            if (results == RegistrationResult.EmailExist)
            {
                _registerVM.Msg.Error = "Email already exists";
            }
            if (results == RegistrationResult.EmptyFields)
            {
                _registerVM.Msg.Error = "Ensure all fields are filled";
            }
            if (results == RegistrationResult.InvalidEmail)
            {
                _registerVM.Msg.Error = "Email entered is Invalid";
            }
            if (results == RegistrationResult.PasswordDontMatch)
            {
                _registerVM.Msg.Error = "Password do not match";
            }
            if (results == RegistrationResult.Success)
            {
                _renav.Renavigate();
            }
        }
    }
}
