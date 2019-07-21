using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Plugin.CurrentActivity;
using Firebase;

namespace ProjectEPlant.Droid
{
    [Activity(Label = "ProjectEPlant", Icon = "@mipmap/iconeplant", Theme = "@style/MainTheme", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        public FirebaseApp app;
        const string _appId = "eplant-947b2";
        const string _apiKey = "AIzaSyCL4ORP4GSF-TFFUZ_Vf95XN_o3NdKdnks";
        const string _databaseUrl = "https://eplant-947b2.firebaseio.com/";
        const string _projectName = "eplant";
        const string _storage = "gs://eplant-947b2.appspot.com/";

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            CrossCurrentActivity.Current.Init(this, savedInstanceState);
            var options = new FirebaseOptions.Builder().SetApplicationId(_appId).SetApiKey(_apiKey).SetDatabaseUrl(_databaseUrl).SetStorageBucket(_storage).Build();
            if (app == null)
            {
                app = FirebaseApp.InitializeApp(this, options, _projectName);
            }
            LoadApplication(new App());
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            Plugin.Permissions.PermissionsImplementation.Current.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}