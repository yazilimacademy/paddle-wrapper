using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Extensions;
using PaddleWrapper.Resources.Reports.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.Reports
{
    public class ReportsClient
    {
        private readonly Client _client;

        public ReportsClient(Client client)
        {
            _client = client;
        }

        public async Task<ReportCollection> ListAsync(ListReports listOperation = null)
        {
            listOperation ??= new ListReports();
            HttpResponseMessage response = await _client.GetRawAsync("/reports", listOperation);
            JsonElement jsonElement = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(ReportCollection)
            );

            return ReportCollection.FromJson(data, paginator);
        }

        public async Task<Report> GetAsync(string id)
        {
            JsonDocument response = await _client.Get($"/reports/{id}");
            return Report.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<ReportCSV> GetReportCsvAsync(string id)
        {
            JsonDocument response = await _client.Get($"/reports/{id}/download-url");
            return ReportCSV.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<Report> CreateAsync(CreateReport createOperation)
        {
            JsonDocument response = await _client.Post("/reports", createOperation);
            return Report.FromJson(response.RootElement.GetProperty("data"));
        }
    }
}