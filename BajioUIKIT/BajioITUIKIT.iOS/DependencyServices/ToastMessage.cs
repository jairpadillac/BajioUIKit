using BajioITUIKIT.DependencyServices;
using BajioITUIKIT.iOS.DependencyServices;
using Foundation;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(ToastMessage))]
namespace BajioITUIKIT.iOS.DependencyServices
{
    public class ToastMessage : IToastMessage
    {
        const double LONG_DELAY = 3.5;
        const double SHORT_DELAY = 0.75;

        public void LongAlert(string message)
        {
            ShowAlert(message, LONG_DELAY);
        }

        public void ShortAlert(string message)
        {
            ShowAlert(message, SHORT_DELAY);
        }

        void ShowAlert(string message, double seconds)
        {
            var alert = UIAlertController.Create(null, message, UIAlertControllerStyle.Alert);

            var alertDelay = NSTimer.CreateScheduledTimer(seconds, obj =>
            {
                DismissMessage(alert, obj);
            });

            UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert, true, null);
        }

        void DismissMessage(UIAlertController alert, NSTimer alertDelay)
        {
            if (alert != null)
            {
                alert.DismissViewController(true, null);
            }

            if (alertDelay != null)
            {
                alertDelay.Dispose();
            }
        }
    }
}
