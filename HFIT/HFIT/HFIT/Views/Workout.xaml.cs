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
    public partial class Workout : ContentPage
    {

        public UsersModel UserLogado { get; set; }
        public Workout(UsersModel user)
        {
            InitializeComponent();
             UserLogado = user; 

        }

        private void OpenDetails(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WorkoutDetails());
        }

        private void BtnDone(object sender, EventArgs e)
        {

        }

       

        protected override void OnAppearing()
        {
            base.OnAppearing();

            UsersModel user = UserLogado;



            //if (string.IsNullOrEmpty(user.CompanyDescription))
            //{
            //    if (responseservice.isSucess)
            //    {

            //        _listOfJob = new ObservableCollection<Domain.Model.Job>(responseservice.Data);
            //        _listOfJobFirstreq = _listOfJob.Count;
            //        // carrega a colectio view 
            //        ListofJob.ItemsSource = _listOfJob;

            //        ListofJob.RemainingItemsThreshold = 1;

            //        txtResultaCount.Text = $"{ responseservice.Pagination.TotalItems} resultado(s).";
            //    }
            //    else
            //    {

            //        await DisplayAlert("Erro!", "Erro inesperado", "OK");

            //    }



            //}

            //if (string.IsNullOrEmpty(job.JobDescription))
            //{
            //    HeaderJobDescription.IsVisible = false;
            //    TextJobDescription.IsVisible = false;


            //}
        }

            private void CheckedChangedAction(object sender, CheckedChangedEventArgs e)
        {

        }

        private void BtnViews(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WorkoutDetails());
        }


        private void Logout(object sender, EventArgs e)
        {
            App.Current.Properties.Remove("MyToken");
            App.Current.SavePropertiesAsync();

            Navigation.PushAsync(new Login());

        }
    }
}