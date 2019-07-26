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

        public async Task saveUserData(UserDataModel model)
        {
            try
            {
                CurrentConnectivity = Connectivity.NetworkAccess;
                if (CurrentConnectivity == NetworkAccess.Internet)
                {
                    var modelo = model;
                    var registerUserUrl = _baseUrl + "UsersData/.json";
                    var stringContent = new StringContent(JsonConvert.SerializeObject(modelo), Encoding.UTF8, "application/json");
                    await Client.PostAsync(registerUserUrl, stringContent).ConfigureAwait(false);
                }
            }catch(Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(saveUserData), ex);
            }
        }

        public async Task<List<Item>> PostRegisterCama(Item model)
        {
            try
            {
                CurrentConnectivity = Connectivity.NetworkAccess;
                if (CurrentConnectivity == NetworkAccess.Internet)
                {
                    var modelo = model;
                    var registerCama = _baseUrl + "Camas.json";
                    var stringContent = new StringContent(JsonConvert.SerializeObject(modelo), Encoding.UTF8, "application/json");
                    await Client.PostAsync(registerCama, stringContent).ConfigureAwait(false);
                }
                return new List<Item>();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(PostRegisterCama), ex);
                return new List<Item>();
            }
        }

        public async Task<List<Item>> GetCamasAsync()
        {
            try
            {
                CurrentConnectivity = Connectivity.NetworkAccess;
                if (CurrentConnectivity == NetworkAccess.Internet)
                {
                    var getCamasUrl = _baseUrl + "Camas/-LkVWigeaRTChEtoWOJ2.json";
                    var json = await Client.GetStringAsync(getCamasUrl).ConfigureAwait(false);
                    var newList = await Task.Run(() => JsonConvert.DeserializeObject<Item>(json));
                    var NewList = new List<Item>();
                    NewList.Add(newList);
                    return new List<Item>(NewList);
                }
                return new List<Item>();
            }
            catch (Exception ex)
            {
                ExceptionHandler.LogAndSendException(this, nameof(GetCamasAsync), ex);
                return new List<Item>();
            }
        }

        #endregion

    }
}
