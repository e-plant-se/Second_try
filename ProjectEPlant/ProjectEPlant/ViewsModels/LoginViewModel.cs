using ProjectEPlant.Helpers;
using ProjectEPlant.Services;
using ProjectEPlant.ViewsModels.Helpers;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjectEPlant.ViewsModels
{
    public class LoginViewModel : BaseViewModel
    {

        bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                SetValue(ref _isBusy, value);
                OnPropertyChanged(nameof(GetSignIn));
            }
        }

        public LoginViewModel(INavigation navigation) : base(navigation)
        {
            FirebaseAuth = new FirebaseAuthService();
        }

        public async Task<bool> GetSignIn(string email, string password)
        {
            try
            {
                IsBusy = true;
                var response = await FirebaseAuth.SignIn(email, password);
                IsBusy = false;
                if(response == true)
                {
                    return response;
                }

                return false;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(GetSignIn), ex);
                return false;
            }
        }

        public async Task<bool> PostSignUp(string email, string password)
        {
            try
            {
                var response = await FirebaseAuth.SignUp(email, password);
                if (response == true)
                {
                    return response;
                }

                return false;
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(PostSignUp), ex);
                return false;
            }
        }
    }
}
