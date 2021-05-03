using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rg.Plugins.Popup.Pages;

namespace HFIT.Utility.Load
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Loading : PopupPage
    {
        public Loading()
        {
            InitializeComponent();
        }
    }
}