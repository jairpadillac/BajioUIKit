using Android.Views.InputMethods;
using BajioITUIKIT.DependencyServices;
using BajioITUIKIT.Droid.DependencyServices;
using Plugin.CurrentActivity;

[assembly: Xamarin.Forms.Dependency(typeof(ForceKeyboardDismissalService))]
namespace BajioITUIKIT.Droid.DependencyServices
{
    public class ForceKeyboardDismissalService : IForceKeyboardDismissalService
    {
        public void DismissKeyboard()
        {
            InputMethodManager imm = InputMethodManager.FromContext(CrossCurrentActivity.Current.Activity.ApplicationContext);

            imm.HideSoftInputFromWindow(CrossCurrentActivity.Current.Activity.Window.DecorView.WindowToken, HideSoftInputFlags.NotAlways);
        }
    }
}
