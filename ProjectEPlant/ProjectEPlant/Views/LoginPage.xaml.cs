﻿using ProjectEPlant.Helpers;
using ProjectEPlant.Models;
using ProjectEPlant.Models.Interface;
using ProjectEPlant.ViewsModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectEPlant.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {

        LoginViewModel _vm;
        MasterPage mp;
        public LoginPage()
        {
            InitializeComponent();

            _vm = new LoginViewModel(Navigation);
            mp = new MasterPage();
            BindingContext = _vm;
            Title = Strings.appName;

            appName_lbl.Text = Strings.viewName;
            email_lbl.Text = Login.Email;
            password_lbl.Text = Login.password;
            rememberMe_lbl.Text = Login.rememberMe;
            logIn_btn.Text = Login.loginTitle;
            signIn_btn.Text = Login.signIn;
        }
        private async Task<bool> Validations()
        {
            if (email_Entry.Text == null)
            {
                await DisplayAlert(Login.MessageAlert, "Porfavor ingrese el email", Login.AcceptMessageAlert);
                return false;
            }else if (password_Entry.Text == null)
            {
                await DisplayAlert(Login.MessageAlert, "Porfavor ingresa la contraseña", Login.AcceptMessageAlert);
                return false;
            }
            return true;
        }

        private async void LogIn_btn_Clicked(object sender, EventArgs e)
        {
            if(await Validations())
            {
                var response = await _vm.GetSignIn(email_Entry.Text, password_Entry.Text);
                if(response == true)
                {
                    var message = "Logueado Correctamente...";
                    DependencyService.Get<IMessage>().ShortAlert(message);
                    Application.Current.MainPage = new MainMasterDetail();
                    //Navigation.InsertPageBefore(new MainMasterDetail(), this);
                    //await Navigation.PopAsync();
                }
                else
                {
                    await DisplayAlert(Login.MessageAlert, "No se pudo acceder, ingrese sus datos nuevamente...", Login.AcceptMessageAlert);
                }
            }
        }

        private async void SignUp_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new UserRegistrationPage());
        }
    }
}