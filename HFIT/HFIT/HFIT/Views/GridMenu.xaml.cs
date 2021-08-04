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
    public partial class GridMenu : ContentPage
    {
        public UsersModel UserLogado { get; set; }
        private Services.WorkoutService _service;

        private List<TreinoModel> productArrayList;

        public GridMenu(UsersModel user)
        {
            InitializeComponent();

            _service = new Services.WorkoutService();

            UserLogado = user;
            CarregarGrid();
          }

        private async void CarregarGrid()
        {

            //productArrayList = new List<TreinoModel>();
            //productArrayList.Add(new TreinoModel());
            //productArrayList.Add(new TreinoModel());
            //productArrayList.Add(new TreinoModel());
            //productArrayList.Add(new TreinoModel());
            //productArrayList.Add(new TreinoModel());

            //productArrayList.Add(new TreinoModel { TRENOME = "Espresso" });
            //productArrayList.Add(new TreinoModel { TRENOME = "Latte" });
            //productArrayList.Add(new TreinoModel { TRENOME = "Americano" });
            //productArrayList.Add(new TreinoModel { TRENOME = "Arabica" });

            //gridListaTreino.RowDefinitions.Add(new RowDefinition());
            //gridListaTreino.RowDefinitions.Add(new RowDefinition());
            //gridListaTreino.ColumnDefinitions.Add(new ColumnDefinition());
            //gridListaTreino.ColumnDefinitions.Add(new ColumnDefinition());
            //gridListaTreino.ColumnDefinitions.Add(new ColumnDefinition());

          //  var treino = new List<TreinoModel>();
            var respostaTreino = new Message<List<TreinoModel>>();
         //   try
           // { // TreinoSelecionado

                respostaTreino = await _service.GetWorkout(UserLogado.Cpocodigo, UserLogado.Id, App.Current.Properties["MyToken"].ToString());

                if (respostaTreino.IsSuccess == true)
                {

                var TreinoDistint = respostaTreino.Data.Select(e => new { e.MSTCODIGO , e.TRECODIGO , e.TRENOME}).Distinct().ToList();

                //for (var i = 0; i < respostaTreino.Data.Count; i++)
                //{
                //    treino.Add(respostaTreino.Data[i]);
                //}

                foreach (var item in TreinoDistint)
                {

                    if(item.TRECODIGO==2)
                         btnTreinoA.Text = item.TRENOME;
                    if (item.TRECODIGO == 3)
                        btnTreinoB.Text = item.TRENOME;
                    if (item.TRECODIGO == 4)
                        btnTreinoC.Text = item.TRENOME;
                    if (item.TRECODIGO == 5)
                        btnTreinoD.Text = item.TRENOME;
                    if (item.TRECODIGO == 6)
                        btnTreinoE.Text = item.TRENOME;
                    if( item.TRECODIGO == 7)
                       btnTreinoE.Text = item.TRENOME;
                    //if (item.TRENOME == "F")
                    //    btnTreinoF.Text = item.TRENOME;
                }
                // dinamico 

                //var workoutInedx = 0;
                //for (int rowIndex = 0; rowIndex < 2; rowIndex++)
                //{
                //    for (int columnIndex = 0; columnIndex < 3; columnIndex++)
                //    {
                //        if (workoutInedx >= treino.Count)
                //        {
                //            break;
                //        }
                //        var workout = treino[workoutInedx];
                //        workoutInedx += 1;
                //        var buton = new Button
                //        {
                //            Text = workout.TRENOME,
                //            VerticalOptions = LayoutOptions.Center,
                //            HorizontalOptions = LayoutOptions.Center,


                //        };
                //        gridListaTreino.Children.Add(buton, columnIndex, rowIndex);
                //    }
                //}
            }            
                else
                {

                    await DisplayAlert("Aviso!", respostaTreino.ReturnMessage, "OK");

                }
            
            }
        private void GoBack(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Login());
           // Navigation.PopAsync();
        }

       

        private void GoTreinoA(object sender, EventArgs e)
        {

            GoTreinoSelected(2);

            //    App.Current.MainPage = new NavigationPage(new Workout(user));????????????
        }

        private void Logout(object sender, EventArgs e)
        {
            App.Current.Properties.Remove("MyToken");
            App.Current.SavePropertiesAsync();

            Navigation.PushAsync(new Login());
          
        }

        private void GoTreinoB(object sender, EventArgs e)
        {
            GoTreinoSelected(3);

            //    App.Current.MainPage = new NavigationPage(new Workout(user));
        }

        private void GoTreinoC(object sender, EventArgs e)
        {

            GoTreinoSelected(4);
        }
                private void GoTreinoD(object sender, EventArgs e)
        {
            //TreinoModel treinoselect;
            //treinoselect = new TreinoModel();

            //treinoselect.TRECODIGO = 5;//treino 
            //Navigation.PushAsync(new Workout(UserLogado, treinoselect));

            GoTreinoSelected(5);
        }

        private void GoTreinoSelected(Int32 vTreino)
        {
            TreinoModel treinoselect;
            treinoselect = new TreinoModel();

            treinoselect.TRECODIGO = vTreino;

            Navigation.PushAsync(new Workout(UserLogado, treinoselect));

        }

        private void GoTreinoE(object sender, EventArgs e)
        {
            GoTreinoSelected(6);
        }
    }
}