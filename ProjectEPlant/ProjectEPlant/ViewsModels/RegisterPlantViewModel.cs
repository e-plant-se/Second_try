using ProjectEPlant.Models;
using ProjectEPlant.Services;
using ProjectEPlant.ViewsModels.Helpers;
using System.IO;
using Xamarin.Forms;

namespace ProjectEPlant.ViewsModels
{
    public class RegisterPlantViewModel : BaseViewModel
    {
        #region Properties and variables

        public string[] tipoCultivo = { "Plantula", "Por semilla", "Germinado" };
        public string[] tipoRiego = { "Abundante", "Moderado", "Poco" };
        public RegisterPlantModel modelo;

        #endregion

        public RegisterPlantViewModel(INavigation navigation) : base(navigation)
        {
            WebApi = new FirebaseConnection();
            modelo = new RegisterPlantModel();
        }

        #region Methods

        public async void WriteRegisterPlantAsync(Stream streamFile, string stream, string nombreComun, string nombreCientifico, string temporada, string tipoRiego, string tipoCultivo, string cicloVida, string uso, string tamaño)
        {
            var model = new RegisterPlantModel()
            {
                Imagen = stream,
                NombreComun = nombreComun,
                NombreCientifico = nombreCientifico,
                Temporada = temporada,
                TipoRiego = tipoRiego,
                TipoCultivo = tipoCultivo,
                Uso = uso,
                CicloVida = cicloVida,
                Tamaño = tamaño
            };
            await WebApi.saveImage(streamFile, stream);
            await WebApi.PostRegisterPlantAsync(model);
        }

        #endregion
    }
}
