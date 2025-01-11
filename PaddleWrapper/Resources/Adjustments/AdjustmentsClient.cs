using System.Threading.Tasks;
using PaddleWrapper.Client;
using PaddleWrapper.Entities;
using PaddleWrapper.Entities.Collections;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Resources.Adjustments.Operations;

namespace PaddleWrapper.Resources.Adjustments
{
    public class AdjustmentsClient
    {
        private readonly IPaddleClient _client;

        public AdjustmentsClient(IPaddleClient client)
        {
            _client = client;
        }

        public async Task<AdjustmentCollection> ListAsync(ListAdjustments listOperation = null)
        {
            listOperation ??= new ListAdjustments();
            var response = await _client.GetRawAsync("/adjustments", listOperation);
            var parser = new ResponseParser(response);

            return AdjustmentCollection.From(
                parser.GetData(),
                new Paginator(_client, parser.GetPagination(), typeof(AdjustmentCollection))
            );
        }

        public async Task<Adjustment> CreateAsync(CreateAdjustment createOperation)
        {
            var response = await _client.PostRawAsync("/adjustments", createOperation);
            var parser = new ResponseParser(response);

            return Adjustment.From(parser.GetData());
        }

        public async Task<AdjustmentCreditNote> GetCreditNoteAsync(string id, GetAdjustmentCreditNote getOperation = null)
        {
            getOperation ??= new GetAdjustmentCreditNote();
            var response = await _client.GetRawAsync($"/adjustments/{id}/credit-note", getOperation);
            var parser = new ResponseParser(response);

            return AdjustmentCreditNote.From(parser.GetData());
        }
    }
} 