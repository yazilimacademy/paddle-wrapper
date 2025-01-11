using System.Threading.Tasks;
using PaddleWrapper.Client;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Resources.Customers.Operations;

namespace PaddleWrapper.Resources.Customers
{
    public class CustomersClient
    {
        private readonly IPaddleClient _client;

        public CustomersClient(IPaddleClient client)
        {
            _client = client;
        }

        public async Task<CustomerCollection> ListAsync(ListCustomers listOperation = null)
        {
            listOperation ??= new ListCustomers();
            var response = await _client.GetRawAsync("/customers", listOperation);
            var parser = new ResponseParser(response);

            return CustomerCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(CustomerCollection))
            );
        }

        public async Task<Customer> GetAsync(string id)
        {
            var response = await _client.GetRawAsync($"/customers/{id}");
            var parser = new ResponseParser(response);

            return Customer.From(parser.GetData());
        }

        public async Task<Customer> CreateAsync(CreateCustomer createOperation)
        {
            var response = await _client.PostRawAsync("/customers", createOperation);
            var parser = new ResponseParser(response);

            return Customer.From(parser.GetData());
        }

        public async Task<Customer> UpdateAsync(string id, UpdateCustomer operation)
        {
            var response = await _client.PatchRawAsync($"/customers/{id}", operation);
            var parser = new ResponseParser(response);

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
            var parser = new ResponseParser(response);

            return CreditBalanceCollection.From(parser.GetData());
        }

        public async Task<CustomerAuthToken> GenerateAuthTokenAsync(string id)
        {
            var response = await _client.PostRawAsync($"/customers/{id}/auth-token", null);
            var parser = new ResponseParser(response);

            return CustomerAuthToken.From(parser.GetData());
        }
    }
} 