using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Resources.SimulationRunEvents.Operations
{
    public class ListSimulationRunEvents : IHasParameters
    {
        private readonly Pager? _pager;
        private readonly string[] _ids;

        public ListSimulationRunEvents(
            Pager? pager = null,
            string[]? ids = null)
        {
            _pager = pager;
            _ids = ids ?? Array.Empty<string>();
        }

        public IDictionary<string, object> GetParameters()
        {
            Dictionary<string, object> parameters = new();

            if (_pager != null)
            {
                foreach (KeyValuePair<string, object> param in _pager.GetParameters())
                {
                    parameters[param.Key] = param.Value;
                }
            }

            if (_ids.Any())
            {
                parameters["id"] = string.Join(",", _ids);
            }

            return parameters;
        }
    }
}