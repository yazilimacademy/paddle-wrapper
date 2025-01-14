using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class EventTypeCollection : Collection<EventType>
    {
        private EventTypeCollection(List<EventType> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static EventTypeCollection FromJson(JsonElement json, Paginator? paginator)
        {
            return From(JsonSerializer.Deserialize<Dictionary<string, object>>(json.GetRawText()), paginator);
        }

        public static new EventTypeCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            List<EventType> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(EventType.From((Dictionary<string, object>)item));
            }

            return new EventTypeCollection(items, paginator);
        }
    }
}