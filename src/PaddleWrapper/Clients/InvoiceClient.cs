using System.Text.Json;
using System.Threading.Tasks;

namespace PaddleWrapper.Clients
{
    public class InvoiceClient
    {
        private readonly PaddleClient _paddleClient;

        public InvoiceClient(PaddleClient paddleClient)
        {
            _paddleClient = paddleClient;
        }

        public async Task<JsonElement> GetInvoiceAsync(string invoiceId)
        {
            var payload = new { invoice_id = invoiceId };
            return await _paddleClient.SendRequestAsync("invoice/get", payload);
        }
    }
} 