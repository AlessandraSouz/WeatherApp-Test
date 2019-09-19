
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Models
{
    public class CityInformation
    {
        [PrimaryKey]
        public int Id { get; set; }

        [JsonProperty("name")]
        public string NomeCidade { get; set; }

        [JsonProperty("weather")]
        public Weather Clima { get; set; }

        [JsonProperty("main")]
        public Temperature Temperatura { get; set; }
    }
}