namespace PaddleWrapper.Entities.Collections
{
    public class ProductCollection : Collection<Product>
    {
        public ProductCollection(List<Product> items, Paginator paginator = null) 
            : base(items, paginator)
        {
        }

        public static ProductCollection FromList(IEnumerable<dynamic> itemsData, Paginator paginator = null)
        {
            var items = itemsData.Select(item => Product.FromDict(item)).ToList();
            return new ProductCollection(items, paginator);
        }
    }
} 