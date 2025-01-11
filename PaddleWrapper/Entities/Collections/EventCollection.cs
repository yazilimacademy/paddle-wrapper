namespace PaddleWrapper.Entities.Collections
{
    public class EventCollection : Collection<Event>
    {
        private EventCollection(List<Event> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new EventCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            List<Event> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(Event.From((Dictionary<string, object>)item));
            }

            return new EventCollection(items, paginator);
        }
    }
}