using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Resources.SimulationRuns.Operations
{
    public class ListSimulationRuns : IHasParameters
    {
        private readonly Pager? _pager;
        private readonly string[] _ids;
        private readonly Includes[] _includes;

        public ListSimulationRuns(
            Pager? pager = null,
            string[]? ids = null,
            Includes[]? includes = null)
        {
            _pager = pager;
            _ids = ids ?? Array.Empty<string>();
            _includes = includes ?? Array.Empty<Includes>();
        }

        public IDictionary<string, object> GetParameters()
        {
            var parameters = new Dictionary<string, object>();

            if (_pager != null)
            {
                foreach (var param in _pager.GetParameters())
                {
                    parameters[param.Key] = param.Value;
                }
            }

            if (_ids.Any())
            {
                parameters["id"] = string.Join(",", _ids);
            }

            if (_includes.Any())
            {
                parameters["include"] = string.Join(",", _includes.Select(i => i.ToString().ToLower()));
            }

            return parameters;
        }
    }
}