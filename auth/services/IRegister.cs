using auth.enums;
using db.dbmodels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace auth.services
{
    public interface IRegister
    {
        Task<RegistrationResult> RegisterUser(string name, string email, string password, string confirm_password, Provider pr);
    }
}
