using Newtonsoft.Json;
using System;

namespace Weather.Models
{
    [JsonArray("data")]
    public class JSONCity
    {
        [JsonProperty("id")]
        public String Id { get; set; }

        [JsonProperty("name")]
        public String NomeCidade { get; set; }
    }
}