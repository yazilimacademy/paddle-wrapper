using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Discount;

namespace PaddleWrapper.Core.Interfaces
{
    /// <summary>
    /// İndirim işlemleri için servis arayüzü.
    /// </summary>
    public interface IDiscountService
    {
        /// <summary>
        /// İndirim detaylarını getirir.
        /// </summary>
        Task<PaddleResponse<Discount>> GetDiscountAsync(string discountId);

        /// <summary>
        /// Yeni bir indirim oluşturur.
        /// </summary>
        Task<PaddleResponse<Discount>> CreateDiscountAsync(Discount discount);

        /// <summary>
        /// Mevcut bir indirimi günceller.
        /// </summary>
        Task<PaddleResponse<Discount>> UpdateDiscountAsync(string discountId, Discount discount);

        /// <summary>
        /// Bir indirimi siler.
        /// </summary>
        Task<PaddleResponse<bool>> DeleteDiscountAsync(string discountId);

        /// <summary>
        /// İndirim listesini getirir.
        /// </summary>
        Task<PaddleResponse<Discount[]>> ListDiscountsAsync();

        /// <summary>
        /// İndirim kodunu doğrular.
        /// </summary>
        Task<PaddleResponse<bool>> ValidateDiscountAsync(string code);
    }
}