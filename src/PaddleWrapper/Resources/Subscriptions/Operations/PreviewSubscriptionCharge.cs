using PaddleWrapper.Notifications.Entities.Subscriptions;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Resources.Subscriptions.Operations;

public class PreviewSubscriptionCharge : IHasParameters
{
    [JsonPropertyName("items")]
    public List<SubscriptionItem> Items { get; set; }

    [JsonPropertyName("effective_from")]
    public DateTime? EffectiveFrom { get; set; }

    [JsonPropertyName("currency_code")]
    public string? CurrencyCode { get; set; }

    [JsonPropertyName("discount")]
    public SubscriptionDiscount? Discount { get; set; }

    public PreviewSubscriptionCharge(List<SubscriptionItem> items)
    {
        Items = items;
    }

    public IDictionary<string, object> GetParameters()
    {
        Dictionary<string, object> parameters = new();

        if (Items != null && Items.Any())
        {
            parameters.Add("items", Items);
        }

        if (EffectiveFrom.HasValue)
        {
            parameters.Add("effective_from", EffectiveFrom.Value);
        }

        if (!string.IsNullOrEmpty(CurrencyCode))
        {
            parameters.Add("currency_code", CurrencyCode);
        }

        if (Discount != null)
        {
            parameters.Add("discount", Discount);
        }

        return parameters;
    }
}