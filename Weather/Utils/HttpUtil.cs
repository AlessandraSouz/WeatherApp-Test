using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Weather.Models;
using Newtonsoft.Json;

namespace Weather.Utils
{
    public class HttpUtil<T>
    {
        private const String RequestUrl = "http://api.openweathermap.org/data/2.5/weather?id={0}&appid=2bac87e0cb16557bff7d4ebcbaa89d2f&lang=pt&units=metric";
        private HttpClient Client { get; set; }

        public HttpUtil()
        {
            Client = new HttpClient()
            {
                Timeout = TimeSpan.FromSeconds(5.0)
            };
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<T> GetAsync(string id)
        {
            T returnObj = default(T);
            HttpResponseMessage Response = await Client.GetAsync(string.Format(RequestUrl, id));
            if (Response.IsSuccessStatusCode)
            {
                var responseMsg = await Response.Content.ReadAsStringAsync();
                var responseObj = JsonConvert.DeserializeObject<T>(responseMsg);
                returnObj = responseObj;
                return returnObj;
            }
            else
            {
                switch (Response.StatusCode)
                {
                    case System.Net.HttpStatusCode.BadRequest:
                        throw new Exception("A requisição está inválida");
                    case System.Net.HttpStatusCode.NotFound:
                        throw new Exception("Servidor não encontrado");
                    case System.Net.HttpStatusCode.InternalServerError:
                        throw new Exception("O servidor possui um erro interno");
                    default:
                        throw new Exception("Encontramos um erro!");
                }
            }
        }
    }
}