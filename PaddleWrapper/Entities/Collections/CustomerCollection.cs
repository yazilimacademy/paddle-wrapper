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
            var customers = new List<Customer>();
            foreach (var element in json.EnumerateArray())
            {
                customers.Add(Customer.FromJson(element));
            }

            return new CustomerCollection(customers, paginator);
        }
    }
}