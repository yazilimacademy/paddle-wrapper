using System.Collections.Generic;
using PaddleWrapper.Entities.Shared;
using PaddleWrapper.Resources.Shared.Operations.List;

namespace PaddleWrapper.Resources.Adjustments.Operations
{
    public class GetAdjustmentCreditNote : IHasParameters
    {
        private readonly Disposition? _disposition;

        public GetAdjustmentCreditNote(Disposition? disposition = null)
        {
            _disposition = disposition;
        }

        public Dictionary<string, object> GetParameters()
        {
            var parameters = new Dictionary<string, object>();

            if (_disposition.HasValue)
            {
                parameters["disposition"] = _disposition.Value;
            }

            return parameters;
        }
    }
} 