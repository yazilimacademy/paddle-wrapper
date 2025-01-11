namespace PaddleWrapper.Entities.Collections
{
    public class PriceCollection : Collection<Price.Price>
    {
        private PriceCollection(List<Price.Price> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new PriceCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            List<Price.Price> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(Price.Price.From((Dictionary<string, object>)item));
            }

            return new PriceCollection(items, paginator);
        }
    }
}