using System.Collections.Generic;
using System.Text.Json.Serialization;
using PaddleWrapper.Entities.Shared;

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
            var lineItems = new List<PricePreviewLineItem>();
            var lineItemsData = (object[])data["line_items"];

            foreach (var item in lineItemsData)
            {
                lineItems.Add(PricePreviewLineItem.From((Dictionary<string, object>)item));
            }

            return new PricePreviewDetails(lineItems);
        }
    }
} 