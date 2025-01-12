namespace PaddleWrapper.Resources.SimulationRuns.Operations
{
    public class GetSimulationRuns : IHasParameters
    {
        private readonly Includes[] _includes;

        public GetSimulationRuns(Includes[]? includes = null)
        {
            _includes = includes ?? Array.Empty<Includes>();
        }

        public IDictionary<string, object> GetParameters()
        {
            var parameters = new Dictionary<string, object>();

            if (_includes.Any())
            {
                parameters["include"] = string.Join(",", _includes.Select(i => i.ToString().ToLower()));
            }

            return parameters;
        }
    }
}