using Client.Services;
using System.Text;
using System.Text.Json;

namespace Client.Entities
{
    internal class HttpMethods : IHttpMethods
    {
        private HttpClient _httpClient;

        public HttpMethods(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAsync(string key)
        {
            string baseurl = "http://docker:8000/keys/$";
            string url = baseurl + key;
            var response = await _httpClient.GetAsync(url);
            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{jsonResponse}\n");
            return jsonResponse.ToString();
        }

        public async Task PutAsync(string key, string value)
        {
            using StringContent jsonContent = new(
            JsonSerializer.Serialize(new
            {
                tempKey = key,
                tempValue = value
            }),
            Encoding.UTF8,
            "application/json"); ;

            using HttpResponseMessage response = await _httpClient.PutAsync(
                $"http://localhost:8000/keys/${key}&value=${value}",
                jsonContent);

            var jsonResponse = await response.Content.ReadAsStringAsync();
            Console.WriteLine($"{jsonResponse}\n");
        }
    }
}
