using BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Classes
{
    public class Auth : IAuth
    {
        public bool ChangePassword(string userName, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUserPassword(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
