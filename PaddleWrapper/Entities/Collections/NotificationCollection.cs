using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class NotificationCollection : Collection<Notification>
    {
        private NotificationCollection(List<Notification> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static NotificationCollection FromJson(JsonElement json, Paginator? paginator)
        {
            return From(JsonSerializer.Deserialize<Dictionary<string, object>>(json.GetRawText()), paginator);
        }

        public static new NotificationCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            List<Notification> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(Notification.From((Dictionary<string, object>)item));
            }

            return new NotificationCollection(items, paginator);
        }
    }
}