using System.Collections.Generic;
using PaddleWrapper.Entities.Subscription;

namespace PaddleWrapper.Entities.Collections
{
    public class SubscriptionCollection : Collection<Subscription.Subscription>
    {
        private SubscriptionCollection(List<Subscription.Subscription> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new SubscriptionCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            var items = new List<Subscription.Subscription>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(Subscription.Subscription.From((Dictionary<string, object>)item));
            }

            return new SubscriptionCollection(items, paginator);
        }
    }
} 