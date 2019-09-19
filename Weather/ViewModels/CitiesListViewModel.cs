using System.Collections.ObjectModel;
using Weather.Models;
using Weather.Utils;
using Weather.Views;
using Xamarin.Forms;

namespace Weather.ViewModels
{
    public class CitiesListViewModel : ViewModelBase
    {
        private JSONCity selectedCity;
        public JSONCity SelectedCity
        {
            get { return selectedCity; }
            set
            {
                SetProperty(ref selectedCity, value);
                SelectedItemCommand.Execute(SelectedCity);
            }
        }

        private ObservableCollection<JSONCity> onlineCities;
        public ObservableCollection<JSONCity> OnlineCities
        {
            get { return onlineCities; }
            set { SetProperty(ref onlineCities, value); }
        }

        public Command SelectedItemCommand { get; private set; }

        public CitiesListViewModel()
        {
            SelectedItemCommand = new Command<JSONCity>(SelectedItemCommandTapped);
            ExecuteFunction(() => LoadCityList());
        }

        public void LoadCityList()
        {
            JSONUtil.LoadJSON();
            var cityList = JSONUtil.ParseJSON<ObservableCollection<JSONCity>>(JSONUtil.Json);
            OnlineCities = cityList;
        }

        public async void SelectedItemCommandTapped(JSONCity city)
        {
            await NavigationUtil.PushAsync(new WeatherInformation(city));
        }
    }
}