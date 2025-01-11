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
            List<Subscription.Subscription> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(Subscription.Subscription.From((Dictionary<string, object>)item));
            }

            return new SubscriptionCollection(items, paginator);
        }
    }
}