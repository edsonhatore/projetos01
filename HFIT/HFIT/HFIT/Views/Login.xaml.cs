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
            UsersModel user = new UsersModel();
            var respostaUser = new Message<List<UsersModel>>();

            try
            {          

            //      await Navigation.PushPopupAsync(new Loading());

            respostaUser = await _service.Login(txtEmail.Text, txtPassword.Text);
            if (respostaUser.IsSuccess)
            {

                //    await Navigation.PushPopupAsync(new Loading());
                for (var i = 0; i < respostaUser.Data.Count; i++)
                {
                    user = respostaUser.Data[i];

                }


                if (respostaUser.IsSuccess)
                {
                    App.Current.MainPage = new NavigationPage(new Workout(user));
                }
                else
                {

                    await DisplayAlert("Erro!", "Erro inesperado.", "OK");

                }
            }
            else
            {
                await DisplayAlert("Erro!", "Erro inesperado: "+ respostaUser.ReturnMessage, "OK");

            }

            }
            catch (Exception)
            {

                throw;
            }
        }

     

        private void GoRemenber(object sender, EventArgs e)
        {

        }
    }
}