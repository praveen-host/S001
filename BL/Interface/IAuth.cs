using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Interface
{
    interface IAuth
    {
        bool ValidateUserPassword(string userName,string password);
        bool ChangePassword(string userName, string oldPassword, string newPassword);

    }
}
