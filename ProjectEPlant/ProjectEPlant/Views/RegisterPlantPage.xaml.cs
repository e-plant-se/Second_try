using Plugin.Media;
using ProjectEPlant.Models.Interface;
using ProjectEPlant.ViewsModels;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectEPlant.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPlantPage : ContentPage
    {
        #region Variables

        RegisterPlantViewModel _vm;

        string streamImage;

        public static Stream streamFile;

        #endregion

        public RegisterPlantPage()
        {
            InitializeComponent();
            _vm = new RegisterPlantViewModel(Navigation);
            radioButtonCultivo.ItemsSource = _vm.tipoCultivo;
            radioButtonRiego.ItemsSource = _vm.tipoRiego;
            image.IsVisible = false;
        }

        #region Methods

        private async Task<bool> Validations()
        {
            if (string.IsNullOrEmpty(entryNombreComun.Text))
            {
                await DisplayAlert("Heey", "Por favor llena el campo nombre común", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(entryNombreCientifico.Text))
            {
                await DisplayAlert("Heey", "Por favor llena el campo nombre científico", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(entryTemporada.Text))
            {
                await DisplayAlert("Heey", "Por favor llena el campo temporada", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(radioButtonRiego.SelectedIndex.ToString()))
            {
                await DisplayAlert("Heey", "Por favor seleccione una opción de riego", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(radioButtonCultivo.SelectedIndex.ToString()))
            {
                await DisplayAlert("Heey", "Por favor seleccione una opción de cultivo", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(entryCicloVida.Text))
            {
                await DisplayAlert("Heey", "Por favor llena el campo ciclo de vida", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(editorUsos.Text))
            {
                await DisplayAlert("Heey", "Por favor llena el campo usos", "Ok");
                return false;
            }
            else if (string.IsNullOrEmpty(entryTamaño.Text))
            {
                await DisplayAlert("Heey", "Por favor llena el campo tamaño", "Ok");
                return false;
            }
            else if (streamImage == null)
            {
                await DisplayAlert("Hey", "Por favor agrega una imagen", "Ok");
                return false;
            }
            return true;
        }

        async void saveRegistroPlanta(object sender, System.EventArgs e)
        {
            if (await Validations())
            {
                _vm.WriteRegisterPlantAsync(streamFile, streamImage, entryNombreComun.Text, entryNombreCientifico.Text, entryTemporada.Text, radioButtonRiego.SelectedIndex.ToString(), radioButtonCultivo.SelectedIndex.ToString(), editorUsos.Text, entryCicloVida.Text, entryTamaño.Text);
                var message = "Datos Guardados";
                DependencyService.Get<IMessage>().LongAlert(message);
                entryNombreComun.Text = null;
                entryNombreCientifico.Text = null;
                entryTemporada.Text = null;
                editorUsos.Text = null;
                entryCicloVida.Text = null;
                entryTamaño.Text = null;
                streamImage = null;
                image.IsVisible = false;
            }
        }

        /*private async void TakePhoto(object sender, System.EventArgs e)
        {

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                await DisplayAlert("No Camera", ":( No camera available.", "OK");
                return;
            }

            var opciones_almacenamiento = new StoreCameraMediaOptions()
            {
                DefaultCamera = CameraDevice.Front,
                Directory = "Test",
                CompressionQuality = 75,
                CustomPhotoSize = 50,
                PhotoSize = PhotoSize.MaxWidthHeight,
                MaxWidthHeight = 2000,
                SaveToAlbum = true
            };

            var foto = await CrossMedia.Current.TakePhotoAsync(opciones_almacenamiento);

            if (opciones_almacenamiento == null)
                return;

            await DisplayAlert("File Location", foto.Path, "OK");

            image.Source = ImageSource.FromStream(() =>
            {
                image.IsVisible = true;
                var stream = foto.GetStream();
                foto.Dispose();
                return stream;
            });
        }*/

        private async void SelectPhoto(object sender, System.EventArgs e)
        {
            if (CrossMedia.Current.IsTakePhotoSupported)
            {
                var imagen = await CrossMedia.Current.PickPhotoAsync();
                var stream = imagen.GetStream();
                streamFile = stream;
                if (imagen != null)
                {
                    var guid = Guid.NewGuid();
                    image.IsVisible = true;
                    streamImage = guid.ToString();
                    image.Source = ImageSource.FromStream(imagen.GetStream);
                }
            }
        }

        #endregion
    }
}