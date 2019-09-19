using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Models
{
    public class Weather
    {  
        [JsonProperty("description")]
        public String  Descricao { get; set; }
    }
}