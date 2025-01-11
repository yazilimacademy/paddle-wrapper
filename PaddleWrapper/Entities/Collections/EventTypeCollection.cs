using System.Collections.Generic;
using PaddleWrapper.Entities.Event;

namespace PaddleWrapper.Entities.Collections
{
    public class EventTypeCollection : Collection<EventType>
    {
        private EventTypeCollection(List<EventType> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new EventTypeCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            var items = new List<EventType>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(EventType.From((Dictionary<string, object>)item));
            }

            return new EventTypeCollection(items, paginator);
        }
    }
} 