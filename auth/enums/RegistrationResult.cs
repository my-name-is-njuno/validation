using System;
using System.Collections.Generic;
using System.Text;

namespace auth.enums
{
    public enum RegistrationResult
    {
        EmailExist,
        PasswordDontMatch,
        Success,
        EmptyFields,
        InvalidEmail,
        DbError
    }
}
