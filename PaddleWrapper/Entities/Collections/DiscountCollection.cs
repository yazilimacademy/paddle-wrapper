using System.Collections.Generic;
using PaddleWrapper.Entities.Discount;

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
            var items = new List<Discount.Discount>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(Discount.Discount.From((Dictionary<string, object>)item));
            }

            return new DiscountCollection(items, paginator);
        }
    }
} 