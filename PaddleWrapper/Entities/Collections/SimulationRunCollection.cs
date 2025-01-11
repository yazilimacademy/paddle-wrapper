using System.Collections.Generic;
using PaddleWrapper.Entities.Simulation;

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
            var items = new List<SimulationRun>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(SimulationRun.From((Dictionary<string, object>)item));
            }

            return new SimulationRunCollection(items, paginator);
        }
    }
} 