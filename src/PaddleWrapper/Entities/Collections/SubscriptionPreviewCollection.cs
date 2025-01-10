using System.Text.Json;
using PaddleWrapper.Entities.Subscriptions;

namespace PaddleWrapper.Entities.Collections
{
    public class SubscriptionPreviewCollection : Collection<SubscriptionPreview>
    {
        public SubscriptionPreviewCollection(List<SubscriptionPreview> items, Paginator paginator = null) 
            : base(items, paginator)
        {
        }

        public static SubscriptionPreviewCollection FromList(IEnumerable<JsonElement> itemsData, Paginator paginator = null)
        {
            var items = itemsData.Select(SubscriptionPreview.FromDict).ToList();
            return new SubscriptionPreviewCollection(items, paginator);
        }
    }
} 