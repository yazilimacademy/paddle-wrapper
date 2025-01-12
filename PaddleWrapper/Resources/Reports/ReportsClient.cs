using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Resources.Reports.Operations;

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
            var response = await _client.GetRaw("/reports", listOperation);
            ResponseParser parser = new(response);

            return ReportCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(ReportCollection))
            );
        }

        public async Task<Report> GetAsync(string id)
        {
            HttpResponseMessage response = await _client.GetRaw($"/reports/{id}");
            ResponseParser parser = new(response);

            return Report.From(parser.GetData());
        }

        public async Task<ReportCSV> GetReportCsvAsync(string id)
        {
            HttpResponseMessage response = await _client.GetRaw($"/reports/{id}/download-url");
            ResponseParser parser = new(response);

            return ReportCSV.From(parser.GetData());
        }

        public async Task<Report> CreateAsync(CreateReport createOperation)
        {
            var response = await _client.PostRaw("/reports", createOperation);
            ResponseParser parser = new(response);

            return Report.From(parser.GetData());
        }
    }
}