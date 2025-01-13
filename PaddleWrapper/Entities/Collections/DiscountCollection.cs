using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class DiscountCollection : Collection<Discount>
    {
        private DiscountCollection(List<Discount> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static DiscountCollection FromJson(JsonElement json, Paginator? paginator)
        {
            return From(JsonSerializer.Deserialize<Dictionary<string, object>>(json.GetRawText()), paginator);
        }

        public static new DiscountCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            List<Discount> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(Discount.From((Dictionary<string, object>)item));
            }

            return new DiscountCollection(items, paginator);
        }
    }
}