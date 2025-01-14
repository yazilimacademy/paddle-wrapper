using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class NotificationSettingCollection : Collection<NotificationSetting>
    {
        private NotificationSettingCollection(List<NotificationSetting> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static NotificationSettingCollection FromJson(JsonElement json, Paginator? paginator)
        {
            return From(JsonSerializer.Deserialize<Dictionary<string, object>>(json.GetRawText()), paginator);
        }

        public static new NotificationSettingCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            List<NotificationSetting> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(NotificationSetting.From((Dictionary<string, object>)item));
            }

            return new NotificationSettingCollection(items, paginator);
        }
    }
}