using Newtonsoft.Json;
using ProjectEPlant.Helpers;
using ProjectEPlant.Models;
using ProjectEPlant.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProjectEPlant.Services
{
    public class FirebaseConnection : IFirebaseConnection
    {

        #region Properties and variables

        const string _baseUrl = "https://eplant-947b2.firebaseio.com/";

        NetworkAccess CurrentConnectivity;

        readonly HttpClient Client;

        #endregion

        public FirebaseConnection()
        {
            Client = new HttpClient();
        }

        #region Methods

        public async Task<List<RegisterPlantPage>> PostRegisterPlantAsync(RegisterPlantModel model)
        {
            try
            {
                CurrentConnectivity = Connectivity.NetworkAccess;
                if (CurrentConnectivity == NetworkAccess.Internet)
                {
                    var modelo = model;
                    var registerPlantUrl = _baseUrl + "RegistroPlanta/.json";
                    var stringContent = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8, "application/json");
                    var response = await Client.PostAsync(registerPlantUrl, stringContent).ConfigureAwait(false);
                    return new List<RegisterPlantPage>();
                }
                return new List<RegisterPlantPage>();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(PostRegisterPlantAsync), ex);
                return new List<RegisterPlantPage>();
            }
        }

        public async Task saveImage(Stream imgStream, string nameImage)
        {
            try
            {
                var firebaseClient = DependencyService.Get<IFirebaseConnection>();

                if (firebaseClient != null)
                {
                    await firebaseClient.saveImage(imgStream, nameImage);
                }
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(saveImage), ex);
            }
        }

        #endregion

    }
}
