using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Extensions;
using PaddleWrapper.Resources.Adjustments.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.Adjustments
{
    public class AdjustmentsClient
    {
        private readonly Client _client;

        public AdjustmentsClient(Client client)
        {
            _client = client;
        }

        public async Task<AdjustmentCollection> ListAsync(ListAdjustments listOperation = null)
        {
            listOperation ??= new ListAdjustments();
            HttpResponseMessage response = await _client.GetRawAsync("/adjustments", listOperation);
            JsonElement jsonElement = JsonDocument.Parse(await response.Content.ReadAsStringAsync()).RootElement;
            JsonElement data = jsonElement.GetProperty("data");
            JsonElement meta = jsonElement.GetProperty("meta");

            Paginator paginator = new(
                _client.HttpClient,
                Pagination.FromJson(meta),
                typeof(AdjustmentCollection)
            );

            return AdjustmentCollection.FromJson(data, paginator);
        }

        public async Task<Adjustment> CreateAsync(CreateAdjustment createOperation)
        {
            JsonDocument response = await _client.Post("/adjustments", createOperation);
            return Adjustment.FromJson(response.RootElement.GetProperty("data"));
        }

        public async Task<AdjustmentCreditNote> GetCreditNoteAsync(string id, GetAdjustmentCreditNote getOperation = null)
        {
            getOperation ??= new GetAdjustmentCreditNote();
            JsonDocument response = await _client.Get($"/adjustments/{id}/credit-note", getOperation);
            return AdjustmentCreditNote.FromJson(response.RootElement.GetProperty("data"));
        }
    }
}