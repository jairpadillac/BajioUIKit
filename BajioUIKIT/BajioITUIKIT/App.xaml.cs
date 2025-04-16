using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BajioITUIKIT
{
    public partial class App : Application
    {
        public App()
        {
            object value = null;
            var themeRes = new Styles.Theme();
            foreach (var key in themeRes.Keys)
            {
                if (Current.Resources.ContainsKey(key))
                {
                    Current.Resources.Remove(key);
                }

                if (themeRes.TryGetValue(key, out value))
                {
                    Current.Resources.Add(key, value);
                }
            }

            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
