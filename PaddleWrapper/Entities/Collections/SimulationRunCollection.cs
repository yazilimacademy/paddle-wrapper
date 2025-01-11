namespace PaddleWrapper.Entities.Collections
{
    public class SimulationRunCollection : Collection<SimulationRun>
    {
        private SimulationRunCollection(List<SimulationRun> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new SimulationRunCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            List<SimulationRun> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(SimulationRun.From((Dictionary<string, object>)item));
            }

            return new SimulationRunCollection(items, paginator);
        }
    }
}