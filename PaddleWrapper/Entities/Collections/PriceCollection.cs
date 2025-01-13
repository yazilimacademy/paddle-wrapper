using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class PriceCollection : Collection<Price>
    {
        private PriceCollection(List<Price> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static PriceCollection FromJson(JsonElement json, Paginator? paginator)
        {
            return From(JsonSerializer.Deserialize<Dictionary<string, object>>(json.GetRawText()), paginator);
        }

        public static new PriceCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            List<Price> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(Price.From((Dictionary<string, object>)item));
            }

            return new PriceCollection(items, paginator);
        }
    }
}