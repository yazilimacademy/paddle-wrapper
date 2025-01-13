using PaddleWrapper.Entities;
using PaddleWrapper.Extensions;
using PaddleWrapper.Resources.PricingPreviews.Operations;
using System.Text.Json;

namespace PaddleWrapper.Resources.PricingPreviews
{
    public class PricingPreviewsClient
    {
        private readonly Client _client;

        public PricingPreviewsClient(Client client)
        {
            _client = client;
        }

        public async Task<PricePreview> PreviewPricesAsync(PreviewPrice operation)
        {
            JsonDocument response = await _client.Post("/pricing-preview", operation);
            return PricePreview.FromJson(response.RootElement.GetProperty("data"));
        }
    }
}