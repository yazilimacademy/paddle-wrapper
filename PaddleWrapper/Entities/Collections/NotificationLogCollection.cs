namespace PaddleWrapper.Entities.Collections
{
    public class NotificationLogCollection : Collection<NotificationLog>
    {
        private NotificationLogCollection(List<NotificationLog> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new NotificationLogCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            List<NotificationLog> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(NotificationLog.From((Dictionary<string, object>)item));
            }

            return new NotificationLogCollection(items, paginator);
        }
    }
}