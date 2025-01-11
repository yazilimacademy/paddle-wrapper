using System;
using System.Collections.Generic;
using System.Linq;
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

        public Dictionary<string, string> GetParameters()
        {
            var parameters = new Dictionary<string, string>();

            if (_pager != null)
            {
                foreach (var param in _pager.GetParameters())
                {
                    parameters.Add(param.Key, param.Value);
                }
            }

            if (_ids.Any())
            {
                parameters.Add("id", string.Join(",", _ids));
            }

            if (_includes.Any())
            {
                parameters.Add("include", string.Join(",", _includes.Select(i => i.ToString().ToLower())));
            }

            return parameters;
        }
    }
} 