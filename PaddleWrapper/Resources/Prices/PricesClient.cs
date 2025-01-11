using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaddleWrapper.Client;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Resources.Prices.Operations;
using PaddleWrapper.Resources.Prices.Operations.List;

namespace PaddleWrapper.Resources.Prices
{
    public class PricesClient
    {
        private readonly IPaddleClient _client;

        public PricesClient(IPaddleClient client)
        {
            _client = client;
        }

        public async Task<PriceCollection> ListAsync(ListPrices listOperation = null)
        {
            listOperation ??= new ListPrices();
            var response = await _client.GetRawAsync("/prices", listOperation);
            var parser = new ResponseParser(response);

            return PriceCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(PriceCollection))
            );
        }

        public async Task<Price> GetAsync(string id, IEnumerable<Includes> includes = null)
        {
            includes ??= Array.Empty<Includes>();
            var includesList = includes.ToList();

            if (includesList.Any(include => include == null))
            {
                throw new ArgumentException("includes cannot contain null values", nameof(includes));
            }

            var parameters = new Dictionary<string, object>();
            if (includesList.Any())
            {
                parameters["include"] = string.Join(",", includesList.Select(x => x.ToString()));
            }

            var response = await _client.GetRawAsync($"/prices/{id}", parameters);
            var parser = new ResponseParser(response);

            return Price.From(parser.GetData());
        }

        public async Task<Price> CreateAsync(CreatePrice createOperation)
        {
            var response = await _client.PostRawAsync("/prices", createOperation);
            var parser = new ResponseParser(response);

            return Price.From(parser.GetData());
        }

        public async Task<Price> UpdateAsync(string id, UpdatePrice operation)
        {
            var response = await _client.PatchRawAsync($"/prices/{id}", operation);
            var parser = new ResponseParser(response);

            return Price.From(parser.GetData());
        }

        public async Task<Price> ArchiveAsync(string id)
        {
            return await UpdateAsync(id, new UpdatePrice { Status = Status.Archived });
        }
    }
} 