using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Extensions;
using PaddleWrapper.Resources.Products.Operations;
using PaddleWrapper.Resources.Products.Operations.List;
using System.Text.Json;

namespace PaddleWrapper.Resources.Products
{
    public class ProductsClient
    {
        private readonly Client _client;

        public ProductsClient(Client client)
        {
            _client = client;
        }

        public async Task<ProductCollection> ListAsync(ListProducts listOperation = null)
        {
            listOperation ??= new ListProducts();
            HttpResponseMessage response = await _client.GetRawAsync("/products", listOperation);
            JsonElement jsonElement = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(ProductCollection)
            );

            return ProductCollection.FromJson(data, paginator);
        }

        public async Task<Product> GetAsync(string id, IEnumerable<Includes> includes = null)
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

            JsonDocument response = await _client.Get($"/products/{id}", parameters);
            return Product.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Product> CreateAsync(CreateProduct createOperation)
        {
            JsonDocument response = await _client.Post("/products", createOperation);
            return Product.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Product> UpdateAsync(string id, UpdateProduct operation)
        {
            JsonDocument response = await _client.Patch($"/products/{id}", operation);
            return Product.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Product> ArchiveAsync(string id)
        {
            return await UpdateAsync(id, new UpdateProduct { Status = Status.Archived });
        }
    }
}