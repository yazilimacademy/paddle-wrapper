using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class AdjustmentCollection : Collection<Adjustment>
    {
        private AdjustmentCollection(List<Adjustment> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static AdjustmentCollection FromJson(JsonElement json, Paginator? paginator)
        {
            return From(JsonSerializer.Deserialize<Dictionary<string, object>>(json.GetRawText()), paginator);
        }

        public static new AdjustmentCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            List<Adjustment> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(Adjustment.From((Dictionary<string, object>)item));
            }

            return new AdjustmentCollection(items, paginator);
        }
    }
}