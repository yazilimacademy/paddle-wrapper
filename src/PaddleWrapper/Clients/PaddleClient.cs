using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace PaddleWrapper.Clients
{
    public class PaddleClient
    {
        private readonly HttpClient _httpClient;

        public PaddleClient(string apiKey)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://vendors.paddle.com/api/2.0/")
            };
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
        }

        public async Task<JsonElement> SendRequestAsync(string endpoint, object payload)
        {
            var json = JsonSerializer.Serialize(payload);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(endpoint, content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<JsonElement>(responseContent);
        }
    }
} 