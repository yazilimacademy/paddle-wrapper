using System.Text.Json;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities.Transactions
{
    public class PaymentMethodDetails
    {
        public PaymentMethodType Type { get; }
        public JsonElement CardDetails { get; }

        public PaymentMethodDetails(PaymentMethodType type, JsonElement cardDetails)
        {
            Type = type;
            CardDetails = cardDetails;
        }

        public static PaymentMethodDetails FromDict(JsonElement data)
        {
            return new PaymentMethodDetails(
                type: Enum.Parse<PaymentMethodType>(data.GetProperty("type").GetString()),
                cardDetails: data.GetProperty("card")
            );
        }
    }
} 