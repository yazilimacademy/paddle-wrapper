using PaddleWrapper.Models.Common;
using PaddleWrapper.Models.Prices;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PaddleWrapper.Interfaces
{
    /// <summary>
    /// Interface for managing prices in the Paddle system
    /// </summary>
    public interface IPriceService
    {
        /// <summary>
        /// Gets a list of all prices
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<List<Price>>> ListPricesAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a list of prices for a specific product
        /// </summary>
        /// <param name="productId">The ID of the product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<List<Price>>> ListProductPricesAsync(string productId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a price by its ID
        /// </summary>
        /// <param name="priceId">The ID of the price</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Price>> GetPriceAsync(string priceId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new price
        /// </summary>
        /// <param name="price">The price to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Price>> CreatePriceAsync(Price price, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing price
        /// </summary>
        /// <param name="priceId">The ID of the price to update</param>
        /// <param name="price">The updated price data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Price>> UpdatePriceAsync(string priceId, Price price, CancellationToken cancellationToken = default);
    }
}