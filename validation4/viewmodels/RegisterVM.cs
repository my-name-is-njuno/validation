using db.dbmodels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows.Input;
using validation4.commands.auth;
using validation4.commands.nav;
using validation4.services.services;
using validation4.states.auth;
using validation4.states.msg;
using validation4.states.nav;

namespace validation4.viewmodels
{
    public class RegisterVM : BaseVM
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); OnPropertyChanged(nameof(CanRegister)); }
        }

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
                OnPropertyChanged(nameof(CanRegister));  
            }
        }


        private string password;

        public string Password
        {
            get { return password; }
            set { password = value; OnPropertyChanged(); OnPropertyChanged(nameof(CanRegister)); }
        }


        private string confirm_password;

        public string ConfirmPassword
        {
            get { return confirm_password; }
            set { confirm_password = value; OnPropertyChanged(); OnPropertyChanged(nameof(CanRegister)); }
        }


        private Provider provider;

        

        public Provider Provider
        {
            get { return provider; }
            set { provider = value; OnPropertyChanged(); OnPropertyChanged(nameof(CanRegister)); }
        }


        



        public bool CanRegister => !(Provider == null) && !(string.IsNullOrEmpty(ConfirmPassword)) && !(string.IsNullOrEmpty(Name)) && !(string.IsNullOrEmpty(Email)) && !(string.IsNullOrEmpty(Password));




        public ICommand RegisterCommand { get; set; }
        public ICommand ViewLoginCommand { get; set; }
        public IMsg Msg { get; set; }
        public IAuth Auth { get; set; }
        public IGetHospitals GetProviderService { get; set; }


        public RegisterVM(IMsg msg, IAuth auth, IRenav renav, IGetHospitals getProviderService)
        {
            Msg = msg;
            Auth = auth;

            RegisterCommand = new RegisterCommand(this, auth, renav);
            ViewLoginCommand = new RenavCommand(renav);
            GetProviderService = getProviderService;
            
        }


        

    }
}
