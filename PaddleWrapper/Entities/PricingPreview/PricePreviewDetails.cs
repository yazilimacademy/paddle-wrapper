using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.PricingPreview
{
    public class PricePreviewDetails
    {
        [JsonPropertyName("line_items")]
        public IReadOnlyList<PricePreviewLineItem> LineItems { get; }

        private PricePreviewDetails(IReadOnlyList<PricePreviewLineItem> lineItems)
        {
            LineItems = lineItems;
        }

        public static PricePreviewDetails From(Dictionary<string, object> data)
        {
            List<PricePreviewLineItem> lineItems = new();
            object[] lineItemsData = (object[])data["line_items"];

            foreach (object item in lineItemsData)
            {
                lineItems.Add(PricePreviewLineItem.From((Dictionary<string, object>)item));
            }

            return new PricePreviewDetails(lineItems);
        }
    }
}