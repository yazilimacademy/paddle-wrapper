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
            List<Adjustment.Adjustment> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(Adjustment.Adjustment.From((Dictionary<string, object>)item));
            }

            return new AdjustmentCollection(items, paginator);
        }
    }
}