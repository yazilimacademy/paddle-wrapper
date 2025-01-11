namespace PaddleWrapper.Entities.Collections
{
    public class AddressCollection : Collection<Address>
    {
        private AddressCollection(List<Address> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new AddressCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            var items = new List<Address>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(Address.From((Dictionary<string, object>)item));
            }

            return new AddressCollection(items, paginator);
        }
    }
} 