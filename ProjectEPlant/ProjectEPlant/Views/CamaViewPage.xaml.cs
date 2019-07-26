using ProjectEPlant.ViewsModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectEPlant.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CamaViewPage : ContentPage
    {

        CamaViewModel _vm;

        public CamaViewPage()
        {
            InitializeComponent();
            _vm = new CamaViewModel(Navigation);
            BindingContext = _vm;
        }

        private void Btn_eliminar_Clicked(object sender, EventArgs e)
        {

        }

        private async void Btn_agregar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AgregarCamaPage());
        }

        private void Btn_modificar_Clicked(object sender, EventArgs e)
        {

        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPlantPage());
        }

        protected override void OnAppearing()
        {
            _vm.GetListCamasCommand.Execute(null);
            base.OnAppearing();
        }
    }
}
