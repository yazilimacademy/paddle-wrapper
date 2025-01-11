using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Transaction;

public class TransactionBreakdown
{
    [JsonPropertyName("credit")]
    public string Credit { get; }

    [JsonPropertyName("refund")] 
    public string Refund { get; }

    [JsonPropertyName("chargeback")]
    public string Chargeback { get; }

    private TransactionBreakdown(string credit, string refund, string chargeback)
    {
        Credit = credit;
        Refund = refund;
        Chargeback = chargeback;
    }

    public static TransactionBreakdown From(JsonElement data)
    {
        return new TransactionBreakdown(
            data.GetProperty("credit").GetString()!,
            data.GetProperty("refund").GetString()!,
            data.GetProperty("chargeback").GetString()!
        );
    }
} 