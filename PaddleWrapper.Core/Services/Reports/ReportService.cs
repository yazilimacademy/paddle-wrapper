using PaddleWrapper.Core.Interfaces;
using PaddleWrapper.Core.Models;
using PaddleWrapper.Core.Models.Report;

namespace PaddleWrapper.Core.Services.Reports
{
    public class ReportService : IReportService
    {
        private readonly PaddleHttpClient _httpClient;
        private const string BaseEndpoint = "report";

        public ReportService(PaddleHttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PaddleResponse<Report>> CreateReportAsync(string type, ReportParameters parameters)
        {
            return await _httpClient.PostAsync<PaddleResponse<Report>>(BaseEndpoint, new { type, parameters });
        }

        public async Task<PaddleResponse<Report>> GetReportAsync(string reportId)
        {
            return await _httpClient.GetAsync<PaddleResponse<Report>>($"{BaseEndpoint}/{reportId}");
        }

        public async Task<PaddleResponse<Report[]>> ListReportsAsync(DateTime? startDate = null, DateTime? endDate = null)
        {
            string endpoint = BaseEndpoint;
            if (startDate.HasValue || endDate.HasValue)
            {
                endpoint += "?";
                if (startDate.HasValue)
                {
                    endpoint += $"start_date={startDate.Value:yyyy-MM-dd}";
                }

                if (endDate.HasValue)
                {
                    endpoint += $"{(startDate.HasValue ? "&" : "")}end_date={endDate.Value:yyyy-MM-dd}";
                }
            }
            return await _httpClient.GetAsync<PaddleResponse<Report[]>>(endpoint);
        }

        public async Task<PaddleResponse<byte[]>> DownloadReportAsync(string reportId)
        {
            return await _httpClient.GetAsync<PaddleResponse<byte[]>>($"{BaseEndpoint}/{reportId}/download");
        }

        public async Task<PaddleResponse<bool>> CancelReportAsync(string reportId)
        {
            return await _httpClient.PostAsync<PaddleResponse<bool>>($"{BaseEndpoint}/{reportId}/cancel", null);
        }

        public async Task<PaddleResponse<Report>> CreateRevenueReportAsync(DateTime startDate, DateTime endDate, string groupBy = "day")
        {
            ReportParameters parameters = new()
            {
                StartDate = startDate,
                EndDate = endDate,
                GroupBy = groupBy
            };
            return await CreateReportAsync("revenue", parameters);
        }

        public async Task<PaddleResponse<Report>> CreateSubscriptionReportAsync(DateTime startDate, DateTime endDate, string groupBy = "day")
        {
            ReportParameters parameters = new()
            {
                StartDate = startDate,
                EndDate = endDate,
                GroupBy = groupBy
            };
            return await CreateReportAsync("subscription", parameters);
        }

        public async Task<PaddleResponse<Report>> CreateTransactionReportAsync(DateTime startDate, DateTime endDate, string groupBy = "day")
        {
            ReportParameters parameters = new()
            {
                StartDate = startDate,
                EndDate = endDate,
                GroupBy = groupBy
            };
            return await CreateReportAsync("transaction", parameters);
        }
    }
}