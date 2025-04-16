using Android.App;
using Android.Widget;
using BajioITUIKIT.DependencyServices;
using BajioITUIKIT.Droid.DependencyServices;

[assembly: Xamarin.Forms.Dependency(typeof(ToastMessage))]
namespace BajioITUIKIT.Droid.DependencyServices
{
    public class ToastMessage : IToastMessage
    {
        public void LongAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Long).Show();
        }

        public void ShortAlert(string message)
        {
            Toast.MakeText(Application.Context, message, ToastLength.Short).Show();
        }
    }
}
