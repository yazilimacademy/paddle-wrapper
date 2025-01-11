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
            List<Address> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(Address.From((Dictionary<string, object>)item));
            }

            return new AddressCollection(items, paginator);
        }
    }
}