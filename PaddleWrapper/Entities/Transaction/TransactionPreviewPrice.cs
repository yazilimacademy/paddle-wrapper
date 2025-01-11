using PaddleWrapper.Entities.Shared;
using System.Text.Json.Serialization;

namespace PaddleWrapper.Entities.Transaction
{
    public class TransactionPreviewPrice
    {
        [JsonPropertyName("id")]
        public string? Id { get; }

        [JsonPropertyName("product_id")]
        public string? ProductId { get; }

        [JsonPropertyName("name")]
        public string? Name { get; }

        [JsonPropertyName("description")]
        public string Description { get; }

        [JsonPropertyName("type")]
        public CatalogType? Type { get; }

        [JsonPropertyName("billing_cycle")]
        public TimePeriod? BillingCycle { get; }

        [JsonPropertyName("trial_period")]
        public TimePeriod? TrialPeriod { get; }

        [JsonPropertyName("tax_mode")]
        public TaxMode TaxMode { get; }

        [JsonPropertyName("unit_price")]
        public Money UnitPrice { get; }

        [JsonPropertyName("unit_price_overrides")]
        public IReadOnlyList<UnitPriceOverride> UnitPriceOverrides { get; }

        [JsonPropertyName("quantity")]
        public PriceQuantity Quantity { get; }

        [JsonPropertyName("status")]
        public Status Status { get; }

        [JsonPropertyName("custom_data")]
        public CustomData? CustomData { get; }

        [JsonPropertyName("import_meta")]
        public ImportMeta? ImportMeta { get; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; }

        private TransactionPreviewPrice(
            string? id,
            string? productId,
            string? name,
            string description,
            CatalogType? type,
            TimePeriod? billingCycle,
            TimePeriod? trialPeriod,
            TaxMode taxMode,
            Money unitPrice,
            IReadOnlyList<UnitPriceOverride> unitPriceOverrides,
            PriceQuantity quantity,
            Status status,
            CustomData? customData,
            ImportMeta? importMeta,
            DateTime createdAt,
            DateTime updatedAt)
        {
            Id = id;
            ProductId = productId;
            Name = name;
            Description = description;
            Type = type;
            BillingCycle = billingCycle;
            TrialPeriod = trialPeriod;
            TaxMode = taxMode;
            UnitPrice = unitPrice;
            UnitPriceOverrides = unitPriceOverrides;
            Quantity = quantity;
            Status = status;
            CustomData = customData;
            ImportMeta = importMeta;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static TransactionPreviewPrice From(Dictionary<string, object> data)
        {
            List<UnitPriceOverride> unitPriceOverrides = new();
            if (data.ContainsKey("unit_price_overrides"))
            {
                object[] overridesData = (object[])data["unit_price_overrides"];
                foreach (object item in overridesData)
                {
                    unitPriceOverrides.Add(UnitPriceOverride.From((Dictionary<string, object>)item));
                }
            }

            return new TransactionPreviewPrice(
                id: data.ContainsKey("id") ? (string?)data["id"] : null,
                productId: data.ContainsKey("product_id") ? (string?)data["product_id"] : null,
                name: data.ContainsKey("name") ? (string?)data["name"] : null,
                description: (string)data["description"],
                type: data.ContainsKey("type") ? System.Enum.Parse<CatalogType>((string)data["type"], true) : null,
                billingCycle: data.ContainsKey("billing_cycle") ? TimePeriod.From((Dictionary<string, object>)data["billing_cycle"]) : null,
                trialPeriod: data.ContainsKey("trial_period") ? TimePeriod.From((Dictionary<string, object>)data["trial_period"]) : null,
                taxMode: System.Enum.Parse<TaxMode>((string)data["tax_mode"], true),
                unitPrice: Money.From((Dictionary<string, object>)data["unit_price"]),
                unitPriceOverrides: unitPriceOverrides,
                quantity: PriceQuantity.From((Dictionary<string, object>)data["quantity"]),
                status: System.Enum.Parse<Status>((string)data["status"], true),
                customData: data.ContainsKey("custom_data") ? CustomData.From((Dictionary<string, object>)data["custom_data"]) : null,
                importMeta: data.ContainsKey("import_meta") ? ImportMeta.From((Dictionary<string, object>)data["import_meta"]) : null,
                createdAt: DateTime.Parse((string)data["created_at"]),
                updatedAt: DateTime.Parse((string)data["updated_at"])
            );
        }
    }
}