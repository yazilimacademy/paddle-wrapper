using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class SimulationRunCollection : Collection<SimulationRun>
    {
        private SimulationRunCollection(List<SimulationRun> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static SimulationRunCollection FromJson(JsonElement json, Paginator? paginator)
        {
            return From(JsonSerializer.Deserialize<Dictionary<string, object>>(json.GetRawText()), paginator);
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