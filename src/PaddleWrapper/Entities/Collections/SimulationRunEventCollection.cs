using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class SimulationRunEventCollection : Collection<SimulationRunEvent>
    {
        private SimulationRunEventCollection(List<SimulationRunEvent> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static SimulationRunEventCollection FromJson(JsonElement json, Paginator? paginator)
        {
            return From(JsonSerializer.Deserialize<Dictionary<string, object>>(json.GetRawText()), paginator);
        }

        public static new SimulationRunEventCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            List<SimulationRunEvent> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(SimulationRunEvent.From((Dictionary<string, object>)item));
            }

            return new SimulationRunEventCollection(items, paginator);
        }
    }
}