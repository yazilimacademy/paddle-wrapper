using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using PaddleWrapper.Resources.Reports.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.Reports
{
    public class ReportsClient(Client client)
    {
        public async Task<ReportCollection> ListAsync(ListReports listOperation = null)
        {
            try
            {
                listOperation ??= new ListReports();
                HttpResponseMessage response = await client.GetRawAsync("/reports", listOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement jsonElement = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw ReportApiError.FromJson(jsonElement);
                }

                JsonElement data = jsonElement.GetProperty("data");
                JsonElement meta = jsonElement.GetProperty("meta");

                Paginator paginator = new(
                    client.HttpClient,
                    Pagination.FromJson(meta),
                    typeof(ReportCollection)
                );

                return ReportCollection.FromJson(data, paginator);
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (ReportApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Report> GetAsync(string id)
        {
            try
            {
                HttpResponseMessage response = await client.GetRawAsync($"/reports/{id}");
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw ReportApiError.FromJson(root);
                }

                return Report.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (ReportApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<Report> CreateAsync(CreateReport createOperation)
        {
            try
            {
                HttpResponseMessage response = await client.PostRawAsync("/reports", createOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw ReportApiError.FromJson(root);
                }

                return Report.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (ReportApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }

        public async Task<ReportCSV> GetReportCsvAsync(string id)
        {
            try
            {
                HttpResponseMessage response = await client.GetRawAsync($"/reports/{id}/download");
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw ReportApiError.FromJson(root);
                }

                return ReportCSV.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (ReportApiError)
            {
                throw;
            }
            catch (Exception ex)
            {
                throw new SdkException("An unexpected error occurred", ex);
            }
        }
    }
}