using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Transactions
{
    public class TransactionBreakdown
    {
        [JsonPropertyName("credit")]
        public string Credit { get; }

        [JsonPropertyName("refund")]
        public string Refund { get; }

        [JsonPropertyName("chargeback")]
        public string Chargeback { get; }

        private TransactionBreakdown(
            string credit,
            string refund,
            string chargeback)
        {
            Credit = credit;
            Refund = refund;
            Chargeback = chargeback;
        }

        public static TransactionBreakdown From(Dictionary<string, object> data)
        {
            return new TransactionBreakdown(
                credit: (string)data["credit"],
                refund: (string)data["refund"],
                chargeback: (string)data["chargeback"]
            );
        }
    }
}