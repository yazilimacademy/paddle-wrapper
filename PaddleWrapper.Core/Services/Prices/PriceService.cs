using System.Threading.Tasks;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Price;

namespace PaddleWrapper.Core.Services.Prices
{
    public class PriceService : IPriceService
    {
        private readonly PaddleHttpClient _httpClient;
        private const string BaseEndpoint = "price";

        public PriceService(PaddleHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaddleResponse<Price>> GetPriceAsync(string priceId)
        {
            return await _httpClient.GetAsync<PaddleResponse<Price>>($"{BaseEndpoint}/{priceId}");
        }

        public async Task<PaddleResponse<Price>> CreatePriceAsync(Price price)
        {
            return await _httpClient.PostAsync<PaddleResponse<Price>>(BaseEndpoint, price);
        }

        public async Task<PaddleResponse<Price>> UpdatePriceAsync(string priceId, Price price)
        {
            return await _httpClient.PostAsync<PaddleResponse<Price>>($"{BaseEndpoint}/{priceId}", price);
        }

        public async Task<PaddleResponse<Price[]>> ListPricesAsync()
        {
            return await _httpClient.GetAsync<PaddleResponse<Price[]>>(BaseEndpoint);
        }

        public async Task<PaddleResponse<Price[]>> GetProductPricesAsync(string productId)
        {
            return await _httpClient.GetAsync<PaddleResponse<Price[]>>($"{BaseEndpoint}/product/{productId}");
        }

        public async Task<PaddleResponse<bool>> ArchivePriceAsync(string priceId)
        {
            return await _httpClient.PostAsync<PaddleResponse<bool>>($"{BaseEndpoint}/{priceId}/archive", null);
        }

        public async Task<PaddleResponse<bool>> ActivatePriceAsync(string priceId)
        {
            return await _httpClient.PostAsync<PaddleResponse<bool>>($"{BaseEndpoint}/{priceId}/activate", null);
        }

        public async Task<PaddleResponse<Price>> AddRegionalPricingAsync(string priceId, string countryCode, decimal amount)
        {
            return await _httpClient.PostAsync<PaddleResponse<Price>>($"{BaseEndpoint}/{priceId}/regional", new { countryCode, amount });
        }
    }
} 