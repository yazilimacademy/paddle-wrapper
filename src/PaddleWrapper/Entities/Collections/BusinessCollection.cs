using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class BusinessCollection : Collection<Business>
    {
        public BusinessCollection(List<Business> items, Paginator paginator = null) 
            : base(items, paginator)
        {
        }

        public static BusinessCollection FromList(IEnumerable<JsonElement> itemsData, Paginator paginator = null)
        {
            var items = itemsData.Select(Business.FromDict).ToList();
            return new BusinessCollection(items, paginator);
        }
    }
} 