using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class NotificationLogCollection : Collection<NotificationLog>
    {
        public NotificationLogCollection(List<NotificationLog> items, Paginator paginator = null) 
            : base(items, paginator)
        {
        }

        public static NotificationLogCollection FromList(IEnumerable<JsonElement> itemsData, Paginator paginator = null)
        {
            var items = itemsData.Select(NotificationLog.FromDict).ToList();
            return new NotificationLogCollection(items, paginator);
        }
    }
} 