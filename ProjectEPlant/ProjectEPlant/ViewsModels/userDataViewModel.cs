using ProjectEPlant.Helpers;
using ProjectEPlant.Models;
using ProjectEPlant.ViewsModels.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProjectEPlant.ViewsModels
{
    public class userDataViewModel : BaseViewModel
    {

        public userDataViewModel(INavigation navigation) : base(navigation)
        {

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

        public async void saveUserData(string name, string email)
        {
            var model = new UserDataModel()
            {
                Name = name,
                Email = email
            };

            await WebApi.saveUserData(model);
        }

    }
}
