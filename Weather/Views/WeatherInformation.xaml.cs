using Weather.Models;
using Weather.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherInformation : ContentPage
    {
        public WeatherInformation(JSONCity city)
        {
            InitializeComponent();
            BindingContext = new WeatherInformartionViewModel(city);
        }
    }
}