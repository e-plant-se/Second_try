using Android.Widget;
using ProjectEPlant.Droid;
using ProjectEPlant.Models.Interface;
using Xamarin.Forms;

[assembly: Dependency(typeof(Message_Droid))]
namespace ProjectEPlant.Droid
{
    public class Message_Droid : IMessage
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Android.App.Application.Context, message, ToastLength.Short).Show();
        }
    }
}