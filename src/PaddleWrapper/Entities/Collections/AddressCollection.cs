using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class AddressCollection : Collection<Address>
    {
        public AddressCollection(List<Address> items, Paginator paginator = null) 
            : base(items, paginator)
        {
        }

        public static AddressCollection FromList(IEnumerable<JsonElement> itemsData, Paginator paginator = null)
        {
            var items = itemsData.Select(Address.FromDict).ToList();
            return new AddressCollection(items, paginator);
        }
    }
} 