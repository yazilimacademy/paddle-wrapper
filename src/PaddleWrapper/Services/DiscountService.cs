using Microsoft.Extensions.Logging;
using PaddleWrapper.Interfaces;
using PaddleWrapper.Models.Common;
using PaddleWrapper.Models.Discounts;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PaddleWrapper.Services
{
    /// <summary>
    /// Service for managing discounts in the Paddle system
    /// </summary>
    public class DiscountService : IDiscountService
    {
        private readonly IPaddleClient _client;
        private readonly ILogger<DiscountService> _logger;
        private const string BasePath = "/discounts";

        /// <summary>
        /// Creates a new instance of DiscountService
        /// </summary>
        public DiscountService(IPaddleClient client, ILogger<DiscountService> logger)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<List<Discount>>> ListDiscountsAsync(CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Retrieving list of discounts");
            return await _client.GetAsync<PaddleResponse<List<Discount>>>(BasePath, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Discount>> GetDiscountAsync(string discountId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(discountId))
            {
                throw new ArgumentException("Discount ID must be provided", nameof(discountId));
            }

            _logger.LogInformation("Retrieving discount with ID: {DiscountId}", discountId);
            return await _client.GetAsync<PaddleResponse<Discount>>($"{BasePath}/{discountId}", cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Discount>> CreateDiscountAsync(Discount discount, CancellationToken cancellationToken = default)
        {
            if (discount == null)
            {
                throw new ArgumentNullException(nameof(discount));
            }

            _logger.LogInformation("Creating new discount with code: {Code}", discount.Code);
            return await _client.PostAsync<Discount, PaddleResponse<Discount>>(BasePath, discount, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<Discount>> UpdateDiscountAsync(string discountId, Discount discount, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(discountId))
            {
                throw new ArgumentException("Discount ID must be provided", nameof(discountId));
            }

            if (discount == null)
            {
                throw new ArgumentNullException(nameof(discount));
            }

            _logger.LogInformation("Updating discount with ID: {DiscountId}", discountId);
            return await _client.PatchAsync<Discount, PaddleResponse<Discount>>($"{BasePath}/{discountId}", discount, cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<List<Discount>>> ListProductDiscountsAsync(string productId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(productId))
            {
                throw new ArgumentException("Product ID must be provided", nameof(productId));
            }

            _logger.LogInformation("Retrieving discounts for product with ID: {ProductId}", productId);
            return await _client.GetAsync<PaddleResponse<List<Discount>>>($"{BasePath}?product_id={productId}", cancellationToken);
        }

        /// <inheritdoc/>
        public async Task<PaddleResponse<List<Discount>>> ListPriceDiscountsAsync(string priceId, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(priceId))
            {
                throw new ArgumentException("Price ID must be provided", nameof(priceId));
            }

            _logger.LogInformation("Retrieving discounts for price with ID: {PriceId}", priceId);
            return await _client.GetAsync<PaddleResponse<List<Discount>>>($"{BasePath}?price_id={priceId}", cancellationToken);
        }
    }
}