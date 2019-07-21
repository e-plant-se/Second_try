using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEPlant.Services
{
    public interface IFirebaseAuthServices
    {
        string getAuthKey();
        bool IsUserSigned();
        Task<bool> SignUp(string email, string password);
        Task<bool> SignIn(string email, string password);
        Task Logout();
        string GetUserId();
    }
}
