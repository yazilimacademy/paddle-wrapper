using System.Collections.Generic;
using PaddleWrapper.Entities.Product;

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
            var items = new List<Product.Product>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(Product.Product.From((Dictionary<string, object>)item));
            }

            return new ProductCollection(items, paginator);
        }
    }
} 