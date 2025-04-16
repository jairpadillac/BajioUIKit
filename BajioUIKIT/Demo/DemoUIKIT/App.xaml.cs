using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DemoUIKIT
{
    public partial class App : Application
    {
        public App()
        {
            BajioITUIKIT.BajioITUIKITPCL.Init(this);
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
