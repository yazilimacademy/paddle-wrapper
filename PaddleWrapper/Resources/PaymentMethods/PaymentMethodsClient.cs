using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Resources.PaymentMethods.Operations;

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
            var response = await _client.GetRaw($"/customers/{customerId}/payment-methods", listOperation);
            ResponseParser parser = new(response);

            return PaymentMethodCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(PaymentMethodCollection))
            );
        }

        public async Task<PaymentMethod> GetAsync(string customerId, string id)
        {
            HttpResponseMessage response = await _client.GetRaw($"/customers/{customerId}/payment-methods/{id}");
            ResponseParser parser = new(response);

            return PaymentMethod.From(parser.GetData());
        }

        public async Task DeleteAsync(string customerId, string id)
        {
            HttpResponseMessage response = await _client.DeleteRawAsync($"/customers/{customerId}/payment-methods/{id}");
            _ = new ResponseParser(response);
        }
    }
}