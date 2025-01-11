using System.Collections.Generic;
using PaddleWrapper.Entities.Event;

namespace PaddleWrapper.Entities.Collections
{
    public class EventCollection : Collection<Event.Event>
    {
        private EventCollection(List<Event.Event> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new EventCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            var items = new List<Event.Event>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(Event.Event.From((Dictionary<string, object>)item));
            }

            return new EventCollection(items, paginator);
        }
    }
} 