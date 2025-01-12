using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Resources.Reports.Operations
{
    public class ListReports : IHasParameters
    {
        private readonly Pager? _pager;
        private readonly ReportStatus[] _statuses;

        public ListReports(Pager? pager = null, ReportStatus[]? statuses = null)
        {
            _pager = pager;
            _statuses = statuses ?? Array.Empty<ReportStatus>();
        }

        public Dictionary<string, string> GetParameters()
        {
            Dictionary<string, string> parameters = new();

            if (_pager != null)
            {
                foreach (KeyValuePair<string, object> param in _pager.GetParameters())
                {
                    parameters.Add(param.Key, param.Value);
                }
            }

            if (_statuses.Any())
            {
                parameters.Add("status", string.Join(",", _statuses.Select(s => s.ToString().ToLower())));
            }

            return parameters;
        }
    }
}