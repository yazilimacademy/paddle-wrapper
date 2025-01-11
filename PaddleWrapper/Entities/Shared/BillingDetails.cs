using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class BillingDetails
    {
        [JsonPropertyName("enable_checkout")]
        public bool EnableCheckout { get; }

        [JsonPropertyName("payment_terms")]
        public TimePeriod PaymentTerms { get; }

        [JsonPropertyName("purchase_order_number")]
        public string? PurchaseOrderNumber { get; }

        [JsonPropertyName("additional_information")]
        public string? AdditionalInformation { get; }

        [JsonConstructor]
        public BillingDetails(
            bool enableCheckout,
            TimePeriod paymentTerms,
            string? purchaseOrderNumber = null,
            string? additionalInformation = null)
        {
            EnableCheckout = enableCheckout;
            PaymentTerms = paymentTerms;
            PurchaseOrderNumber = purchaseOrderNumber;
            AdditionalInformation = additionalInformation;
        }

        public static BillingDetails From(Dictionary<string, object> data)
        {
            return new BillingDetails(
                enableCheckout: (bool)data["enable_checkout"],
                paymentTerms: TimePeriod.From((Dictionary<string, object>)data["payment_terms"]),
                purchaseOrderNumber: data.ContainsKey("purchase_order_number") ? data["purchase_order_number"]?.ToString() : null,
                additionalInformation: data.ContainsKey("additional_information") ? data["additional_information"]?.ToString() : null
            );
        }
    }
} 