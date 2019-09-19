using Newtonsoft.Json;
using System;
using System.IO;

namespace Weather.Utils
{
    public class JSONUtil
    {
        public static String Json { get; set; }

        public static void LoadJSON()
        {
            StreamReader reader = new StreamReader("Resources/city.list.json");
            Json = reader.ReadToEnd();
        }

        public static T ParseJSON<T>(string json)
        {
            T obj = JsonConvert.DeserializeObject<T>(json);
            return obj;
        }
    }
}