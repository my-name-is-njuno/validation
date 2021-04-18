using auth.enums;
using db.dbmodels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace validation4.states.auth
{
    public interface IAuth
    {
        User CurrentUser { get; set; }
        bool IsLoggedIn { get; }
        Task<bool> Login(string email, string password);
        Task<RegistrationResult> Register(string name, string email, string password, string confirm_password, Provider pr);
        void Logout();
    }
}
