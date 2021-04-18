using db.dbmodels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace db.services
{
    public interface ICrudUser : ICrud<User>
    {
        Task<User> GetByEmail(string email);
        Task<User> GetByUserName(string name);
    }
}
