using PaddleWrapper.Entities.Notifications;
using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Resources.Notifications.Operations
{
    public class ListNotifications : IHasParameters
    {
        private readonly Pager? _pager;
        private readonly List<string> _notificationSettingIds;
        private readonly string? _search;
        private readonly List<NotificationStatus> _statuses;
        private readonly string? _filter;
        private readonly DateTime? _to;
        private readonly DateTime? _from;

        public ListNotifications(
            Pager? pager = null,
            IEnumerable<string>? notificationSettingIds = null,
            string? search = null,
            IEnumerable<NotificationStatus>? statuses = null,
            string? filter = null,
            DateTime? to = null,
            DateTime? from = null)
        {
            _pager = pager;
            _notificationSettingIds = notificationSettingIds?.ToList() ?? new List<string>();
            _search = search;
            _statuses = statuses?.ToList() ?? new List<NotificationStatus>();
            _filter = filter;
            _to = to;
            _from = from;

            ValidateIds(_notificationSettingIds, "notificationSettingIds");
        }

        private void ValidateIds(List<string> ids, string paramName)
        {
            if (ids.Any(string.IsNullOrEmpty))
            {
                throw new ArgumentException($"{paramName} cannot contain null or empty values", paramName);
            }
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

            if (_notificationSettingIds.Any())
            {
                parameters["notification_setting_id"] = string.Join(",", _notificationSettingIds);
            }

            if (!string.IsNullOrEmpty(_search))
            {
                parameters["search"] = _search;
            }

            if (_statuses.Any())
            {
                parameters["status"] = string.Join(",", _statuses.Select(s => s.ToString().ToLower()));
            }

            if (!string.IsNullOrEmpty(_filter))
            {
                parameters["filter"] = _filter;
            }

            if (_to.HasValue)
            {
                parameters["to"] = _to.Value.ToString("O");
            }

            if (_from.HasValue)
            {
                parameters["from"] = _from.Value.ToString("O");
            }

            return parameters;
        }
    }
}