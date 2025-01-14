using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Resources.Subscriptions.Operations;
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
            try
            {
                listOperation ??= new ListSubscriptions();
                HttpResponseMessage response = await _client.GetRawAsync("/subscriptions", listOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement jsonElement = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw SubscriptionApiError.FromJson(jsonElement);
                }

                JsonElement data = jsonElement.GetProperty("data");
                JsonElement meta = jsonElement.GetProperty("meta");

                Paginator paginator = new(
                    _client.HttpClient,
                    Pagination.FromJson(meta),
                    typeof(SubscriptionCollection)
                );

                return SubscriptionCollection.FromJson(data, paginator);
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (SubscriptionApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Subscription> GetAsync(string id)
        {
            try
            {
                HttpResponseMessage response = await _client.GetRawAsync($"/subscriptions/{id}");
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw SubscriptionApiError.FromJson(root);
                }

                return Subscription.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (SubscriptionApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Subscription> UpdateAsync(string id, UpdateSubscription operation)
        {
            try
            {
                HttpResponseMessage response = await _client.PatchRawAsync($"/subscriptions/{id}", operation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw SubscriptionApiError.FromJson(root);
                }

                return Subscription.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (SubscriptionApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Subscription> PauseAsync(string id, PauseSubscription operation)
        {
            try
            {
                HttpResponseMessage response = await _client.PostRawAsync($"/subscriptions/{id}/pause", operation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw SubscriptionApiError.FromJson(root);
                }

                return Subscription.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (SubscriptionApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Subscription> ResumeAsync(string id, ResumeSubscription operation)
        {
            try
            {
                HttpResponseMessage response = await _client.PostRawAsync($"/subscriptions/{id}/resume", operation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw SubscriptionApiError.FromJson(root);
                }

                return Subscription.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (SubscriptionApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Subscription> CancelAsync(string id, CancelSubscription operation)
        {
            try
            {
                HttpResponseMessage response = await _client.PostRawAsync($"/subscriptions/{id}/cancel", operation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw SubscriptionApiError.FromJson(root);
                }

                return Subscription.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (SubscriptionApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<PaymentMethodTransaction> GetPaymentMethodChangeTransactionAsync(string id)
        {
            try
            {
                HttpResponseMessage response = await _client.GetRawAsync($"/subscriptions/{id}/payment-method-change-transaction");
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw SubscriptionApiError.FromJson(root);
                }

                return PaymentMethodTransaction.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (SubscriptionApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Subscription> ActivateAsync(string id)
        {
            try
            {
                HttpResponseMessage response = await _client.PostRawAsync($"/subscriptions/{id}/activate", null);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw SubscriptionApiError.FromJson(root);
                }

                return Subscription.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (SubscriptionApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Transaction> CreateOneTimeChargeAsync(string id, CreateSubscriptionCharge operation)
        {
            try
            {
                HttpResponseMessage response = await _client.PostRawAsync($"/subscriptions/{id}/charge", operation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw SubscriptionApiError.FromJson(root);
                }

                return Transaction.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (SubscriptionApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<SubscriptionPreview> PreviewUpdateAsync(string id, PreviewSubscriptionUpdate operation)
        {
            try
            {
                HttpResponseMessage response = await _client.PostRawAsync($"/subscriptions/{id}/preview", operation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw SubscriptionApiError.FromJson(root);
                }

                return SubscriptionPreview.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (SubscriptionApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<SubscriptionPreview> PreviewOneTimeChargeAsync(string id, PreviewSubscriptionCharge operation)
        {
            try
            {
                HttpResponseMessage response = await _client.PostRawAsync($"/subscriptions/{id}/charge/preview", operation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw SubscriptionApiError.FromJson(root);
                }

                return SubscriptionPreview.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (SubscriptionApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }
    }
}