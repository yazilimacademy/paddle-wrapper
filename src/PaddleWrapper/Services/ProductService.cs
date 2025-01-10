using Microsoft.Extensions.Logging;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Common;
using PaddleWrapper.Models.Products;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PaddleWrapper.Services
{
    /// <summary>
    /// Service for managing products in the Paddle system
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly IPaddleClient _client;
        private readonly ILogger<ProductService> _logger;
        private const string BasePath = "/products";

        /// <summary>
        /// Creates a new instance of ProductService
        /// </summary>
        public ProductService(IPaddleClient client, ILogger<ProductService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<List<Product>>> ListProductsAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Retrieving list of products");
            return await _client.GetAsync<PaddleResponse<List<Product>>>(BasePath, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Product>> GetProductAsync(string productId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(productId))
            {
                throw new ArgumentException("Product ID must be provided", nameof(productId));
            }

            _logger.LogInformation("Retrieving product with ID: {ProductId}", productId);
            return await _client.GetAsync<PaddleResponse<Product>>($"{BasePath}/{productId}", cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Product>> CreateProductAsync(Product product, CancellationToken cancellationToken = default)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _logger.LogInformation("Creating new product");
            return await _client.PostAsync<Product, PaddleResponse<Product>>(BasePath, product, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Product>> UpdateProductAsync(string productId, Product product, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(productId))
            {
                throw new ArgumentException("Product ID must be provided", nameof(productId));
            }

            if (product == null)
            {
                throw new ArgumentNullException(nameof(product));
            }

            _logger.LogInformation("Updating product with ID: {ProductId}", productId);
            return await _client.PatchAsync<Product, PaddleResponse<Product>>($"{BasePath}/{productId}", product, cancellationToken);
        }
    }
}