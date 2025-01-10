using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Subscription;

namespace PaddleWrapper.Core.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly PaddleHttpClient _httpClient;
        private const string BaseEndpoint = "subscription";

        public SubscriptionService(PaddleHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaddleResponse<Subscription>> GetSubscriptionAsync(int subscriptionId)
        {
            return await _httpClient.GetAsync<PaddleResponse<Subscription>>($"{BaseEndpoint}/{subscriptionId}");
        }

        public async Task<PaddleResponse<Subscription[]>> ListUserSubscriptionsAsync(int userId)
        {
            return await _httpClient.GetAsync<PaddleResponse<Subscription[]>>($"{BaseEndpoint}/user/{userId}");
        }

        public async Task<PaddleResponse<Subscription>> UpdateSubscriptionAsync(int subscriptionId, Subscription subscription)
        {
            return await _httpClient.PostAsync<PaddleResponse<Subscription>>($"{BaseEndpoint}/{subscriptionId}", subscription);
        }

        public async Task<PaddleResponse<Subscription>> CancelSubscriptionAsync(int subscriptionId)
        {
            return await _httpClient.PostAsync<PaddleResponse<Subscription>>($"{BaseEndpoint}/{subscriptionId}/cancel", null);
        }

        public async Task<PaddleResponse<Subscription>> PauseSubscriptionAsync(int subscriptionId)
        {
            return await _httpClient.PostAsync<PaddleResponse<Subscription>>($"{BaseEndpoint}/{subscriptionId}/pause", null);
        }

        public async Task<PaddleResponse<Subscription>> ResumeSubscriptionAsync(int subscriptionId)
        {
            return await _httpClient.PostAsync<PaddleResponse<Subscription>>($"{BaseEndpoint}/{subscriptionId}/resume", null);
        }
    }
}