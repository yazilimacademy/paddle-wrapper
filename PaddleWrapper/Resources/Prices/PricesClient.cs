using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Resources.Prices.Operations;
using PaddleWrapper.Resources.Prices.Operations.List;

namespace PaddleWrapper.Resources.Prices
{
    public class PricesClient
    {
        private readonly Client _client;

        public PricesClient(Client client)
        {
            _client = client;
        }

        public async Task<PriceCollection> ListAsync(ListPrices listOperation = null)
        {
            listOperation ??= new ListPrices();
            var response = await _client.GetRawAsync("/prices", listOperation);
            ResponseParser parser = new(response);

            return PriceCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(PriceCollection))
            );
        }

        public async Task<Price> GetAsync(string id, IEnumerable<Includes> includes = null)
        {
            includes ??= Array.Empty<Includes>();
            List<Includes> includesList = includes.ToList();

            if (includesList.Any(include => include == null))
            {
                throw new ArgumentException("includes cannot contain null values", nameof(includes));
            }

            Dictionary<string, object> parameters = new();
            if (includesList.Any())
            {
                parameters["include"] = string.Join(",", includesList.Select(x => x.ToString()));
            }

            HttpResponseMessage response = await _client.GetRawAsync($"/prices/{id}", parameters);
            ResponseParser parser = new(response);

            return Price.From(parser.GetData());
        }

        public async Task<Price> CreateAsync(CreatePrice createOperation)
        {
            var response = await _client.PostRawAsync("/prices", createOperation);
            ResponseParser parser = new(response);

            return Price.From(parser.GetData());
        }

        public async Task<Price> UpdateAsync(string id, UpdatePrice operation)
        {
            var response = await _client.PatchRawAsync($"/prices/{id}", operation);
            ResponseParser parser = new(response);

            return Price.From(parser.GetData());
        }

        public async Task<Price> ArchiveAsync(string id)
        {
            return await UpdateAsync(id, new UpdatePrice { Status = Status.Archived });
        }
    }
}