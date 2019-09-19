using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Weather.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace Weather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FavoriteCites : ContentPage
    {
        public FavoriteCites()
        {
            InitializeComponent();
            BindingContext = new FavoriteCitesViewModel();
        }
    }
}