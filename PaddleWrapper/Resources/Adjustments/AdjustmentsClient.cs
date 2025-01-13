using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Resources.Adjustments.Operations;

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
            var response = await _client.GetRawAsync("/adjustments", listOperation);
            ResponseParser parser = new(response);

            return AdjustmentCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(AdjustmentCollection))
            );
        }

        public async Task<Adjustment> CreateAsync(CreateAdjustment createOperation)
        {
            var response = await _client.PostRawAsync("/adjustments", createOperation);
            ResponseParser parser = new(response);

            return Adjustment.From(parser.GetData());
        }

        public async Task<AdjustmentCreditNote> GetCreditNoteAsync(string id, GetAdjustmentCreditNote getOperation = null)
        {
            getOperation ??= new GetAdjustmentCreditNote();
            var response = await _client.GetRawAsync($"/adjustments/{id}/credit-note", getOperation);
            ResponseParser parser = new(response);

            return AdjustmentCreditNote.From(parser.GetData());
        }
    }
}