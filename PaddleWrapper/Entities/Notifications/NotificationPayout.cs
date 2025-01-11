using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Notifications
{
    public class NotificationPayout
    {
        [JsonPropertyName("id")]
        public string Id { get; }

        [JsonPropertyName("status")]
        public NotificationPayoutStatus Status { get; }

        [JsonPropertyName("amount")]
        public string Amount { get; }

        [JsonPropertyName("currency_code")]
        public CurrencyCodePayouts CurrencyCode { get; }

        private NotificationPayout(
            string id,
            NotificationPayoutStatus status,
            string amount,
            CurrencyCodePayouts currencyCode)
        {
            Id = id;
            Status = status;
            Amount = amount;
            CurrencyCode = currencyCode;
        }

        public static NotificationPayout From(Dictionary<string, object> data)
        {
            return new NotificationPayout(
                id: (string)data["id"],
                status: Enum.Parse<NotificationPayoutStatus>((string)data["status"], true),
                amount: (string)data["amount"],
                currencyCode: Enum.Parse<CurrencyCodePayouts>((string)data["currency_code"], true)
            );
        }
    }
}