using System.Text.Json;

namespace PaddleWrapper.Entities.Subscriptions
{
    public class Item
    {
        public string PriceId { get; }
        public string Status { get; }
        public int Quantity { get; }
        public bool Recurring { get; }
        public DateTime? NextBilledAt { get; }
        public DateTime? TrialDates { get; }
        public Price Price { get; }

        public Item(
            string priceId,
            string status,
            int quantity,
            bool recurring,
            DateTime? nextBilledAt,
            DateTime? trialDates,
            Price price)
        {
            PriceId = priceId;
            Status = status;
            Quantity = quantity;
            Recurring = recurring;
            NextBilledAt = nextBilledAt;
            TrialDates = trialDates;
            Price = price;
        }

        public static Item FromDict(JsonElement data)
        {
            return new Item(
                priceId: data.GetProperty("price_id").GetString(),
                status: data.GetProperty("status").GetString(),
                quantity: data.GetProperty("quantity").GetInt32(),
                recurring: data.GetProperty("recurring").GetBoolean(),
                nextBilledAt: data.TryGetProperty("next_billed_at", out var nextBilled) ? 
                    DateTime.Parse(nextBilled.GetString()) : null,
                trialDates: data.TryGetProperty("trial_dates", out var trial) ? 
                    DateTime.Parse(trial.GetString()) : null,
                price: Price.FromDict(data.GetProperty("price"))
            );
        }
    }
} 