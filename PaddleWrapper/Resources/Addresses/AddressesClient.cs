using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Extensions;
using PaddleWrapper.Resources.Addresses.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.Addresses
{
    public class AddressesClient
    {
        private readonly Client _client;

        public AddressesClient(Client client)
        {
            _client = client;
        }

        public async Task<AddressCollection> ListAsync(string customerId, ListAddresses listOperation = null)
        {
            listOperation ??= new ListAddresses();
            HttpResponseMessage response = await _client.GetRawAsync($"/customers/{customerId}/addresses", listOperation);
            JsonElement jsonElement = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(AddressCollection)
            );

            return AddressCollection.FromJson(data, paginator);
        }

        public async Task<Address> GetAsync(string customerId, string id)
        {
            JsonDocument response = await _client.Get($"/customers/{customerId}/addresses/{id}");
            return Address.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Address> CreateAsync(string customerId, CreateAddress createOperation)
        {
            JsonDocument response = await _client.Post($"/customers/{customerId}/addresses", createOperation);
            return Address.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Address> UpdateAsync(string customerId, string id, UpdateAddress operation)
        {
            JsonDocument response = await _client.Patch($"/customers/{customerId}/addresses/{id}", operation);
            return Address.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Address> ArchiveAsync(string customerId, string id)
        {
            return await UpdateAsync(customerId, id, new UpdateAddress { Status = Status.Archived });
        }
    }
}