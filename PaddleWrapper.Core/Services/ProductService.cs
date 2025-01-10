using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Bulk;
using PaddleWrapper.Core.Models.Product;
using PaddleWrapper.Core.Services.Bulk;
using PaddleWrapper.Core.Services.Cache;

namespace PaddleWrapper.Core.Services
{
    /// <summary>
    /// Paddle ürün yönetimi için servis sınıfı.
    /// </summary>
    public class ProductService : IProductService
    {
        private readonly PaddleHttpClient _httpClient;
        private readonly IPaddleCache _cache;
        private readonly IPaddleLogger _logger;
        private readonly TimeSpan _defaultCacheTime = TimeSpan.FromMinutes(15);
        private const string BaseEndpoint = "product";

        /// <summary>
        /// ProductService sınıfının yeni bir örneğini oluşturur.
        /// </summary>
        /// <param name="httpClient">HTTP istekleri için kullanılacak Paddle HTTP istemcisi.</param>
        /// <param name="cache">Cache servisi.</param>
        /// <param name="logger">Loglama servisi.</param>
        public ProductService(PaddleHttpClient httpClient, IPaddleCache cache, IPaddleLogger logger)
        {
            _httpClient = httpClient;
            _cache = cache;
            _logger = logger;
        }

        /// <summary>
        /// Belirtilen ID'ye sahip ürünü getirir.
        /// </summary>
        /// <param name="productId">Getirilecek ürünün ID'si.</param>
        /// <returns>Ürün bilgilerini içeren yanıt.</returns>
        /// <exception cref="PaddleApiException">API isteği başarısız olduğunda fırlatılır.</exception>
        public async Task<PaddleResponse<Product>> GetProductAsync(int productId)
        {
            string cacheKey = $"product_{productId}";
            PaddleResponse<Product> cachedResponse = await _cache.GetAsync<PaddleResponse<Product>>(cacheKey);
            if (cachedResponse != null)
            {
                return cachedResponse;
            }

            PaddleResponse<Product> response = await _httpClient.GetAsync<PaddleResponse<Product>>($"{BaseEndpoint}/{productId}");
            if (response.Success)
            {
                await _cache.SetAsync(cacheKey, response, _defaultCacheTime);
            }
            return response;
        }

        /// <summary>
        /// Mevcut bir ürünü günceller.
        /// </summary>
        /// <param name="productId">Güncellenecek ürünün ID'si.</param>
        /// <param name="product">Güncellenmiş ürün bilgileri.</param>
        /// <returns>Güncellenmiş ürün bilgilerini içeren yanıt.</returns>
        /// <exception cref="PaddleApiException">API isteği başarısız olduğunda fırlatılır.</exception>
        public async Task<PaddleResponse<Product>> UpdateProductAsync(int productId, Product product)
        {
            PaddleResponse<Product> response = await _httpClient.PostAsync<PaddleResponse<Product>>($"{BaseEndpoint}/{productId}", product);
            if (response.Success)
            {
                await _cache.RemoveAsync($"product_{productId}");
                await _cache.RemoveAsync("products_list");
            }
            return response;
        }

        /// <summary>
        /// Tüm ürünlerin listesini getirir.
        /// </summary>
        /// <returns>Ürün listesini içeren yanıt.</returns>
        /// <exception cref="PaddleApiException">API isteği başarısız olduğunda fırlatılır.</exception>
        public async Task<PaddleResponse<Product[]>> ListProductsAsync()
        {
            string cacheKey = "products_list";
            PaddleResponse<Product[]> cachedResponse = await _cache.GetAsync<PaddleResponse<Product[]>>(cacheKey);
            if (cachedResponse != null)
            {
                return cachedResponse;
            }

            PaddleResponse<Product[]> response = await _httpClient.GetAsync<PaddleResponse<Product[]>>(BaseEndpoint);
            if (response.Success)
            {
                await _cache.SetAsync(cacheKey, response, _defaultCacheTime);
            }
            return response;
        }

        /// <summary>
        /// Yeni bir ürün oluşturur.
        /// </summary>
        /// <param name="product">Oluşturulacak ürün bilgileri.</param>
        /// <returns>Oluşturulan ürün bilgilerini içeren yanıt.</returns>
        /// <exception cref="PaddleApiException">API isteği başarısız olduğunda fırlatılır.</exception>
        public async Task<PaddleResponse<Product>> CreateProductAsync(Product product)
        {
            PaddleResponse<Product> response = await _httpClient.PostAsync<PaddleResponse<Product>>(BaseEndpoint, product);
            if (response.Success)
            {
                await _cache.RemoveAsync("products_list");
            }
            return response;
        }

        /// <inheritdoc/>
        public async Task<BulkOperationResult<Product>> CreateProductsBulkAsync(
            IEnumerable<Product> products,
            BulkOperationOptions options = null)
        {
            BulkOperationHandler<Product, Product> handler = new(
                async product =>
                {
                    PaddleResponse<Product> response = await CreateProductAsync(product);
                    if (!response.Success)
                    {
                        throw new Exception($"Failed to create product: {response.Error?.Message}");
                    }
                    return response.Response;
                },
                _logger);

            BulkOperationResult<Product> result = await handler.ProcessAsync(products, options);

            // Bulk işlem başarılı olduğunda cache'i temizle
            if (result.Success)
            {
                await _cache.RemoveAsync("products_list");
            }

            return result;
        }

        /// <inheritdoc/>
        public async Task<BulkOperationResult<Product>> UpdateProductsBulkAsync(
            IEnumerable<Product> products,
            BulkOperationOptions options = null)
        {
            BulkOperationHandler<Product, Product> handler = new(
                async product =>
                {
                    PaddleResponse<Product> response = await UpdateProductAsync(product.Id, product);
                    if (!response.Success)
                    {
                        throw new Exception($"Failed to update product {product.Id}: {response.Error?.Message}");
                    }
                    return response.Response;
                },
                _logger);

            BulkOperationResult<Product> result = await handler.ProcessAsync(products, options);

            // Bulk işlem başarılı olduğunda cache'i temizle
            if (result.Success)
            {
                await _cache.RemoveAsync("products_list");
                foreach (Product product in products)
                {
                    await _cache.RemoveAsync($"product_{product.Id}");
                }
            }

            return result;
        }
    }
}