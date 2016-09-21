using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TempCheckMobile.Views;
using Xamarin.Forms;

namespace TempCheckMobile
{
    public class App : Application
    {
        public static readonly string DeviceId = "TempCheck-1337";

        public App()
        {
            // The root page of your application
            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
