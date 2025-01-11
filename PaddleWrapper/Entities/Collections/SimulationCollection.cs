using System.Collections.Generic;
using PaddleWrapper.Entities.Simulation;

namespace PaddleWrapper.Entities.Collections
{
    public class SimulationCollection : Collection<Simulation>
    {
        private SimulationCollection(List<Simulation> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new SimulationCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            var items = new List<Simulation>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(Simulation.From((Dictionary<string, object>)item));
            }

            return new SimulationCollection(items, paginator);
        }
    }
} 