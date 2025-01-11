using System.Collections.Generic;
using PaddleWrapper.Entities.Simulation;

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
            var items = new List<SimulationType>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(SimulationType.From((Dictionary<string, object>)item));
            }

            return new SimulationTypeCollection(items, paginator);
        }
    }
} 