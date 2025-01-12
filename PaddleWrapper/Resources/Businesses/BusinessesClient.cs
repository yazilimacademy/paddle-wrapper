using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Resources.Businesses.Operations;

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
            var response = await _client.GetRaw($"/customers/{customerId}/businesses", listOperation);
            ResponseParser parser = new(response);

            return BusinessCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(BusinessCollection))
            );
        }

        public async Task<Business> GetAsync(string customerId, string id)
        {
            HttpResponseMessage response = await _client.GetRaw($"/customers/{customerId}/businesses/{id}");
            ResponseParser parser = new(response);

            return Business.From(parser.GetData());
        }

        public async Task<Business> CreateAsync(string customerId, CreateBusiness createOperation)
        {
            var response = await _client.PostRaw($"/customers/{customerId}/businesses", createOperation);
            ResponseParser parser = new(response);

            return Business.From(parser.GetData());
        }

        public async Task<Business> UpdateAsync(string customerId, string id, UpdateBusiness operation)
        {
            var response = await _client.PatchRaw($"/customers/{customerId}/businesses/{id}", operation);
            ResponseParser parser = new(response);

            return Business.From(parser.GetData());
        }

        public async Task<Business> ArchiveAsync(string customerId, string id)
        {
            return await UpdateAsync(customerId, id, new UpdateBusiness { Status = Status.Archived });
        }
    }
}