using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PaddleWrapper.Client;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Resources.Products.Operations;
using PaddleWrapper.Resources.Products.Operations.List;

namespace PaddleWrapper.Resources.Products
{
    public class ProductsClient
    {
        private readonly IPaddleClient _client;

        public ProductsClient(IPaddleClient client)
        {
            _client = client;
        }

        public async Task<ProductCollection> ListAsync(ListProducts listOperation = null)
        {
            listOperation ??= new ListProducts();
            var response = await _client.GetRawAsync("/products", listOperation);
            var parser = new ResponseParser(response);

            return ProductCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(ProductCollection))
            );
        }

        public async Task<Product> GetAsync(string id, IEnumerable<Includes> includes = null)
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

            var response = await _client.GetRawAsync($"/products/{id}", parameters);
            var parser = new ResponseParser(response);

            return Product.From(parser.GetData());
        }

        public async Task<Product> CreateAsync(CreateProduct createOperation)
        {
            var response = await _client.PostRawAsync("/products", createOperation);
            var parser = new ResponseParser(response);

            return Product.From(parser.GetData());
        }

        public async Task<Product> UpdateAsync(string id, UpdateProduct operation)
        {
            var response = await _client.PatchRawAsync($"/products/{id}", operation);
            var parser = new ResponseParser(response);

            return Product.From(parser.GetData());
        }

        public async Task<Product> ArchiveAsync(string id)
        {
            return await UpdateAsync(id, new UpdateProduct { Status = Status.Archived });
        }
    }
} 