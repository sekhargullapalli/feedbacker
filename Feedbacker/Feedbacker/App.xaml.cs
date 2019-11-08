using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;

namespace Feedbacker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            AppCenter.Start("android=APP_SECRET_KEY_HERE;",
                  typeof(Analytics), typeof(Crashes));
            Analytics.SetEnabledAsync(true);
            Crashes.SetEnabledAsync(true);
        }

        protected override void OnSleep()
        {            
        }

        protected override void OnResume()
        {            
        }
    }
}
