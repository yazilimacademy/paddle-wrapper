using System.Threading.Tasks;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Adjustment;

namespace PaddleWrapper.Core.Interfaces
{
    /// <summary>
    /// Ayarlama işlemleri için servis arayüzü.
    /// </summary>
    public interface IAdjustmentService
    {
        /// <summary>
        /// Ayarlama detaylarını getirir.
        /// </summary>
        Task<PaddleResponse<Adjustment>> GetAdjustmentAsync(string adjustmentId);

        /// <summary>
        /// Yeni bir ayarlama oluşturur.
        /// </summary>
        Task<PaddleResponse<Adjustment>> CreateAdjustmentAsync(Adjustment adjustment);

        /// <summary>
        /// Mevcut bir ayarlamayı günceller.
        /// </summary>
        Task<PaddleResponse<Adjustment>> UpdateAdjustmentAsync(string adjustmentId, Adjustment adjustment);

        /// <summary>
        /// Ayarlama listesini getirir.
        /// </summary>
        Task<PaddleResponse<Adjustment[]>> ListAdjustmentsAsync();

        /// <summary>
        /// Müşterinin ayarlamalarını getirir.
        /// </summary>
        Task<PaddleResponse<Adjustment[]>> GetCustomerAdjustmentsAsync(string customerId);

        /// <summary>
        /// Aboneliğin ayarlamalarını getirir.
        /// </summary>
        Task<PaddleResponse<Adjustment[]>> GetSubscriptionAdjustmentsAsync(string subscriptionId);

        /// <summary>
        /// Ayarlamayı iptal eder.
        /// </summary>
        Task<PaddleResponse<bool>> CancelAdjustmentAsync(string adjustmentId);

        /// <summary>
        /// Ayarlamayı onaylar.
        /// </summary>
        Task<PaddleResponse<Adjustment>> ApproveAdjustmentAsync(string adjustmentId);
    }
} 