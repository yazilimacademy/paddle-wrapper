using PaddleWrapper.Entities;
using PaddleWrapper.Resources.PricingPreviews.Operations;

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
            var response = await _client.PostRawAsync("/pricing-preview", operation);
            ResponseParser parser = new(response);

            return PricePreview.From(parser.GetData());
        }
    }
}