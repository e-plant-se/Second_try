using ProjectEPlant.Controls;
using ProjectEPlant.Views;
using Xamarin.Forms;

namespace ProjectEPlant
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new BaseNavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
