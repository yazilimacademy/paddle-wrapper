using System.Collections.Generic;
using PaddleWrapper.Entities.Subscription;

namespace PaddleWrapper.Entities.Collections
{
    public class SubscriptionPreviewCollection : Collection<SubscriptionPreview>
    {
        private SubscriptionPreviewCollection(List<SubscriptionPreview> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new SubscriptionPreviewCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            var items = new List<SubscriptionPreview>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(SubscriptionPreview.From((Dictionary<string, object>)item));
            }

            return new SubscriptionPreviewCollection(items, paginator);
        }
    }
} 