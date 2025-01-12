namespace PaddleWrapper.Resources.SimulationRuns.Operations
{
    public class GetSimulationRuns : IHasParameters
    {
        private readonly Includes[] _includes;

        public GetSimulationRuns(Includes[]? includes = null)
        {
            _includes = includes ?? Array.Empty<Includes>();
        }

        public Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> parameters = new();

            if (_includes.Any())
            {
                parameters.Add("include", string.Join(",", _includes.Select(i => i.ToString().ToLower())));
            }

            return parameters;
        }
    }
}