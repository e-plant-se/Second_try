using System;
using System.Threading.Tasks;
using Firebase;
using ProjectEPlant.Droid.Services;
using ProjectEPlant.Helpers;
using ProjectEPlant.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(FirebaseAuthServices_Droid))]
namespace ProjectEPlant.Droid.Services
{
    public class FirebaseAuthServices_Droid : IFirebaseAuthServices
    {
        FirebaseApp app = FirebaseApp.Instance;
        public static int REQ_AUTH = 9999;
        public static string KEY_AUTH = "auth";

        public FirebaseAuthServices_Droid()
        {

        }

        public string getAuthKey()
        {
            return KEY_AUTH;
        }

        public string GetUserId()
        {
            try
            {
                var user = Firebase.Auth.FirebaseAuth.GetInstance(app).CurrentUser;
                return user.Uid;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(GetUserId), ex);
                return null;
            }
        }

        public bool IsUserSigned()
        {
            try
            {
                var user = Firebase.Auth.FirebaseAuth.GetInstance(app).CurrentUser;
                var signedIn = user != null;
                return signedIn;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(IsUserSigned), ex);
                return false;
            }
        }

        public async Task Logout()
        {
            try
            {
                Firebase.Auth.FirebaseAuth.GetInstance(app).SignOut();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(Logout), ex);
            }
        }

        public async Task<bool> SignIn(string email, string password)
        {
            try
            {
                await Firebase.Auth.FirebaseAuth.GetInstance(app).SignInWithEmailAndPasswordAsync(email, password);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(SignIn), ex);
                return false;
            }
        }

        public async Task<bool> SignUp(string email, string password)
        {
            try
            {
                await Firebase.Auth.FirebaseAuth.GetInstance(app).CreateUserWithEmailAndPasswordAsync(email, password);
                return true;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(SignUp), ex);
                return false;
            }
        }
    }
}