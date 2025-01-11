using System.Collections.Generic;
using PaddleWrapper.Entities.Price;

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
            var items = new List<Price.Price>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(Price.Price.From((Dictionary<string, object>)item));
            }

            return new PriceCollection(items, paginator);
        }
    }
} 