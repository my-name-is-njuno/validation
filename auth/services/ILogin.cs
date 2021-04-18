using db.dbmodels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace auth.services
{
    public interface ILogin
    {
        Task<User> LoginUser(string name, string password);
    }
}
