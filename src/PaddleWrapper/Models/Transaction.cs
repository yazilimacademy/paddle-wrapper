using System.Text.Json.Serialization;

namespace PaddleWrapper.Models
{
    public class Transaction
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("customer_id")]
        public string CustomerId { get; set; }

        [JsonPropertyName("address_id")]
        public string AddressId { get; set; }

        [JsonPropertyName("business_id")]
        public string BusinessId { get; set; }

        [JsonPropertyName("currency_code")]
        public string CurrencyCode { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("billed_at")]
        public DateTime? BilledAt { get; set; }

        [JsonPropertyName("collection_mode")]
        public string CollectionMode { get; set; }

        [JsonPropertyName("invoice_number")]
        public string InvoiceNumber { get; set; }

        [JsonPropertyName("total_amount")]
        public decimal TotalAmount { get; set; }

        [JsonPropertyName("tax_amount")]
        public decimal TaxAmount { get; set; }

        [JsonPropertyName("subtotal")]
        public decimal Subtotal { get; set; }

        [JsonPropertyName("billing_details")]
        public BillingDetails BillingDetails { get; set; }

        [JsonPropertyName("items")]
        public TransactionItem[] Items { get; set; }
    }

    public class BillingDetails
    {
        [JsonPropertyName("payment_method")]
        public string PaymentMethod { get; set; }

        [JsonPropertyName("payment_method_details")]
        public object PaymentMethodDetails { get; set; }
    }

    public class TransactionItem
    {
        [JsonPropertyName("price_id")]
        public string PriceId { get; set; }

        [JsonPropertyName("quantity")]
        public int Quantity { get; set; }

        [JsonPropertyName("amount")]
        public decimal Amount { get; set; }

        [JsonPropertyName("tax_amount")]
        public decimal TaxAmount { get; set; }
    }
}