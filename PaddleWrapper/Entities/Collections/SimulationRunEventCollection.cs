using System.Collections.Generic;
using PaddleWrapper.Entities.Simulation;

namespace PaddleWrapper.Entities.Collections
{
    public class SimulationRunEventCollection : Collection<SimulationRunEvent>
    {
        private SimulationRunEventCollection(List<SimulationRunEvent> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new SimulationRunEventCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            var items = new List<SimulationRunEvent>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(SimulationRunEvent.From((Dictionary<string, object>)item));
            }

            return new SimulationRunEventCollection(items, paginator);
        }
    }
} 