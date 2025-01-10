using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class SubscriptionCollection : Collection<Subscription>
    {
        public SubscriptionCollection(List<Subscription> items, Paginator paginator = null) 
            : base(items, paginator)
        {
        }

        public static SubscriptionCollection FromList(IEnumerable<JsonElement> itemsData, Paginator paginator = null)
        {
            var items = itemsData.Select(Subscription.FromDict).ToList();
            return new SubscriptionCollection(items, paginator);
        }
    }
} 