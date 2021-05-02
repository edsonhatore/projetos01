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
    public partial class WorkoutDetails : ContentPage
    {
        public WorkoutDetails()
        {
            InitializeComponent();
        }
        private void GoBack(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}