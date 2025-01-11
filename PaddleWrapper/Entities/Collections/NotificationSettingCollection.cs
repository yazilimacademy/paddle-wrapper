using System.Collections.Generic;
using PaddleWrapper.Entities.Notification;

namespace PaddleWrapper.Entities.Collections
{
    public class NotificationSettingCollection : Collection<NotificationSetting>
    {
        private NotificationSettingCollection(List<NotificationSetting> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new NotificationSettingCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            var items = new List<NotificationSetting>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(NotificationSetting.From((Dictionary<string, object>)item));
            }

            return new NotificationSettingCollection(items, paginator);
        }
    }
} 