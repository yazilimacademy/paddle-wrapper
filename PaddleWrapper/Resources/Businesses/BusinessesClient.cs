using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Extensions;
using PaddleWrapper.Resources.Businesses.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.Businesses
{
    public class BusinessesClient
    {
        private readonly Client _client;

        public BusinessesClient(Client client)
        {
            _client = client;
        }

        public async Task<BusinessCollection> ListAsync(string customerId, ListBusinesses listOperation = null)
        {
            listOperation ??= new ListBusinesses();
            HttpResponseMessage response = await _client.GetRawAsync($"/customers/{customerId}/businesses", listOperation);
            JsonElement jsonElement = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(BusinessCollection)
            );

            return BusinessCollection.FromJson(data, paginator);
        }

        public async Task<Business> GetAsync(string customerId, string id)
        {
            JsonDocument response = await _client.Get($"/customers/{customerId}/businesses/{id}");
            return Business.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Business> CreateAsync(string customerId, CreateBusiness createOperation)
        {
            JsonDocument response = await _client.Post($"/customers/{customerId}/businesses", createOperation);
            return Business.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Business> UpdateAsync(string customerId, string id, UpdateBusiness operation)
        {
            JsonDocument response = await _client.Patch($"/customers/{customerId}/businesses/{id}", operation);
            return Business.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Business> ArchiveAsync(string customerId, string id)
        {
            return await UpdateAsync(customerId, id, new UpdateBusiness { Status = Status.Archived });
        }
    }
}