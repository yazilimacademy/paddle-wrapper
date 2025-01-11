using System.Collections.Generic;
using PaddleWrapper.Entities.Notification;

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
            var items = new List<Notification.Notification>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(Notification.Notification.From((Dictionary<string, object>)item));
            }

            return new NotificationCollection(items, paginator);
        }
    }
} 