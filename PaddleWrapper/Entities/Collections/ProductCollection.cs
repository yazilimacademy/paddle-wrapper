namespace PaddleWrapper.Entities.Collections
{
    public class ProductCollection : Collection<Product.Product>
    {
        private ProductCollection(List<Product.Product> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new ProductCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            List<Product.Product> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(Product.Product.From((Dictionary<string, object>)item));
            }

            return new ProductCollection(items, paginator);
        }
    }
}