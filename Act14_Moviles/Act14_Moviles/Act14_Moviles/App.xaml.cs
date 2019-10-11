using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Act14_Moviles.Services;
using Act14_Moviles.Views;

namespace Act14_Moviles
{
    public partial class App : Application
    {

        public App()
        {
            MainPage = new Main();
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
