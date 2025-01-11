using System.Collections.Generic;
using PaddleWrapper.Entities.Notification;

namespace PaddleWrapper.Entities.Collections
{
    public class NotificationLogCollection : Collection<NotificationLog>
    {
        private NotificationLogCollection(List<NotificationLog> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new NotificationLogCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            var items = new List<NotificationLog>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(NotificationLog.From((Dictionary<string, object>)item));
            }

            return new NotificationLogCollection(items, paginator);
        }
    }
} 