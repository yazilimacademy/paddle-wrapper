using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Price;

namespace PaddleWrapper.Core.Interfaces
{
    /// <summary>
    /// Fiyatlandırma işlemleri için servis arayüzü.
    /// </summary>
    public interface IPriceService
    {
        /// <summary>
        /// Fiyat detaylarını getirir.
        /// </summary>
        Task<PaddleResponse<Price>> GetPriceAsync(string priceId);

        /// <summary>
        /// Yeni bir fiyat oluşturur.
        /// </summary>
        Task<PaddleResponse<Price>> CreatePriceAsync(Price price);

        /// <summary>
        /// Mevcut bir fiyatı günceller.
        /// </summary>
        Task<PaddleResponse<Price>> UpdatePriceAsync(string priceId, Price price);

        /// <summary>
        /// Fiyat listesini getirir.
        /// </summary>
        Task<PaddleResponse<Price[]>> ListPricesAsync();

        /// <summary>
        /// Ürünün fiyatlarını getirir.
        /// </summary>
        Task<PaddleResponse<Price[]>> GetProductPricesAsync(string productId);

        /// <summary>
        /// Fiyatı arşivler.
        /// </summary>
        Task<PaddleResponse<bool>> ArchivePriceAsync(string priceId);

        /// <summary>
        /// Fiyatı aktifleştirir.
        /// </summary>
        Task<PaddleResponse<bool>> ActivatePriceAsync(string priceId);

        /// <summary>
        /// Bölgeye özel fiyatlandırma ekler.
        /// </summary>
        Task<PaddleResponse<Price>> AddRegionalPricingAsync(string priceId, string countryCode, decimal amount);
    }
}