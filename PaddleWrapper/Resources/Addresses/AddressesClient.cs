using System.Threading.Tasks;
using PaddleWrapper.Client;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Resources.Addresses.Operations;

namespace PaddleWrapper.Resources.Addresses
{
    public class AddressesClient
    {
        private readonly IPaddleClient _client;

        public AddressesClient(IPaddleClient client)
        {
            _client = client;
        }

        public async Task<AddressCollection> ListAsync(string customerId, ListAddresses listOperation = null)
        {
            listOperation ??= new ListAddresses();
            var response = await _client.GetRawAsync($"/customers/{customerId}/addresses", listOperation);
            var parser = new ResponseParser(response);

            return AddressCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(AddressCollection))
            );
        }

        public async Task<Address> GetAsync(string customerId, string id)
        {
            var response = await _client.GetRawAsync($"/customers/{customerId}/addresses/{id}");
            var parser = new ResponseParser(response);

            return Address.From(parser.GetData());
        }

        public async Task<Address> CreateAsync(string customerId, CreateAddress createOperation)
        {
            var response = await _client.PostRawAsync($"/customers/{customerId}/addresses", createOperation);
            var parser = new ResponseParser(response);

            return Address.From(parser.GetData());
        }

        public async Task<Address> UpdateAsync(string customerId, string id, UpdateAddress operation)
        {
            var response = await _client.PatchRawAsync($"/customers/{customerId}/addresses/{id}", operation);
            var parser = new ResponseParser(response);

            return Address.From(parser.GetData());
        }

        public async Task<Address> ArchiveAsync(string customerId, string id)
        {
            return await UpdateAsync(customerId, id, new UpdateAddress { Status = Status.Archived });
        }
    }
} 