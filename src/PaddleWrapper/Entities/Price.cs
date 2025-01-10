using System.Text.Json;
using PaddleWrapper.Entities.Shared;

namespace PaddleWrapper.Entities
{
    public class Price : Entity
    {
        public string Description { get; }
        public string ProductId { get; }
        public string BillingCycle { get; }
        public Money UnitPrice { get; }
        public PriceQuantity Quantity { get; }
        public TaxMode TaxMode { get; }
        public UnitPriceOverride[] UnitPriceOverrides { get; }
        public CustomData CustomData { get; }
        public Status Status { get; }
        public DateTime CreatedAt { get; }
        public DateTime UpdatedAt { get; }

        public Price(
            string id,
            string description,
            string productId,
            string billingCycle,
            Money unitPrice,
            PriceQuantity quantity,
            TaxMode taxMode,
            UnitPriceOverride[] unitPriceOverrides,
            CustomData customData,
            Status status,
            DateTime createdAt,
            DateTime updatedAt)
        {
            Id = id;
            Description = description;
            ProductId = productId;
            BillingCycle = billingCycle;
            UnitPrice = unitPrice;
            Quantity = quantity;
            TaxMode = taxMode;
            UnitPriceOverrides = unitPriceOverrides;
            CustomData = customData;
            Status = status;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static Price FromDict(JsonElement data)
        {
            var unitPriceData = data.GetProperty("unit_price");
            var unitPrice = new Money(
                unitPriceData.GetProperty("amount").GetString(),
                Enum.Parse<CurrencyCode>(unitPriceData.GetProperty("currency_code").GetString())
            );

            var quantityData = data.GetProperty("quantity");
            var quantity = new PriceQuantity(
                quantityData.GetProperty("minimum").GetInt32(),
                quantityData.GetProperty("maximum").GetInt32()
            );

            var overrides = data.GetProperty("unit_price_overrides").EnumerateArray()
                .Select(UnitPriceOverride.FromDict)
                .ToArray();

            return new Price(
                id: data.GetProperty("id").GetString(),
                description: data.GetProperty("description").GetString(),
                productId: data.GetProperty("product_id").GetString(),
                billingCycle: data.GetProperty("billing_cycle").GetString(),
                unitPrice: unitPrice,
                quantity: quantity,
                taxMode: Enum.Parse<TaxMode>(data.GetProperty("tax_mode").GetString()),
                unitPriceOverrides: overrides,
                customData: data.TryGetProperty("custom_data", out var customData) ? new CustomData(customData) : null,
                status: Enum.Parse<Status>(data.GetProperty("status").GetString()),
                createdAt: DateTime.Parse(data.GetProperty("created_at").GetString()),
                updatedAt: DateTime.Parse(data.GetProperty("updated_at").GetString())
            );
        }
    }
} 