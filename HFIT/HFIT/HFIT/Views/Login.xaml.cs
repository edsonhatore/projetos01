using HFIT.Utility.Load;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZAMIO.Model2;

namespace HFIT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Login : ContentPage
    {
        private Services.LoginService _service;
        public Login()
        {
            InitializeComponent();
            _service = new Services.LoginService();

        }

        private async void GoWorkout(object sender, EventArgs e)
        {
            UsersModel user;
            await Navigation.PushPopupAsync(new Loading());

            user = await _service.Login(txtEmail.Text, txtPassword.Text);

            await Navigation.PushPopupAsync(new Loading());

            App.Current.MainPage = new NavigationPage(new Workout());
        }

        private void GoRemenber(object sender, EventArgs e)
        {

        }
    }
}