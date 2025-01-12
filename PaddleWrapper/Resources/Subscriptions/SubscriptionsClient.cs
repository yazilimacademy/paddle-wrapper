using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Resources.Subscriptions.Operations;
using PaddleWrapper.Resources.Subscriptions.Operations.Get;

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
            var response = await _client.GetRaw("/subscriptions", listOperation);
            ResponseParser parser = new(response);

            return SubscriptionCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(SubscriptionCollection))
            );
        }

        public async Task<Subscription> GetAsync(string id, Includes[]? includes = null)
        {
            Dictionary<string, string> parameters = new();
            if (includes != null && includes.Any())
            {
                parameters.Add("include", string.Join(",", includes.Select(i => i.ToString().ToLower())));
            }

            var response = await _client.GetRaw($"/subscriptions/{id}", parameters);
            ResponseParser parser = new(response);

            return Subscription.From(parser.GetData());
        }

        public async Task<Subscription> UpdateAsync(string id, UpdateSubscription operation)
        {
            var response = await _client.PatchRaw($"/subscriptions/{id}", operation);
            ResponseParser parser = new(response);

            return Subscription.From(parser.GetData());
        }

        public async Task<Subscription> PauseAsync(string id, PauseSubscription operation)
        {
            var response = await _client.PostRaw($"/subscriptions/{id}/pause", operation);
            ResponseParser parser = new(response);

            return Subscription.From(parser.GetData());
        }

        public async Task<Subscription> ResumeAsync(string id, ResumeSubscription operation)
        {
            var response = await _client.PostRaw($"/subscriptions/{id}/resume", operation);
            ResponseParser parser = new(response);

            return Subscription.From(parser.GetData());
        }

        public async Task<Subscription> CancelAsync(string id, CancelSubscription operation)
        {
            var response = await _client.PostRaw($"/subscriptions/{id}/cancel", operation);
            ResponseParser parser = new(response);

            return Subscription.From(parser.GetData());
        }

        public async Task<Transaction> GetPaymentMethodChangeTransactionAsync(string id)
        {
            HttpResponseMessage response = await _client.GetRaw($"/subscriptions/{id}/update-payment-method-transaction");
            ResponseParser parser = new(response);

            return Transaction.From(parser.GetData());
        }

        public async Task<Subscription> ActivateAsync(string id)
        {
            var response = await _client.PostRaw($"/subscriptions/{id}/activate");
            ResponseParser parser = new(response);

            return Subscription.From(parser.GetData());
        }

        public async Task<Subscription> CreateOneTimeChargeAsync(string id, CreateOneTimeCharge operation)
        {
            var response = await _client.PostRaw($"/subscriptions/{id}/charge", operation);
            ResponseParser parser = new(response);

            return Subscription.From(parser.GetData());
        }

        public async Task<SubscriptionPreview> PreviewUpdateAsync(string id, PreviewUpdateSubscription operation)
        {
            var response = await _client.PatchRaw($"/subscriptions/{id}/preview", operation);
            ResponseParser parser = new(response);

            return SubscriptionPreview.From(parser.GetData());
        }

        public async Task<SubscriptionPreview> PreviewOneTimeChargeAsync(string id, PreviewOneTimeCharge operation)
        {
            var response = await _client.PostRaw($"/subscriptions/{id}/charge/preview", operation);
            ResponseParser parser = new(response);

            return SubscriptionPreview.From(parser.GetData());
        }
    }
}