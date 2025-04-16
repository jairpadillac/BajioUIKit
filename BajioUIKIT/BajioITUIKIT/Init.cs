using System;
using Xamarin.Forms;

namespace BajioITUIKIT
{
    public class BajioITUIKITPCL
    {
        #region Public Properties
        /// <summary>
        /// The app.
        /// </summary>
        public static Application App;
        #endregion

        #region Public Methods
        public static void Init(Application app)
        {
            if (app == null)
            {
                throw new NotImplementedException("Bajio UIKIT must be initialized with an App instance");
            }
            if (app.Resources == null)
            {
                throw new NotImplementedException("Your App on PCL project must have at least one resource dictionary, please declare it on your App.xaml file");
            }

            App = app;

            //object value = null;
            //var themeRes = new Styles.Theme();
            //foreach (var key in themeRes.Keys)
            //{
            //    if (App.Resources.ContainsKey(key))
            //    {
            //        app.Resources.Remove(key);
            //    }

            //    if (themeRes.TryGetValue(key, out value))
            //    {
            //        App.Resources.Add(key, value);
            //    }
            //}
        }
        #endregion
    }
}
