using Plugin.Media;
using ProjectEPlant.ViewsModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectEPlant.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AgregarCamaPage : ContentPage
    {
        CamaViewModel _vm;

        string streamImage;

        public static Stream streamFile;

        public AgregarCamaPage()
        {
            InitializeComponent();
            _vm = new CamaViewModel(Navigation);
            image.IsVisible = false;
        }

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

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await _vm.PostCamaAsync(huerto.Text, idCama.Text, tipo.Text, estructura.Text, planta.Text, fechaCultivo.Text);
        }
    }
}