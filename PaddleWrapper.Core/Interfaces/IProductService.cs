using System.Collections.Generic;
using System.Threading.Tasks;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Bulk;
using PaddleWrapper.Core.Models.Product;

namespace PaddleWrapper.Core.Interfaces
{
    public interface IProductService
    {
        Task<PaddleResponse<Product>> GetProductAsync(int productId);
        Task<PaddleResponse<Product>> UpdateProductAsync(int productId, Product product);
        Task<PaddleResponse<Product[]>> ListProductsAsync();
        Task<PaddleResponse<Product>> CreateProductAsync(Product product);

        /// <summary>
        /// Birden fazla ürünü toplu olarak oluşturur.
        /// </summary>
        /// <param name="products">Oluşturulacak ürünler.</param>
        /// <param name="options">Bulk işlem seçenekleri.</param>
        Task<BulkOperationResult<Product>> CreateProductsBulkAsync(
            IEnumerable<Product> products,
            BulkOperationOptions options = null);

        /// <summary>
        /// Birden fazla ürünü toplu olarak günceller.
        /// </summary>
        /// <param name="products">Güncellenecek ürünler.</param>
        /// <param name="options">Bulk işlem seçenekleri.</param>
        Task<BulkOperationResult<Product>> UpdateProductsBulkAsync(
            IEnumerable<Product> products,
            BulkOperationOptions options = null);
    }
} 