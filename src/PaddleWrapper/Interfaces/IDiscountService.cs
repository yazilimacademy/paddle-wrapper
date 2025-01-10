using PaddleWrapper.Models.Common;
using PaddleWrapper.Models.Discounts;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PaddleWrapper.Interfaces
{
    /// <summary>
    /// Interface for managing discounts in the Paddle system
    /// </summary>
    public interface IDiscountService
    {
        /// <summary>
        /// Gets a list of all discounts
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<List<Discount>>> ListDiscountsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a discount by its ID
        /// </summary>
        /// <param name="discountId">The ID of the discount</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Discount>> GetDiscountAsync(string discountId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new discount
        /// </summary>
        /// <param name="discount">The discount to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Discount>> CreateDiscountAsync(Discount discount, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing discount
        /// </summary>
        /// <param name="discountId">The ID of the discount to update</param>
        /// <param name="discount">The updated discount data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Discount>> UpdateDiscountAsync(string discountId, Discount discount, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a list of discounts for a product
        /// </summary>
        /// <param name="productId">The ID of the product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<List<Discount>>> ListProductDiscountsAsync(string productId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a list of discounts for a price
        /// </summary>
        /// <param name="priceId">The ID of the price</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<List<Discount>>> ListPriceDiscountsAsync(string priceId, CancellationToken cancellationToken = default);
    }
}