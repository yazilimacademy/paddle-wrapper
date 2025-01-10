using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class PriceCollection : Collection<Price>
    {
        public PriceCollection(List<Price> items, Paginator paginator = null) 
            : base(items, paginator)
        {
        }

        public static PriceCollection FromList(IEnumerable<JsonElement> itemsData, Paginator paginator = null)
        {
            var items = itemsData.Select(Price.FromDict).ToList();
            return new PriceCollection(items, paginator);
        }
    }
} 