using PaddleWrapper.Notifications.Entities.Shared;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Notifications.Entities.Transactions;

public class TransactionDetails
{
    [JsonPropertyName("tax_rates_used")]
    public IReadOnlyList<TaxRatesUsed> TaxRatesUsed { get; }

    [JsonPropertyName("totals")]
    public TransactionTotals Totals { get; }

    [JsonPropertyName("adjusted_totals")]
    public TransactionTotalsAdjusted? AdjustedTotals { get; }

    [JsonPropertyName("payout_totals")]
    public TransactionPayoutTotals? PayoutTotals { get; }

    [JsonPropertyName("adjusted_payout_totals")]
    public TransactionPayoutTotalsAdjusted? AdjustedPayoutTotals { get; }

    [JsonPropertyName("line_items")]
    public IReadOnlyList<TransactionLineItem> LineItems { get; }

    private TransactionDetails(
        IReadOnlyList<TaxRatesUsed> taxRatesUsed,
        TransactionTotals totals,
        TransactionTotalsAdjusted? adjustedTotals,
        TransactionPayoutTotals? payoutTotals,
        TransactionPayoutTotalsAdjusted? adjustedPayoutTotals,
        IReadOnlyList<TransactionLineItem> lineItems)
    {
        TaxRatesUsed = taxRatesUsed;
        Totals = totals;
        AdjustedTotals = adjustedTotals;
        PayoutTotals = payoutTotals;
        AdjustedPayoutTotals = adjustedPayoutTotals;
        LineItems = lineItems;
    }

    public static TransactionDetails FromJson(JsonElement data)
    {
        List<TaxRatesUsed> taxRatesUsed = new();
        foreach (JsonElement taxRateUsed in data.GetProperty("tax_rates_used").EnumerateArray())
        {
            taxRatesUsed.Add(Shared.TaxRatesUsed.FromJson(taxRateUsed));
        }

        List<TransactionLineItem> lineItems = new();
        foreach (JsonElement lineItem in data.GetProperty("line_items").EnumerateArray())
        {
            lineItems.Add(TransactionLineItem.FromJson(lineItem));
        }

        return new TransactionDetails(
            taxRatesUsed,
            TransactionTotals.FromJson(data.GetProperty("totals")),
            data.TryGetProperty("adjusted_totals", out JsonElement adjustedTotals) ? TransactionTotalsAdjusted.FromJson(adjustedTotals) : null,
            data.TryGetProperty("payout_totals", out JsonElement payoutTotals) ? TransactionPayoutTotals.FromJson(payoutTotals) : null,
            data.TryGetProperty("adjusted_payout_totals", out JsonElement adjustedPayoutTotals) ? TransactionPayoutTotalsAdjusted.FromJson(adjustedPayoutTotals) : null,
            lineItems);
    }
}