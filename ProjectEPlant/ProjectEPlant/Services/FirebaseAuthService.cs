using ProjectEPlant.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjectEPlant.Services
{
    public class FirebaseAuthService : IFirebaseAuthServices
    {

        public FirebaseAuthService()
        {

        }

        public string getAuthKey()
        {
            var firebaseClient = DependencyService.Get<IFirebaseAuthServices>();

            if (firebaseClient != null)
            {
                var response = firebaseClient.getAuthKey();
                return response;
            }
            return string.Empty;
        }

        public string GetUserId()
        {
            try
            {
                var firebaseClient = DependencyService.Get<IFirebaseAuthServices>();

                if (firebaseClient != null)
                {
                    var response = firebaseClient.GetUserId();
                    if (response == null || !response.Any())
                    {
                        return string.Empty;
                    }
                    return response;
                }
                return string.Empty;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(GetUserId), ex);
                return string.Empty;
            }
        }

        public bool IsUserSigned()
        {
            try
            {
                var firebaseClient = DependencyService.Get<IFirebaseAuthServices>();

                if (firebaseClient != null)
                {
                    var response = firebaseClient.IsUserSigned();
                    if (response == true)
                    {
                        return response;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(IsUserSigned), ex);
                return false;
            }
        }

        public Task Logout()
        {
            try
            {
                var firebaseClient = DependencyService.Get<IFirebaseAuthServices>();

                if (firebaseClient != null)
                {
                    var response = firebaseClient.Logout();
                    return response;
                }
                return null;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(IsUserSigned), ex);
                return null;
            }
        }

        public async Task<bool> SignIn(string email, string password)
        {
            try
            {
                var firebaseClient = DependencyService.Get<IFirebaseAuthServices>();

                if (firebaseClient != null)
                {
                    var response = await firebaseClient.SignIn(email, password);
                    if (response == true)
                    {
                        return response;
                    }
                    return false;
                }
                return false;
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
                var firebaseClient = DependencyService.Get<IFirebaseAuthServices>();

                if (firebaseClient != null)
                {
                    var response = await firebaseClient.SignUp(email, password);
                    if (response == true)
                    {
                        return response;
                    }
                    return false;
                }
                return false;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(SignUp), ex);
                return false;
            }
        }
    }
}
