using ProjectEPlant.Controls;
using ProjectEPlant.Services;
using ProjectEPlant.Views;
using Xamarin.Forms;

namespace ProjectEPlant
{
    public partial class App : Application
    {

        FirebaseAuthService firebaseAuth;
        public App()
        {
            InitializeComponent();
            firebaseAuth = new FirebaseAuthService();
            //firebaseAuth.Logout();

            MainPage = new LoginPage();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            var resp = firebaseAuth.IsUserSigned();

            if (resp)
            {
                MainPage = new MainMasterDetail();
            }
            
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
