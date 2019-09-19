using System.Collections.ObjectModel;
using Weather.Models;
using Weather.Utils;
using Weather.Views;
using Xamarin.Forms;

namespace Weather.ViewModels
{
    public class FavoriteCitesViewModel : ViewModelBase
    {
        private HttpUtil<ObservableCollection<CityInformation>> Handler;

        private CityInformation selectedCity;
        public CityInformation SelectedCity
        {
            get { return selectedCity; }
            set { SetProperty(ref selectedCity, value); }
        }

        private ObservableCollection<CityInformation> offlineCities;
        public ObservableCollection<CityInformation> OfflineCities
        {
            get { return offlineCities; }
            set { SetProperty(ref offlineCities, value); }
        }

        public Command SearchCitiesCommand { get; private set; }

        public FavoriteCitesViewModel()
        {
            Handler = new HttpUtil<ObservableCollection<CityInformation>>();
            SearchCitiesCommand = new Command(SearchCitiesCommandTapped);

            ExecuteFunction(() => LoadOfflineCities());
        }

        private async void SearchCitiesCommandTapped()
        {
            await NavigationUtil.PushAsync(new CitiesList());
        }

        public void LoadOfflineCities()
        {
            OfflineCities = new ObservableCollection<CityInformation>(SQLiteUtil.GetInformation());
        }
    }
}