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
            var respostaUser = new Message<List<UsersModel>>();
            


            //      await Navigation.PushPopupAsync(new Loading());

            respostaUser = await _service.Login(txtEmail.Text, txtPassword.Text);

            //    await Navigation.PushPopupAsync(new Loading());


            if (respostaUser.IsSuccess)
            {
                var eventArgs = (EventArgs)e;
                var page = new Workout();
             //   page.BindingContext = eventArgs.LoadFromXaml<e>;

              //  Navigation.PushAsync(page);
            }
            else
            {

                await DisplayAlert("Erro!", "Erro inesperado", "OK");
             
            }

            App.Current.MainPage = new NavigationPage(new Workout());
        }

     

        private void GoRemenber(object sender, EventArgs e)
        {

        }
    }
}