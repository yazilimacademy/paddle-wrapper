using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class NotificationSettingCollection : Collection<NotificationSetting>
    {
        public NotificationSettingCollection(List<NotificationSetting> items, Paginator paginator = null) 
            : base(items, paginator)
        {
        }

        public static NotificationSettingCollection FromList(IEnumerable<JsonElement> itemsData, Paginator paginator = null)
        {
            var items = itemsData.Select(NotificationSetting.FromDict).ToList();
            return new NotificationSettingCollection(items, paginator);
        }
    }
} 