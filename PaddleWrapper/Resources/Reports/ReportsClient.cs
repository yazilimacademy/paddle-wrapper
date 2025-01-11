using System.Threading.Tasks;
using PaddleWrapper.Client;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Resources.Reports.Operations;

namespace PaddleWrapper.Resources.Reports
{
    public class ReportsClient
    {
        private readonly IPaddleClient _client;

        public ReportsClient(IPaddleClient client)
        {
            _client = client;
        }

        public async Task<ReportCollection> ListAsync(ListReports listOperation = null)
        {
            listOperation ??= new ListReports();
            var response = await _client.GetRawAsync("/reports", listOperation);
            var parser = new ResponseParser(response);

            return ReportCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(ReportCollection))
            );
        }

        public async Task<Report> GetAsync(string id)
        {
            var response = await _client.GetRawAsync($"/reports/{id}");
            var parser = new ResponseParser(response);

            return Report.From(parser.GetData());
        }

        public async Task<ReportCSV> GetReportCsvAsync(string id)
        {
            var response = await _client.GetRawAsync($"/reports/{id}/download-url");
            var parser = new ResponseParser(response);

            return ReportCSV.From(parser.GetData());
        }

        public async Task<Report> CreateAsync(CreateReport createOperation)
        {
            var response = await _client.PostRawAsync("/reports", createOperation);
            var parser = new ResponseParser(response);

            return Report.From(parser.GetData());
        }
    }
} 