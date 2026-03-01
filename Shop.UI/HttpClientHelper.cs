using Newtonsoft.Json;
using System.Text;

namespace Shop.UI
{
    public class HttpClientHelper
    {
       private readonly HttpClient _client;
        public HttpClientHelper(HttpClient client)
        {
            _client = client;
        }

        public async Task<T> GetAsync<T>(string route)
        {
            var response = await _client.GetAsync(route);
            string content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(content);
            return result!;
        }
        public async Task<Tout> PostAsync<Tout, Tin>(string route, Tin data)
        {
            string json = JsonConvert.SerializeObject(data);
            StringContent stringContent = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync(route, stringContent);
            string content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<Tout>(content);
            return result!;
        }
        public async Task<bool> DeleteAsync(string route)
        {
            var response = await _client.DeleteAsync(route);
            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            return false;
        }


    }
}
