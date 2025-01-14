using PaddleWrapper.Notifications.Entities.Subscriptions;
using PaddleWrapper.Resources.Subscriptions.Operations.Update;
using System.Text.Json.Serialization;
using SubscriptionDiscount = PaddleWrapper.Resources.Subscriptions.Operations.Update.SubscriptionDiscount;

namespace PaddleWrapper.Resources.Subscriptions.Operations;

public class PreviewSubscriptionUpdate : IHasParameters
{
    [JsonPropertyName("billing_cycle")]
    public BillingCycle? BillingCycle { get; set; }

    [JsonPropertyName("scheduled_change")]
    public ScheduledChange? ScheduledChange { get; set; }

    [JsonPropertyName("items")]
    public List<SubscriptionItem>? Items { get; set; }

    [JsonPropertyName("currency_code")]
    public string? CurrencyCode { get; set; }

    [JsonPropertyName("discount")]
    public SubscriptionDiscount? Discount { get; set; }

    [JsonPropertyName("custom_data")]
    public Dictionary<string, string>? CustomData { get; set; }

    public IDictionary<string, object> GetParameters()
    {
        Dictionary<string, object> parameters = new();

        if (BillingCycle != null)
        {
            parameters.Add("billing_cycle", BillingCycle);
        }

        if (ScheduledChange != null)
        {
            parameters.Add("scheduled_change", ScheduledChange);
        }

        if (Items != null && Items.Any())
        {
            parameters.Add("items", Items);
        }

        if (!string.IsNullOrEmpty(CurrencyCode))
        {
            parameters.Add("currency_code", CurrencyCode);
        }

        if (Discount != null)
        {
            parameters.Add("discount", Discount);
        }

        if (CustomData != null && CustomData.Any())
        {
            parameters.Add("custom_data", CustomData);
        }

        return parameters;
    }
}