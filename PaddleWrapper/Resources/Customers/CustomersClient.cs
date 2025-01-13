using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Extensions;
using PaddleWrapper.Resources.Customers.Operations;
using System.Text.Json;

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
            HttpResponseMessage response = await _client.GetRawAsync("/customers", listOperation);
            JsonElement jsonElement = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(CustomerCollection)
            );

            return CustomerCollection.FromJson(data, paginator);
        }

        public async Task<Customer> GetAsync(string id)
        {
            JsonDocument response = await _client.Get($"/customers/{id}");
            return Customer.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Customer> CreateAsync(CreateCustomer createOperation)
        {
            JsonDocument response = await _client.Post("/customers", createOperation);
            return Customer.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Customer> UpdateAsync(string id, UpdateCustomer operation)
        {
            JsonDocument response = await _client.Patch($"/customers/{id}", operation);
            return Customer.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Customer> ArchiveAsync(string id)
        {
            return await UpdateAsync(id, new UpdateCustomer { Status = Status.Archived });
        }

        public async Task<CreditBalanceCollection> GetCreditBalancesAsync(string id, ListCreditBalances operation = null)
        {
            operation ??= new ListCreditBalances();
            JsonDocument response = await _client.Get($"/customers/{id}/credit-balances", operation);
            return CreditBalanceCollection.FromJson(response.RootElement.GetProperty("data"), null);
        }

        public async Task<CustomerAuthToken> GenerateAuthTokenAsync(string id)
        {
            JsonDocument response = await _client.Post($"/customers/{id}/auth-token", null);
            return CustomerAuthToken.FromJson(response.RootElement.GetProperty("data"));
        }
    }
}