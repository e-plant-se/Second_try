using ProjectEPlant.Helpers;
using ProjectEPlant.Models.Interface;
using ProjectEPlant.ViewsModels;
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

        userDataViewModel _vm;
        LoginViewModel _vm2;
        public UserRegistrationPage()
        {
            InitializeComponent();

            _vm = new userDataViewModel(Navigation);
            _vm2 = new LoginViewModel(Navigation);
            BindingContext = _vm;

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
            else if ((password_Entry.Text).Length < 8)
            {
                await DisplayAlert(Login.MessageAlert, "¡La contraseña debe tener más de 8 caracteres!", Login.AcceptMessageAlert);
                return false;
            }
            return true;
        }

        void saveRegisterUserData()
        {
            _vm.saveUserData(userName_Entry.Text, email_Entry.Text);
        }

        public async void register_btn_Clicked(object sender, EventArgs e)
        {
            if (await Validations())
            {
                var response = await _vm.PostSignUp(email_Entry.Text, password_Entry.Text);

                if (response)
                {
                    var message = "Registrado Correctamente...";
                    DependencyService.Get<IMessage>().ShortAlert(message);
                    saveRegisterUserData();
                    var signIn = await _vm2.GetSignIn(email_Entry.Text, password_Entry.Text);
                    if (signIn)
                    {
                        //This is just a flag, but will be deleted
                        var OkMessage = "Logueado Correctamente...";
                        DependencyService.Get<IMessage>().ShortAlert(OkMessage);

                        //Next Page
                        Navigation.InsertPageBefore(new RegisterPlantPage(), this);
                        await Navigation.PopAsync();
                    }
                    else
                    {
                        await DisplayAlert(Login.MessageAlert, "No se pudo iniciar sesión", Login.AcceptMessageAlert);
                    }
                }
                else
                {
                    await DisplayAlert(Login.MessageAlert, "No se pudo registrar", Login.AcceptMessageAlert);
                }
                
            }
            
        }
    }
}