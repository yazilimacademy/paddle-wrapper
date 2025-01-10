using Microsoft.Extensions.Logging;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Common;
using PaddleWrapper.Models.Prices;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PaddleWrapper.Services
{
    /// <summary>
    /// Service for managing prices in the Paddle system
    /// </summary>
    public class PriceService : IPriceService
    {
        private readonly IPaddleClient _client;
        private readonly ILogger<PriceService> _logger;
        private const string BasePath = "/prices";

        /// <summary>
        /// Creates a new instance of PriceService
        /// </summary>
        public PriceService(IPaddleClient client, ILogger<PriceService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<List<Price>>> ListPricesAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Retrieving list of prices");
            return await _client.GetAsync<PaddleResponse<List<Price>>>(BasePath, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<List<Price>>> ListProductPricesAsync(string productId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(productId))
            {
                throw new ArgumentException("Product ID must be provided", nameof(productId));
            }

            _logger.LogInformation("Retrieving prices for product with ID: {ProductId}", productId);
            return await _client.GetAsync<PaddleResponse<List<Price>>>($"{BasePath}?product_id={productId}", cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Price>> GetPriceAsync(string priceId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(priceId))
            {
                throw new ArgumentException("Price ID must be provided", nameof(priceId));
            }

            _logger.LogInformation("Retrieving price with ID: {PriceId}", priceId);
            return await _client.GetAsync<PaddleResponse<Price>>($"{BasePath}/{priceId}", cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Price>> CreatePriceAsync(Price price, CancellationToken cancellationToken = default)
        {
            if (price == null)
            {
                throw new ArgumentNullException(nameof(price));
            }

            _logger.LogInformation("Creating new price for product: {ProductId}", price.ProductId);
            return await _client.PostAsync<Price, PaddleResponse<Price>>(BasePath, price, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Price>> UpdatePriceAsync(string priceId, Price price, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(priceId))
            {
                throw new ArgumentException("Price ID must be provided", nameof(priceId));
            }

            if (price == null)
            {
                throw new ArgumentNullException(nameof(price));
            }

            _logger.LogInformation("Updating price with ID: {PriceId}", priceId);
            return await _client.PatchAsync<Price, PaddleResponse<Price>>($"{BasePath}/{priceId}", price, cancellationToken);
        }
    }
}