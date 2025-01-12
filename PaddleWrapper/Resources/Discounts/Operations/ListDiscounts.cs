using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Resources.Discounts.Operations
{
    public class ListDiscounts : IHasParameters
    {
        private readonly Pager? _pager;
        private readonly List<string> _ids;
        private readonly List<Status> _statuses;
        private readonly List<string> _codes;

        public ListDiscounts(
            Pager? pager = null,
            IEnumerable<string>? ids = null,
            IEnumerable<Status>? statuses = null,
            IEnumerable<string>? codes = null)
        {
            _pager = pager;
            _ids = ids?.ToList() ?? new List<string>();
            _statuses = statuses?.ToList() ?? new List<Status>();
            _codes = codes?.ToList() ?? new List<string>();

            ValidateIds(_ids, "ids");
            ValidateIds(_codes, "codes");
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

            if (_codes.Any())
            {
                parameters["code"] = string.Join(",", _codes);
            }

            return parameters;
        }
    }
}