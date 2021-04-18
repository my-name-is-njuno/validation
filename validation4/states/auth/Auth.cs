using auth.enums;
using auth.services;
using db.dbmodels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using validation4.notifiers;

namespace validation4.states.auth
{
    public class Auth : ChangeNotifier, IAuth
    {


        private readonly ILogin _login;
        private readonly IRegister _register;

        public Auth(ILogin login, IRegister register)
        {
            _login = login;
            _register = register;
        }



        private User _currentUser;
        public User CurrentUser
        {
            get { return _currentUser; }
            set { _currentUser = value; OnPropertyChanged(); OnPropertyChanged("IsLoggedIn"); }
        }


        public bool IsLoggedIn => CurrentUser != null;

        public async Task<bool> Login(string email, string password)
        {
            try
            {
                var results = await _login.LoginUser(email, password);
                if (results != null)
                {
                    CurrentUser = results;
                    return true;
                }
            }
            catch (Exception)
            {}
            return false;
        }

        public void Logout()
        {
            CurrentUser = null;
        }

        public async Task<RegistrationResult> Register(string name, string email, string password, string confirm_password, Provider pr)
        {
            var results = await _register.RegisterUser(name, email, password, confirm_password, pr);
            return results;
        }
    }
}
