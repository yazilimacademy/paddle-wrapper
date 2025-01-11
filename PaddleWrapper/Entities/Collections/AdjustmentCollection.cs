using System.Collections.Generic;
using PaddleWrapper.Entities.Adjustment;

namespace PaddleWrapper.Entities.Collections
{
    public class AdjustmentCollection : Collection<Adjustment.Adjustment>
    {
        private AdjustmentCollection(List<Adjustment.Adjustment> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new AdjustmentCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            var items = new List<Adjustment.Adjustment>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(Adjustment.Adjustment.From((Dictionary<string, object>)item));
            }

            return new AdjustmentCollection(items, paginator);
        }
    }
} 