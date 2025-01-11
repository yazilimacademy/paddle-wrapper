namespace PaddleWrapper.Entities.Collections
{
    public class DiscountCollection : Collection<Discount.Discount>
    {
        private DiscountCollection(List<Discount.Discount> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new DiscountCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            List<Discount.Discount> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(Discount.Discount.From((Dictionary<string, object>)item));
            }

            return new DiscountCollection(items, paginator);
        }
    }
}