using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Resources.Customers.Operations;

namespace PaddleWrapper.Resources.Customers
{
    public class CustomersClient
    {
        private readonly Client _client;

        public CustomersClient(Client client)
        {
            _client = client;
        }

        public async Task<CustomerCollection> ListAsync(ListCustomers listOperation = null)
        {
            listOperation ??= new ListCustomers();
            var response = await _client.GetRawAsync("/customers", listOperation);
            ResponseParser parser = new(response);

            return CustomerCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(CustomerCollection))
            );
        }

        public async Task<Customer> GetAsync(string id)
        {
            HttpResponseMessage response = await _client.GetRawAsync($"/customers/{id}");
            ResponseParser parser = new(response);

            return Customer.From(parser.GetData());
        }

        public async Task<Customer> CreateAsync(CreateCustomer createOperation)
        {
            var response = await _client.PostRawAsync("/customers", createOperation);
            ResponseParser parser = new(response);

            return Customer.From(parser.GetData());
        }

        public async Task<Customer> UpdateAsync(string id, UpdateCustomer operation)
        {
            var response = await _client.PatchRawAsync($"/customers/{id}", operation);
            ResponseParser parser = new(response);

            return Customer.From(parser.GetData());
        }

        public async Task<Customer> ArchiveAsync(string id)
        {
            return await UpdateAsync(id, new UpdateCustomer { Status = Status.Archived });
        }

        public async Task<CreditBalanceCollection> GetCreditBalancesAsync(string id, ListCreditBalances operation = null)
        {
            operation ??= new ListCreditBalances();
            var response = await _client.GetRawAsync($"/customers/{id}/credit-balances", operation);
            ResponseParser parser = new(response);

            return CreditBalanceCollection.From(parser.GetData());
        }

        public async Task<CustomerAuthToken> GenerateAuthTokenAsync(string id)
        {
            var response = await _client.PostRawAsync($"/customers/{id}/auth-token", null);
            ResponseParser parser = new(response);

            return CustomerAuthToken.From(parser.GetData());
        }
    }
}