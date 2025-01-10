using System.Text.Json;
using System.Threading.Tasks;

namespace PaddleWrapper.Clients
{
    public class ProductClient
    {
        private readonly PaddleClient _paddleClient;

        public ProductClient(PaddleClient paddleClient)
        {
            _paddleClient = paddleClient;
        }

        public async Task<JsonElement> GetProductAsync(string productId)
        {
            var payload = new { product_id = productId };
            return await _paddleClient.SendRequestAsync("product/get", payload);
        }
    }
} 