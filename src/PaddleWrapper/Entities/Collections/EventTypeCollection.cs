using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class EventTypeCollection : Collection<EventType>
    {
        public EventTypeCollection(List<EventType> items, Paginator paginator = null) 
            : base(items, paginator)
        {
        }

        public static EventTypeCollection FromList(IEnumerable<JsonElement> itemsData, Paginator paginator = null)
        {
            var items = itemsData.Select(EventType.FromDict).ToList();
            return new EventTypeCollection(items, paginator);
        }
    }
} 