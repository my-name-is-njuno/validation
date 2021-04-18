using auth.enums;
using auth.services;
using db.dbmodels;
using db.services;
using Microsoft.AspNet.Identity;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace auth.serviceimplementations
{
    public class Register : IRegister
    {
        private readonly ICrudUser _crudUser;
        private IPasswordHasher _hasher;

        public Register(ICrudUser crudUser, IPasswordHasher hasher)
        {
            _crudUser = crudUser;
            _hasher = hasher;
        }

        public async Task<RegistrationResult> RegisterUser(string name, string email, string password, string confirm_password, Provider pr)
        {
            if (password != confirm_password)
            {
                return RegistrationResult.PasswordDontMatch;
            }

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirm_password) || pr == null )
            {
                return RegistrationResult.EmptyFields;
            }

            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (!match.Success)
            {
                return RegistrationResult.InvalidEmail;
            }

            var usr = await _crudUser.GetByEmail(email);
            if (usr != null)
            {
                return RegistrationResult.EmailExist;
            }

            var hashedPassword = _hasher.HashPassword(password);
            var newUser = new User
            {
                Name = name,
                Email = email,
                Password = hashedPassword,
                Provider = pr
            };

            if (_crudUser.Create(newUser) == null)
            {
                return RegistrationResult.DbError;
            }
            return RegistrationResult.Success;


        }
    }
}
