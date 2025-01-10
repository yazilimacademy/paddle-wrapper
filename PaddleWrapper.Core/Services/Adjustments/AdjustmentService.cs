using System.Threading.Tasks;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Adjustment;

namespace PaddleWrapper.Core.Services.Adjustments
{
    public class AdjustmentService : IAdjustmentService
    {
        private readonly PaddleHttpClient _httpClient;
        private const string BaseEndpoint = "adjustment";

        public AdjustmentService(PaddleHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaddleResponse<Adjustment>> GetAdjustmentAsync(string adjustmentId)
        {
            return await _httpClient.GetAsync<PaddleResponse<Adjustment>>($"{BaseEndpoint}/{adjustmentId}");
        }

        public async Task<PaddleResponse<Adjustment>> CreateAdjustmentAsync(Adjustment adjustment)
        {
            return await _httpClient.PostAsync<PaddleResponse<Adjustment>>(BaseEndpoint, adjustment);
        }

        public async Task<PaddleResponse<Adjustment>> UpdateAdjustmentAsync(string adjustmentId, Adjustment adjustment)
        {
            return await _httpClient.PostAsync<PaddleResponse<Adjustment>>($"{BaseEndpoint}/{adjustmentId}", adjustment);
        }

        public async Task<PaddleResponse<Adjustment[]>> ListAdjustmentsAsync()
        {
            return await _httpClient.GetAsync<PaddleResponse<Adjustment[]>>(BaseEndpoint);
        }

        public async Task<PaddleResponse<Adjustment[]>> GetCustomerAdjustmentsAsync(string customerId)
        {
            return await _httpClient.GetAsync<PaddleResponse<Adjustment[]>>($"{BaseEndpoint}/customer/{customerId}");
        }

        public async Task<PaddleResponse<Adjustment[]>> GetSubscriptionAdjustmentsAsync(string subscriptionId)
        {
            return await _httpClient.GetAsync<PaddleResponse<Adjustment[]>>($"{BaseEndpoint}/subscription/{subscriptionId}");
        }

        public async Task<PaddleResponse<bool>> CancelAdjustmentAsync(string adjustmentId)
        {
            return await _httpClient.PostAsync<PaddleResponse<bool>>($"{BaseEndpoint}/{adjustmentId}/cancel", null);
        }

        public async Task<PaddleResponse<Adjustment>> ApproveAdjustmentAsync(string adjustmentId)
        {
            return await _httpClient.PostAsync<PaddleResponse<Adjustment>>($"{BaseEndpoint}/{adjustmentId}/approve", null);
        }
    }
} 