using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace PaddleWrapper
{
    public class Client
    {
        private readonly string _apiKey;
        private readonly HttpClient _httpClient;
        private readonly Environment _environment;

        public Client(string apiKey, Environment environment = Environment.Production)
        {
            _apiKey = apiKey;
            _environment = environment;
            _httpClient = new HttpClient();
        }

        // API metodları buraya eklenecek
    }
} 