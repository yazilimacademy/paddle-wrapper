using PaddleWrapper.Entities;
using PaddleWrapper.Exceptions;
using PaddleWrapper.Exceptions.ApiErrors;
using PaddleWrapper.Exceptions.SdkExceptions;
using System.Text.Json;

namespace PaddleWrapper.Resources.PricingPreviews
{
    public class PricingPreviewsClient(Client client)
    {
        public async Task<PricePreview> PreviewPricesAsync(PricePreview previewOperation)
        {
            try
            {
                HttpResponseMessage response = await client.PostRawAsync("/pricing-preview", previewOperation);
                string jsonString = await response.Content.ReadAsStringAsync();
                JsonElement root = JsonDocument.Parse(jsonString).RootElement;

                if (!response.IsSuccessStatusCode)
                {
                    throw PricePreviewApiError.FromJson(root);
                }

                return PricePreview.FromJson(root.GetProperty("data"));
            }
            catch (JsonException ex)
            {
                throw new MalformedResponse("Failed to parse API response", ex);
            }
            catch (PricePreviewApiError)
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