using System.Threading.Tasks;
using PaddleWrapper.Client;
using PaddleWrapper.Entities;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Resources.PricingPreviews.Operations;

namespace PaddleWrapper.Resources.PricingPreviews
{
    public class PricingPreviewsClient
    {
        private readonly IPaddleClient _client;

        public PricingPreviewsClient(IPaddleClient client)
        {
            _client = client;
        }

        public async Task<PricePreview> PreviewPricesAsync(PreviewPrice operation)
        {
            var response = await _client.PostRawAsync("/pricing-preview", operation);
            var parser = new ResponseParser(response);

            return PricePreview.From(parser.GetData());
        }
    }
} 