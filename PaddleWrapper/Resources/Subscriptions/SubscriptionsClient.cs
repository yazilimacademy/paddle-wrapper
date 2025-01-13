using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Extensions;
using PaddleWrapper.Resources.Subscriptions.Operations;
using PaddleWrapper.Resources.Subscriptions.Operations.Get;
using System.Text.Json;

namespace PaddleWrapper.Resources.Subscriptions
{
    public class SubscriptionsClient
    {
        private readonly Client _client;

        public SubscriptionsClient(Client client)
        {
            _client = client;
        }

        public async Task<SubscriptionCollection> ListAsync(ListSubscriptions listOperation = null)
        {
            listOperation ??= new ListSubscriptions();
            HttpResponseMessage response = await _client.GetRawAsync("/subscriptions", listOperation);
            JsonElement jsonElement = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(SubscriptionCollection)
            );

            return SubscriptionCollection.FromJson(data, paginator);
        }

        public async Task<Subscription> GetAsync(string id, Includes[]? includes = null)
        {
            includes ??= Array.Empty<Includes>();
            var parameters = includes.Length == 0
                ? null
                : new { include = string.Join(",", includes.Select(x => x.ToString().ToLower())) };

            JsonDocument response = await _client.Get($"/subscriptions/{id}", parameters);
            return Subscription.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Subscription> UpdateAsync(string id, UpdateSubscription operation)
        {
            JsonDocument response = await _client.Patch($"/subscriptions/{id}", operation);
            return Subscription.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Subscription> PauseAsync(string id, PauseSubscription operation)
        {
            JsonDocument response = await _client.Post($"/subscriptions/{id}/pause", operation);
            return Subscription.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Subscription> ResumeAsync(string id, ResumeSubscription operation)
        {
            JsonDocument response = await _client.Post($"/subscriptions/{id}/resume", operation);
            return Subscription.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Subscription> CancelAsync(string id, CancelSubscription operation)
        {
            JsonDocument response = await _client.Post($"/subscriptions/{id}/cancel", operation);
            return Subscription.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Transaction> GetPaymentMethodChangeTransactionAsync(string id)
        {
            JsonDocument response = await _client.Get($"/subscriptions/{id}/update-payment-method-transaction");
            return Transaction.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Subscription> ActivateAsync(string id)
        {
            JsonDocument response = await _client.Post($"/subscriptions/{id}/activate");
            return Subscription.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Subscription> CreateOneTimeChargeAsync(string id, CreateOneTimeCharge operation)
        {
            JsonDocument response = await _client.Post($"/subscriptions/{id}/charge", operation);
            return Subscription.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<SubscriptionPreview> PreviewUpdateAsync(string id, PreviewUpdateSubscription operation)
        {
            JsonDocument response = await _client.Patch($"/subscriptions/{id}/preview", operation);
            return SubscriptionPreview.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<SubscriptionPreview> PreviewOneTimeChargeAsync(string id, PreviewOneTimeCharge operation)
        {
            JsonDocument response = await _client.Post($"/subscriptions/{id}/charge/preview", operation);
            return SubscriptionPreview.FromJson(response.RootElement.GetProperty("data"));
        }
    }
}