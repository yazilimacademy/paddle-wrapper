using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Resources.Businesses.Operations
{
    public class ListBusinesses : IHasParameters
    {
        private readonly Pager? _pager;
        private readonly List<string> _ids;
        private readonly List<Status> _statuses;
        private readonly string? _search;

        public ListBusinesses(
            Pager? pager = null,
            IEnumerable<string>? ids = null,
            IEnumerable<Status>? statuses = null,
            string? search = null)
        {
            _pager = pager;
            _ids = ids?.ToList() ?? new List<string>();
            _statuses = statuses?.ToList() ?? new List<Status>();
            _search = search;

            if (_ids.Any(string.IsNullOrEmpty))
            {
                throw new ArgumentException("IDs cannot contain null or empty values", nameof(ids));
            }
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

            if (_statuses.Any())
            {
                parameters["status"] = string.Join(",", _statuses);
            }

            if (!string.IsNullOrEmpty(_search))
            {
                parameters["search"] = _search;
            }

            return parameters;
        }
    }
}