using System.Threading.Tasks;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Discount;

namespace PaddleWrapper.Core.Services.Discounts
{
    public class DiscountService : IDiscountService
    {
        private readonly PaddleHttpClient _httpClient;
        private const string BaseEndpoint = "discount";

        public DiscountService(PaddleHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaddleResponse<Discount>> GetDiscountAsync(string discountId)
        {
            return await _httpClient.GetAsync<PaddleResponse<Discount>>($"{BaseEndpoint}/{discountId}");
        }

        public async Task<PaddleResponse<Discount>> CreateDiscountAsync(Discount discount)
        {
            return await _httpClient.PostAsync<PaddleResponse<Discount>>(BaseEndpoint, discount);
        }

        public async Task<PaddleResponse<Discount>> UpdateDiscountAsync(string discountId, Discount discount)
        {
            return await _httpClient.PostAsync<PaddleResponse<Discount>>($"{BaseEndpoint}/{discountId}", discount);
        }

        public async Task<PaddleResponse<bool>> DeleteDiscountAsync(string discountId)
        {
            return await _httpClient.PostAsync<PaddleResponse<bool>>($"{BaseEndpoint}/{discountId}/delete", null);
        }

        public async Task<PaddleResponse<Discount[]>> ListDiscountsAsync()
        {
            return await _httpClient.GetAsync<PaddleResponse<Discount[]>>(BaseEndpoint);
        }

        public async Task<PaddleResponse<bool>> ValidateDiscountAsync(string code)
        {
            return await _httpClient.PostAsync<PaddleResponse<bool>>($"{BaseEndpoint}/validate", new { code });
        }
    }
} 