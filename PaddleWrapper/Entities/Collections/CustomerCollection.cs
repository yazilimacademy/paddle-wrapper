using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class CustomerCollection : Collection<Customer>
    {
        public CustomerCollection(IEnumerable<Customer> items, Paginator? paginator = null) : base(items, paginator)
        {
        }

        public static CustomerCollection FromJson(JsonElement json, Paginator? paginator = null)
        {
            List<Customer> customers = new();
            foreach (JsonElement element in json.EnumerateArray())
            {
                customers.Add(Customer.FromJson(element));
            }

            return new CustomerCollection(customers, paginator);
        }

        public static CustomerCollection From(Dictionary<string, object> data, Paginator? paginator = null)
        {
            return FromJson(JsonSerializer.Deserialize<JsonElement>(data), paginator);
        }
    }
}