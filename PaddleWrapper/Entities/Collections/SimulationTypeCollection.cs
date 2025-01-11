namespace PaddleWrapper.Entities.Collections
{
    public class SimulationTypeCollection : Collection<SimulationType>
    {
        private SimulationTypeCollection(List<SimulationType> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new SimulationTypeCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            List<SimulationType> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(SimulationType.From((Dictionary<string, object>)item));
            }

            return new SimulationTypeCollection(items, paginator);
        }
    }
}