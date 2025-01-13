using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Resources.Products.Operations;
using PaddleWrapper.Resources.Products.Operations.List;

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
            var response = await _client.GetRawAsync("/products", listOperation);
            ResponseParser parser = new(response);

            return ProductCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(ProductCollection))
            );
        }

        public async Task<Product> GetAsync(string id, IEnumerable<Includes> includes = null)
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

            HttpResponseMessage response = await _client.GetRawAsync($"/products/{id}", parameters);
            ResponseParser parser = new(response);

            return Product.From(parser.GetData());
        }

        public async Task<Product> CreateAsync(CreateProduct createOperation)
        {
            var response = await _client.PostRawAsync("/products", createOperation);
            ResponseParser parser = new(response);

            return Product.From(parser.GetData());
        }

        public async Task<Product> UpdateAsync(string id, UpdateProduct operation)
        {
            var response = await _client.PatchRawAsync($"/products/{id}", operation);
            ResponseParser parser = new(response);

            return Product.From(parser.GetData());
        }

        public async Task<Product> ArchiveAsync(string id)
        {
            return await UpdateAsync(id, new UpdateProduct { Status = Status.Archived });
        }
    }
}