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
            List<SubscriptionPreview> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(SubscriptionPreview.From((Dictionary<string, object>)item));
            }

            return new SubscriptionPreviewCollection(items, paginator);
        }
    }
}