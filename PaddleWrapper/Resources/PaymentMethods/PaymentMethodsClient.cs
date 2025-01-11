using System.Threading.Tasks;
using PaddleWrapper.Client;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Resources.PaymentMethods.Operations;

namespace PaddleWrapper.Resources.PaymentMethods
{
    public class PaymentMethodsClient
    {
        private readonly IPaddleClient _client;

        public PaymentMethodsClient(IPaddleClient client)
        {
            _client = client;
        }

        public async Task<PaymentMethodCollection> ListAsync(string customerId, ListPaymentMethods listOperation = null)
        {
            listOperation ??= new ListPaymentMethods();
            var response = await _client.GetRawAsync($"/customers/{customerId}/payment-methods", listOperation);
            var parser = new ResponseParser(response);

            return PaymentMethodCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(PaymentMethodCollection))
            );
        }

        public async Task<PaymentMethod> GetAsync(string customerId, string id)
        {
            var response = await _client.GetRawAsync($"/customers/{customerId}/payment-methods/{id}");
            var parser = new ResponseParser(response);

            return PaymentMethod.From(parser.GetData());
        }

        public async Task DeleteAsync(string customerId, string id)
        {
            var response = await _client.DeleteRawAsync($"/customers/{customerId}/payment-methods/{id}");
            _ = new ResponseParser(response);
        }
    }
} 