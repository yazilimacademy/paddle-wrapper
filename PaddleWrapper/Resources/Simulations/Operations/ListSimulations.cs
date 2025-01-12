using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Resources.Simulations.Operations
{
    public class ListSimulations : IHasParameters
    {
        private readonly Pager? _pager;
        private readonly string[] _notificationSettingIds;
        private readonly string[] _ids;
        private readonly SimulationStatus[] _statuses;

        public ListSimulations(
            Pager? pager = null,
            string[]? notificationSettingIds = null,
            string[]? ids = null,
            SimulationStatus[]? statuses = null)
        {
            _pager = pager;
            _notificationSettingIds = notificationSettingIds ?? Array.Empty<string>();
            _ids = ids ?? Array.Empty<string>();
            _statuses = statuses ?? Array.Empty<SimulationStatus>();
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

            if (_notificationSettingIds.Any())
            {
                parameters.Add("notification_setting_id", string.Join(",", _notificationSettingIds));
            }

            if (_ids.Any())
            {
                parameters.Add("id", string.Join(",", _ids));
            }

            if (_statuses.Any())
            {
                parameters.Add("status", string.Join(",", _statuses.Select(s => s.ToString().ToLower())));
            }

            return parameters;
        }
    }
}