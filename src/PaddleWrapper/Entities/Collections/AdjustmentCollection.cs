using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class AdjustmentCollection : Collection<Adjustment>
    {
        public AdjustmentCollection(List<Adjustment> items, Paginator paginator = null) 
            : base(items, paginator)
        {
        }

        public static AdjustmentCollection FromList(IEnumerable<JsonElement> itemsData, Paginator paginator = null)
        {
            var items = itemsData.Select(Adjustment.FromDict).ToList();
            return new AdjustmentCollection(items, paginator);
        }
    }
} 