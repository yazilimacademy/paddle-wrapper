using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class BusinessCollection : Collection<Business>
    {
        private BusinessCollection(List<Business> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static BusinessCollection FromJson(JsonElement json, Paginator? paginator)
        {
            return From(JsonSerializer.Deserialize<Dictionary<string, object>>(json.GetRawText()), paginator);
        }

        public static new BusinessCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            List<Business> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(Business.From((Dictionary<string, object>)item));
            }

            return new BusinessCollection(items, paginator);
        }
    }
}