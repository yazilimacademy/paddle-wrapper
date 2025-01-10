using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class EventCollection : Collection<Event>
    {
        public EventCollection(List<Event> items, Paginator paginator = null) 
            : base(items, paginator)
        {
        }

        public static EventCollection FromList(IEnumerable<JsonElement> itemsData, Paginator paginator = null)
        {
            var items = itemsData.Select(Event.FromDict).ToList();
            return new EventCollection(items, paginator);
        }
    }
} 