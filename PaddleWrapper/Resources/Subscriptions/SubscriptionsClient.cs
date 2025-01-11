using System.Threading.Tasks;
using System.Linq;
using PaddleWrapper.Client;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Resources.Subscriptions.Operations;
using PaddleWrapper.Resources.Subscriptions.Operations.Get;

namespace PaddleWrapper.Resources.Subscriptions
{
    public class SubscriptionsClient
    {
        private readonly IPaddleClient _client;

        public SubscriptionsClient(IPaddleClient client)
        {
            _client = client;
        }

        public async Task<SubscriptionCollection> ListAsync(ListSubscriptions listOperation = null)
        {
            listOperation ??= new ListSubscriptions();
            var response = await _client.GetRawAsync("/subscriptions", listOperation);
            var parser = new ResponseParser(response);

            return SubscriptionCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(SubscriptionCollection))
            );
        }

        public async Task<Subscription> GetAsync(string id, Includes[]? includes = null)
        {
            var parameters = new Dictionary<string, string>();
            if (includes != null && includes.Any())
            {
                parameters.Add("include", string.Join(",", includes.Select(i => i.ToString().ToLower())));
            }

            var response = await _client.GetRawAsync($"/subscriptions/{id}", parameters);
            var parser = new ResponseParser(response);

            return Subscription.From(parser.GetData());
        }

        public async Task<Subscription> UpdateAsync(string id, UpdateSubscription operation)
        {
            var response = await _client.PatchRawAsync($"/subscriptions/{id}", operation);
            var parser = new ResponseParser(response);

            return Subscription.From(parser.GetData());
        }

        public async Task<Subscription> PauseAsync(string id, PauseSubscription operation)
        {
            var response = await _client.PostRawAsync($"/subscriptions/{id}/pause", operation);
            var parser = new ResponseParser(response);

            return Subscription.From(parser.GetData());
        }

        public async Task<Subscription> ResumeAsync(string id, ResumeSubscription operation)
        {
            var response = await _client.PostRawAsync($"/subscriptions/{id}/resume", operation);
            var parser = new ResponseParser(response);

            return Subscription.From(parser.GetData());
        }

        public async Task<Subscription> CancelAsync(string id, CancelSubscription operation)
        {
            var response = await _client.PostRawAsync($"/subscriptions/{id}/cancel", operation);
            var parser = new ResponseParser(response);

            return Subscription.From(parser.GetData());
        }

        public async Task<Transaction> GetPaymentMethodChangeTransactionAsync(string id)
        {
            var response = await _client.GetRawAsync($"/subscriptions/{id}/update-payment-method-transaction");
            var parser = new ResponseParser(response);

            return Transaction.From(parser.GetData());
        }

        public async Task<Subscription> ActivateAsync(string id)
        {
            var response = await _client.PostRawAsync($"/subscriptions/{id}/activate");
            var parser = new ResponseParser(response);

            return Subscription.From(parser.GetData());
        }

        public async Task<Subscription> CreateOneTimeChargeAsync(string id, CreateOneTimeCharge operation)
        {
            var response = await _client.PostRawAsync($"/subscriptions/{id}/charge", operation);
            var parser = new ResponseParser(response);

            return Subscription.From(parser.GetData());
        }

        public async Task<SubscriptionPreview> PreviewUpdateAsync(string id, PreviewUpdateSubscription operation)
        {
            var response = await _client.PatchRawAsync($"/subscriptions/{id}/preview", operation);
            var parser = new ResponseParser(response);

            return SubscriptionPreview.From(parser.GetData());
        }

        public async Task<SubscriptionPreview> PreviewOneTimeChargeAsync(string id, PreviewOneTimeCharge operation)
        {
            var response = await _client.PostRawAsync($"/subscriptions/{id}/charge/preview", operation);
            var parser = new ResponseParser(response);

            return SubscriptionPreview.From(parser.GetData());
        }
    }
} 