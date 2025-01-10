using PaddleWrapper.Models.Common;
using PaddleWrapper.Models.Products;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace PaddleWrapper.Interfaces
{
    /// <summary>
    /// Interface for managing products in the Paddle system
    /// </summary>
    public interface IProductService
    {
        /// <summary>
        /// Gets a list of all products
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<List<Product>>> ListProductsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Gets a product by its ID
        /// </summary>
        /// <param name="productId">The ID of the product</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Product>> GetProductAsync(string productId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new product
        /// </summary>
        /// <param name="product">The product to create</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Product>> CreateProductAsync(Product product, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing product
        /// </summary>
        /// <param name="productId">The ID of the product to update</param>
        /// <param name="product">The updated product data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        Task<PaddleResponse<Product>> UpdateProductAsync(string productId, Product product, CancellationToken cancellationToken = default);
    }
}