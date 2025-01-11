namespace PaddleWrapper.Entities.Collections
{
    public class CustomerCollection : Collection<Customer>
    {
        private CustomerCollection(List<Customer> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new CustomerCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            List<Customer> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(Customer.From((Dictionary<string, object>)item));
            }

            return new CustomerCollection(items, paginator);
        }
    }
}