using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Resources.Events.Operations
{
    public class ListEvents : IHasParameters
    {
        private readonly Pager? _pager;

        public ListEvents(Pager? pager = null)
        {
            _pager = pager;
        }

        public Dictionary<string, object> GetParameters()
        {
            return _pager?.GetParameters() ?? new Dictionary<string, object>();
        }
    }
}