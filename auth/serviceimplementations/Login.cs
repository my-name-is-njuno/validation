using auth.services;
using db.dbmodels;
using db.services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace auth.serviceimplementations
{
    public class Login : ILogin
    {
        private ICrudUser _userCrud;
        private IPasswordHasher _hasher;

        public Login(ICrudUser userCrud, IPasswordHasher hasher)
        {
            _userCrud = userCrud;
            _hasher = hasher;
        }

        public async Task<User> LoginUser(string name, string password)
        {
            var user = await _userCrud.GetByEmail(name);
            if (user == null)
            {
                throw new Exception();
            }
            PasswordVerificationResult passwordVerificationResult = _hasher.VerifyHashedPassword(user.Password, password);
            if (passwordVerificationResult != PasswordVerificationResult.Success)
            {
                throw new Exception();
            }
            return user;
        }
    }
}
