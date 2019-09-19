using Weather.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CitiesList : ContentPage
    {
        public CitiesList()
        {
            InitializeComponent();
            BindingContext = new CitiesListViewModel();
        }
    }
}