using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Resources.NotificationLogs.Operations
{
    public class ListNotificationLogs : IHasParameters
    {
        private readonly Pager? _pager;

        public ListNotificationLogs(Pager? pager = null)
        {
            _pager = pager;
        }

        public Dictionary<string, object> GetParameters()
        {
            return _pager?.GetParameters() ?? new Dictionary<string, object>();
        }
    }
}