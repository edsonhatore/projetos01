using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HFIT.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Workout : ContentPage
    {
        public Workout()
        {
            InitializeComponent();
        }

        private void OpenDetails(object sender, EventArgs e)
        {
            Navigation.PushAsync(new WorkoutDetails());
        }

        private void BtnDone(object sender, EventArgs e)
        {

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