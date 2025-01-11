namespace PaddleWrapper.Entities.Collections
{
    public class NotificationCollection : Collection<Notification.Notification>
    {
        private NotificationCollection(List<Notification.Notification> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new NotificationCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            List<Notification.Notification> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(Notification.Notification.From((Dictionary<string, object>)item));
            }

            return new NotificationCollection(items, paginator);
        }
    }
}