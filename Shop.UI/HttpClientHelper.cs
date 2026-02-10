using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.UI
{
    public class HttpClientHelper
    {
        HttpClient client;
        public HttpClientHelper()
        {
            client=new HttpClient();
            client.BaseAddress = new Uri(RouteConstants.BaseUrl);
        }

        public async Task<T> GetAsync<T>(string route)
        {
            var response = await client.GetAsync(route);
            string content = await response.Content.ReadAsStringAsync();
            var resilt = JsonConvert.DeserializeObject<T>(content);
            return resilt!;
        }
        public async Task<Tout> PostAsync<Tout, Tin>(string route, Tin data)
        {
            string json = JsonConvert.SerializeObject(data);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(route, stringContent);
            string content = await response.Content.ReadAsStringAsync();
            var resilt = JsonConvert.DeserializeObject<Tout>(content);
            return resilt!;
        }


    }
}
