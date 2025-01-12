using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Resources.Customers.Operations
{
    public class ListCustomers : IHasParameters
    {
        private readonly Pager? _pager;
        private readonly List<string> _ids;
        private readonly List<Status> _statuses;
        private readonly string? _search;
        private readonly List<string> _emails;

        public ListCustomers(
            Pager? pager = null,
            IEnumerable<string>? ids = null,
            IEnumerable<Status>? statuses = null,
            string? search = null,
            IEnumerable<string>? emails = null)
        {
            _pager = pager;
            _ids = ids?.ToList() ?? new List<string>();
            _statuses = statuses?.ToList() ?? new List<Status>();
            _search = search;
            _emails = emails?.ToList() ?? new List<string>();

            ValidateIds(_ids, "ids");
            ValidateIds(_emails, "emails");
        }

        private void ValidateIds(List<string> ids, string paramName)
        {
            if (ids.Any(string.IsNullOrEmpty))
            {
                throw new ArgumentException($"{paramName} cannot contain null or empty values", paramName);
            }
        }

        public Dictionary<string, object> GetParameters()
        {
            Dictionary<string, object> parameters = _pager?.GetParameters() ?? new Dictionary<string, object>();

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

            if (_emails.Any())
            {
                parameters["email"] = string.Join(",", _emails);
            }

            return parameters;
        }
    }
}