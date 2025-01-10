using System.Threading.Tasks;
using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Event;

namespace PaddleWrapper.Core.Services.Events
{
    public class EventService : IEventService
    {
        private readonly PaddleHttpClient _httpClient;
        private const string BaseEndpoint = "event";

        public EventService(PaddleHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaddleResponse<Event>> GetEventAsync(string eventId)
        {
            return await _httpClient.GetAsync<PaddleResponse<Event>>($"{BaseEndpoint}/{eventId}");
        }

        public async Task<PaddleResponse<Event[]>> ListEventsAsync()
        {
            return await _httpClient.GetAsync<PaddleResponse<Event[]>>(BaseEndpoint);
        }

        public async Task<PaddleResponse<Event[]>> GetCustomerEventsAsync(string customerId)
        {
            return await _httpClient.GetAsync<PaddleResponse<Event[]>>($"{BaseEndpoint}/customer/{customerId}");
        }

        public async Task<PaddleResponse<Event[]>> GetSubscriptionEventsAsync(string subscriptionId)
        {
            return await _httpClient.GetAsync<PaddleResponse<Event[]>>($"{BaseEndpoint}/subscription/{subscriptionId}");
        }

        public async Task<PaddleResponse<Event[]>> GetTransactionEventsAsync(string transactionId)
        {
            return await _httpClient.GetAsync<PaddleResponse<Event[]>>($"{BaseEndpoint}/transaction/{transactionId}");
        }

        public async Task<PaddleResponse<bool>> RetryEventAsync(string eventId)
        {
            return await _httpClient.PostAsync<PaddleResponse<bool>>($"{BaseEndpoint}/{eventId}/retry", null);
        }

        public async Task<PaddleResponse<bool>> MarkEventAsync(string eventId, string status)
        {
            return await _httpClient.PostAsync<PaddleResponse<bool>>($"{BaseEndpoint}/{eventId}/mark", new { status });
        }

        public async Task<PaddleResponse<EventType[]>> GetEventTypesAsync()
        {
            return await _httpClient.GetAsync<PaddleResponse<EventType[]>>($"{BaseEndpoint}/types");
        }
    }
} 