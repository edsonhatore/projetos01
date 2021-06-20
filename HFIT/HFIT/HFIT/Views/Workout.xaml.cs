using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public event PropertyChangedEventHandler PropertyChanged;

        private Services.WorkoutService _service;
        public UsersModel UserLogado { get; set; }

    

        public Workout(UsersModel user)
        {
            InitializeComponent();
            _service = new Services.WorkoutService();
        
            UserLogado = user;

            AtualizarDataCalendario();

            var idioma = System.Globalization.CultureInfo.CurrentCulture;


           DiaDaSemana.Text = PrimeiraLetraMaiuscula(idioma.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek)) + "-" + DateTime.Now.ToString();


        }

        private void OpenDetails(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WorkoutDetails());
        }


        private string PrimeiraLetraMaiuscula(string palavra)
        {
            return char.ToUpper(palavra[0]) + palavra.Substring(1);
        }

        private void BtnDone(object sender, EventArgs e)
        {

        }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            try
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


        private ObservableCollection<TreinoModel> _lista;
        public ObservableCollection<TreinoModel> Lista
        {

            get
            {
                return _lista;
            }
            set
            {
                _lista = value;
                NotifyPropertyChanged("Lista");
            }
        }


        private async void AtualizarDataCalendario()
        {

            ///pedndente chamar api 
            ///
            var treino = new List<TreinoModel>();
            var respostaTreino = new Message<List<TreinoModel>>();



            //      await Navigation.PushPopupAsync(new Loading());
            try
            {
                respostaTreino = await _service.GetWorkout(1, App.Current.Properties["MyToken"].ToString());

                
                for (var i = 0; i < respostaTreino.Data.Count; i++)
                {
                    treino.Add(respostaTreino.Data[i]);
                }

                Lista = new ObservableCollection<TreinoModel>(treino);

                txtWorkout.Text = Lista[0].TRENOME.ToString();

                CVListaDeTarefas.ItemsSource = Lista;

            }
            catch (Exception ex)
            {

                throw;

            }
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