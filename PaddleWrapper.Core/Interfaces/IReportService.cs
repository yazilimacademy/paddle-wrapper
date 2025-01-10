using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Report;

namespace PaddleWrapper.Core.Interfaces
{
    /// <summary>
    /// Rapor işlemleri için servis arayüzü.
    /// </summary>
    public interface IReportService
    {
        /// <summary>
        /// Yeni bir rapor oluşturur.
        /// </summary>
        Task<PaddleResponse<Report>> CreateReportAsync(string type, ReportParameters parameters);

        /// <summary>
        /// Rapor detaylarını getirir.
        /// </summary>
        Task<PaddleResponse<Report>> GetReportAsync(string reportId);

        /// <summary>
        /// Rapor listesini getirir.
        /// </summary>
        Task<PaddleResponse<Report[]>> ListReportsAsync(DateTime? startDate = null, DateTime? endDate = null);

        /// <summary>
        /// Raporu indirir.
        /// </summary>
        Task<PaddleResponse<byte[]>> DownloadReportAsync(string reportId);

        /// <summary>
        /// Raporu iptal eder.
        /// </summary>
        Task<PaddleResponse<bool>> CancelReportAsync(string reportId);

        /// <summary>
        /// Gelir raporunu oluşturur.
        /// </summary>
        Task<PaddleResponse<Report>> CreateRevenueReportAsync(DateTime startDate, DateTime endDate, string groupBy = "day");

        /// <summary>
        /// Abonelik raporunu oluşturur.
        /// </summary>
        Task<PaddleResponse<Report>> CreateSubscriptionReportAsync(DateTime startDate, DateTime endDate, string groupBy = "day");

        /// <summary>
        /// İşlem raporunu oluşturur.
        /// </summary>
        Task<PaddleResponse<Report>> CreateTransactionReportAsync(DateTime startDate, DateTime endDate, string groupBy = "day");
    }
}