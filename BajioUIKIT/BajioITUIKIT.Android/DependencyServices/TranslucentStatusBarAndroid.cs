using Android.Annotation;
using Android.OS;
using Android.Views;
using BajioITUIKIT.DependencyServices;
using BajioITUIKIT.Droid.DependencyServices;
using BajioITUIKIT.Droid.Resources;
using Xamarin.Forms;

[assembly: Dependency(typeof(TranslucentStatusBarAndroid))]
namespace BajioITUIKIT.Droid.DependencyServices
{
    public class TranslucentStatusBarAndroid : ITranslucentStatusBar
    {
        #region Public Properties

        /// <summary>
        /// Gets or sets a value indicating whether this instance is translucent.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is translucent; otherwise, <c>false</c>.
        /// </value>
        public bool IsTranslucent
        {
            get
            {
                return _translucent;
            }
            set
            {
                _translucent = value;
            }
        }
        #endregion

        #region Private Properties

        /// <summary>
        /// The translucent
        /// </summary>
        private bool _translucent;

        #endregion

        #region Public Methods

        /// <summary>
        /// Translucents this instance.
        /// </summary>
        public void Translucent()
        {
            IsTranslucent = true;
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                setTranslucentStatus(true);
            }

            SystemBarTintManager tintManager = new SystemBarTintManager(BajioITUIKITDroid.MainActivity);
            tintManager.setStatusBarTintEnabled(true);

            tintManager.setStatusBarTintResource(Android.Graphics.Color.Transparent);
        }

        /// <summary>
        /// Normals this instance.
        /// </summary>
        public void Normal()
        {
            IsTranslucent = false;
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Kitkat)
            {
                setTranslucentStatus(false);
            }

            SystemBarTintManager tintManager = new SystemBarTintManager(BajioITUIKITDroid.MainActivity);
            tintManager.setStatusBarTintEnabled(false);
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Sets the translucent status.
        /// </summary>
        /// <param name="on">if set to <c>true</c> [on].</param>
        [TargetApi(Value = 19)]
        private void setTranslucentStatus(bool on)
        {
            Android.Views.Window win = BajioITUIKITDroid.MainActivity.Window;
            WindowManagerLayoutParams winParams = win.Attributes;
            WindowManagerFlags bits = WindowManagerFlags.TranslucentStatus;
            if (on)
            {
                winParams.Flags |= bits;
            }
            else
            {
                winParams.Flags &= ~bits;
            }
            win.Attributes = winParams;
        }

        #endregion
    }
}

