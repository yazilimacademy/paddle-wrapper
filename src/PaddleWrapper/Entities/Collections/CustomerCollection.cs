using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class CustomerCollection : Collection<Customer>
    {
        public CustomerCollection(List<Customer> items, Paginator paginator = null) 
            : base(items, paginator)
        {
        }

        public static CustomerCollection FromList(IEnumerable<JsonElement> itemsData, Paginator paginator = null)
        {
            var items = itemsData.Select(Customer.FromDict).ToList();
            return new CustomerCollection(items, paginator);
        }
    }
} 