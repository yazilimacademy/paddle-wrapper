using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class DiscountCollection : Collection<Discount>
    {
        public DiscountCollection(List<Discount> items, Paginator paginator = null) 
            : base(items, paginator)
        {
        }

        public static DiscountCollection FromList(IEnumerable<JsonElement> itemsData, Paginator paginator = null)
        {
            var items = itemsData.Select(Discount.FromDict).ToList();
            return new DiscountCollection(items, paginator);
        }
    }
} 