using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HFIT
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            if (App.Current.Properties.ContainsKey("MyToken"))
            {
                MainPage = new NavigationPage(new Views.Workout());

            }
            else
            {
                MainPage = new NavigationPage(new Views.Login());
            }
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
