using System.Text.Json;

namespace PaddleWrapper.Entities.Subscriptions
{
    public class BillingDetails
    {
        public bool EnableCheckout { get; }
        public string PaymentTerms { get; }
        public string PurchaseOrderNumber { get; }
        public string AdditionalInformation { get; }
        public string PaymentMethodId { get; }

        public BillingDetails(
            bool enableCheckout,
            string paymentTerms,
            string purchaseOrderNumber,
            string additionalInformation,
            string paymentMethodId)
        {
            EnableCheckout = enableCheckout;
            PaymentTerms = paymentTerms;
            PurchaseOrderNumber = purchaseOrderNumber;
            AdditionalInformation = additionalInformation;
            PaymentMethodId = paymentMethodId;
        }

        public static BillingDetails FromDict(JsonElement data)
        {
            return new BillingDetails(
                enableCheckout: data.GetProperty("enable_checkout").GetBoolean(),
                paymentTerms: data.TryGetProperty("payment_terms", out var terms) ? terms.GetString() : null,
                purchaseOrderNumber: data.TryGetProperty("purchase_order_number", out var po) ? po.GetString() : null,
                additionalInformation: data.TryGetProperty("additional_information", out var info) ? info.GetString() : null,
                paymentMethodId: data.TryGetProperty("payment_method_id", out var methodId) ? methodId.GetString() : null
            );
        }
    }
} 