using System.Threading.Tasks;
using PaddleWrapper.Client;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Resources.Businesses.Operations;

namespace PaddleWrapper.Resources.Businesses
{
    public class BusinessesClient
    {
        private readonly IPaddleClient _client;

        public BusinessesClient(IPaddleClient client)
        {
            _client = client;
        }

        public async Task<BusinessCollection> ListAsync(string customerId, ListBusinesses listOperation = null)
        {
            listOperation ??= new ListBusinesses();
            var response = await _client.GetRawAsync($"/customers/{customerId}/businesses", listOperation);
            var parser = new ResponseParser(response);

            return BusinessCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(BusinessCollection))
            );
        }

        public async Task<Business> GetAsync(string customerId, string id)
        {
            var response = await _client.GetRawAsync($"/customers/{customerId}/businesses/{id}");
            var parser = new ResponseParser(response);

            return Business.From(parser.GetData());
        }

        public async Task<Business> CreateAsync(string customerId, CreateBusiness createOperation)
        {
            var response = await _client.PostRawAsync($"/customers/{customerId}/businesses", createOperation);
            var parser = new ResponseParser(response);

            return Business.From(parser.GetData());
        }

        public async Task<Business> UpdateAsync(string customerId, string id, UpdateBusiness operation)
        {
            var response = await _client.PatchRawAsync($"/customers/{customerId}/businesses/{id}", operation);
            var parser = new ResponseParser(response);

            return Business.From(parser.GetData());
        }

        public async Task<Business> ArchiveAsync(string customerId, string id)
        {
            return await UpdateAsync(customerId, id, new UpdateBusiness { Status = Status.Archived });
        }
    }
} 