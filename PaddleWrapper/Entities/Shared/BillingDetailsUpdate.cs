using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Shared
{
    public class BillingDetailsUpdate
    {
        [JsonPropertyName("enable_checkout")]
        public bool EnableCheckout { get; }

        [JsonPropertyName("purchase_order_number")]
        public string PurchaseOrderNumber { get; }

        [JsonPropertyName("additional_information")]
        public string AdditionalInformation { get; }

        [JsonPropertyName("payment_terms")]
        public TimePeriod PaymentTerms { get; }

        [JsonConstructor]
        public BillingDetailsUpdate(
            bool enableCheckout,
            string purchaseOrderNumber,
            string additionalInformation,
            TimePeriod paymentTerms)
        {
            EnableCheckout = enableCheckout;
            PurchaseOrderNumber = purchaseOrderNumber;
            AdditionalInformation = additionalInformation;
            PaymentTerms = paymentTerms;
        }
    }
} 