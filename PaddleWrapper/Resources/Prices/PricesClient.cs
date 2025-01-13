using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Extensions;
using PaddleWrapper.Resources.Prices.Operations;
using PaddleWrapper.Resources.Prices.Operations.List;
using System.Text.Json;

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
            HttpResponseMessage response = await _client.GetRawAsync("/prices", listOperation);
            JsonElement jsonElement = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(PriceCollection)
            );

            return PriceCollection.FromJson(data, paginator);
        }

        public async Task<Price> GetAsync(string id, IEnumerable<Includes> includes = null)
        {
            includes ??= Array.Empty<Includes>();
            List<Includes> includesList = includes.ToList();

            if (includesList.Any(include => include == null))
            {
                throw new ArgumentException("includes cannot contain null values", nameof(includes));
            }

            var parameters = includesList.Any()
                ? new { include = string.Join(",", includesList.Select(x => x.ToString())) }
                : null;

            JsonDocument response = await _client.Get($"/prices/{id}", parameters);
            return Price.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Price> CreateAsync(CreatePrice createOperation)
        {
            JsonDocument response = await _client.Post("/prices", createOperation);
            return Price.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Price> UpdateAsync(string id, UpdatePrice operation)
        {
            JsonDocument response = await _client.Patch($"/prices/{id}", operation);
            return Price.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Price> ArchiveAsync(string id)
        {
            return await UpdateAsync(id, new UpdatePrice { Status = Status.Archived });
        }
    }
}