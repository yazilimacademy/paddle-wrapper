using System.Text.Json;
using PaddleWrapper.Entities.Notifications;

namespace PaddleWrapper.Entities.Collections
{
    public class NotificationCollection : Collection<Notification>
    {
        public NotificationCollection(List<Notification> items, Paginator paginator = null) 
            : base(items, paginator)
        {
        }

        public static NotificationCollection FromList(IEnumerable<JsonElement> itemsData, Paginator paginator = null)
        {
            var items = itemsData.Select(Notification.FromDict).ToList();
            return new NotificationCollection(items, paginator);
        }
    }
} 