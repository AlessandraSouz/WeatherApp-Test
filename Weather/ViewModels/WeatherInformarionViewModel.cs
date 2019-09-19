using System;
using Weather.Models;
using Weather.Utils;

namespace Weather.ViewModels
{
    public class WeatherInformartionViewModel : ViewModelBase
    {
        private HttpUtil<CityInformation> Handler { get; set; }

        public String NomeCidade { get; set; }
        public String Descricao { get; set; }
        public String Temperatura { get; set; }
        public String TempMin { get; set; }
        public String TempMax { get; set; }

        public WeatherInformartionViewModel(JSONCity city)
        {
            Handler = new HttpUtil<CityInformation>();
            ExecuteFunction(() => LoadCityInformation(city));
        }

        public async void LoadCityInformation(JSONCity city)
        {
            var cityInfo = await Handler.GetAsync(city.Id);

            NomeCidade = cityInfo.NomeCidade;
            Descricao = cityInfo.Clima.Descricao;
            Temperatura = cityInfo.Temperatura.Temperatura.ToString();
            TempMax = cityInfo.Temperatura.TempMax.ToString();
            TempMin = cityInfo.Temperatura.TempMin.ToString();
        }
    }
}