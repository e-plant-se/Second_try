using ProjectEPlant.Controls;
using ProjectEPlant.Models;
using ProjectEPlant.Services;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProjectEPlant.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : ContentPage
    {
        public ListView ListView { get { return listView; } }
        FirebaseAuthService firebaseAuth;


        public MasterPage()
        {
            InitializeComponent();
            firebaseAuth = new FirebaseAuthService();
            var masterPageItem = new List<MasterItems>();
            masterPageItem.Add(new MasterItems
            {
                title = "Home page",
                icon = "Pene",
                tipeClass = typeof(RegisterPlantPage)
            });

            masterPageItem.Add(new MasterItems
            {
                title = "Register plant",
                icon = "noPene",
                tipeClass = typeof(RegisterPlantPage)
            });

            masterPageItem.Add(new MasterItems
            {
                title = "Register Bed",
                icon = "notPinusatAll",
                tipeClass = typeof(RegisterPlantPage)
            });

            listView.ItemsSource = masterPageItem;

            Content = new StackLayout
            {
                Children = { listView, btn }
            };
        }

        private async void Button_Clicked(object sender, System.EventArgs e)
        {
            await firebaseAuth.Logout();
            Application.Current.MainPage = new BaseNavigationPage(new LoginPage());

        }
    }
}