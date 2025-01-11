using System.Collections.Generic;
using PaddleWrapper.Entities.Customer;

namespace PaddleWrapper.Entities.Collections
{
    public class CustomerCollection : Collection<Customer.Customer>
    {
        private CustomerCollection(List<Customer.Customer> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new CustomerCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            var items = new List<Customer.Customer>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(Customer.Customer.From((Dictionary<string, object>)item));
            }

            return new CustomerCollection(items, paginator);
        }
    }
} 