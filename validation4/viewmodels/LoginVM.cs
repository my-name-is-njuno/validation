using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows.Input;
using validation4.commands.auth;
using validation4.commands.nav;
using validation4.states.auth;
using validation4.states.msg;
using validation4.states.nav;

namespace validation4.viewmodels
{
    public class LoginVM : BaseVM
    {
        public IAuth LoginService { get; set; }
        public IMsg Msg { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand ViewRegisterCommand { get; set; }

        public LoginVM(IAuth loginService, IMsg msg, IRenav renavHome, IRenav renavRegister)
        {
            LoginService = loginService;
            Msg = msg;
            LoginCommand = new LoginCommand(this, loginService, renavHome);
            ViewRegisterCommand = new RenavCommand(renavRegister);
            Email = "pmnjuno@gmail.com";
            Password = "password";
        }



        public bool CanLogin => !(string.IsNullOrEmpty(Email)) && !(string.IsNullOrEmpty(Password)) && !(ErrorNotifier.HasErrors) ;

        private string email;

        public string Email
        {
            get { return email; }
            set 
            {
                ErrorNotifier.ClearErrors(nameof(Email));
                var foo = new EmailAddressAttribute();
                if (!foo.IsValid(value))
                {
                    ErrorNotifier.AddError(nameof(Email), "Invalid Email");
                }
                email = value; 
                OnPropertyChanged(); 
                OnPropertyChanged("CanLogin"); 
            }
        }


        private string password;

        

        public string Password
        {
            get { return password; }
            set 
            {                
                password = value;
                OnPropertyChanged();
                OnPropertyChanged("CanLogin"); 
            }
        }


    }
}
