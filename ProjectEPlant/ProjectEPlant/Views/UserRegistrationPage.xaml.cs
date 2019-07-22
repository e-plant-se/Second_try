using ProjectEPlant.Helpers;
using ProjectEPlant.Models.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectEPlant.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserRegistrationPage : ContentPage
    {
        public UserRegistrationPage()
        {
            InitializeComponent();

            Title = Strings.appName;

            urpName_lbl.Text = Strings.urpName;
            userName_lbl.Text = Registration.userName;
            email_lbl.Text = Registration.Email;           
            password_lbl.Text = Registration.password;
            rPassword_lbl.Text = Registration.password;
            register_btn.Text = Registration.registerUser;
        }

        private async Task<bool> Validations()
        {
            if (String.IsNullOrWhiteSpace(userName_Entry.Text))
            {
                await DisplayAlert(Login.MessageAlert, "Por favor ingrese su nombre", Login.AcceptMessageAlert);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(email_Entry.Text))
            {
                await DisplayAlert(Login.MessageAlert, "Por favor ingrese su email", Login.AcceptMessageAlert);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(password_Entry.Text))
            {
                await DisplayAlert(Login.MessageAlert, "Por favor ingrese su contraseña", Login.AcceptMessageAlert);
                return false;
            }
            else if (String.IsNullOrWhiteSpace(rPassword_Entry.Text))
            {
                await DisplayAlert(Login.MessageAlert, "Por favor repita su contraseña", Login.AcceptMessageAlert);
                return false;
            }
            else if (password_Entry.Text != rPassword_Entry.Text)
            {
                await DisplayAlert(Login.MessageAlert, "¡Las contraseñas deben ser iguales!", Login.AcceptMessageAlert);
                return false;
            }
            return true;
        }

        public async void register_btn_Clicked(object sender, EventArgs e)
        {
            if (await Validations())
            {
                var message = "Registrado Correctamente...";
                DependencyService.Get<IMessage>().ShortAlert(message);
            }
            
        }
    }
}