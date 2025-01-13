using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Extensions;
using PaddleWrapper.Resources.PaymentMethods.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.PaymentMethods
{
    public class PaymentMethodsClient
    {
        private readonly Client _client;

        public PaymentMethodsClient(Client client)
        {
            _client = client;
        }

        public async Task<PaymentMethodCollection> ListAsync(string customerId, ListPaymentMethods listOperation = null)
        {
            listOperation ??= new ListPaymentMethods();
            HttpResponseMessage response = await _client.GetRawAsync($"/customers/{customerId}/payment-methods", listOperation);
            JsonElement jsonElement = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(PaymentMethodCollection)
            );

            return PaymentMethodCollection.FromJson(data, paginator);
        }

        public async Task<PaymentMethod> GetAsync(string customerId, string id)
        {
            JsonDocument response = await _client.Get($"/customers/{customerId}/payment-methods/{id}");
            return PaymentMethod.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task DeleteAsync(string customerId, string id)
        {
            await _client.DeleteRawAsync($"/customers/{customerId}/payment-methods/{id}");
        }
    }
}