using System.Text.Json;

namespace PaddleWrapper.Entities.Subscriptions
{
    public class ScheduledChange
    {
        public string Action { get; }
        public DateTime EffectiveAt { get; }
        public bool ResumeAt { get; }
        public List<Item> Items { get; }

        public ScheduledChange(
            string action,
            DateTime effectiveAt,
            bool resumeAt,
            List<Item> items)
        {
            Action = action;
            EffectiveAt = effectiveAt;
            ResumeAt = resumeAt;
            Items = items;
        }

        public static ScheduledChange FromDict(JsonElement data)
        {
            return new ScheduledChange(
                action: data.GetProperty("action").GetString(),
                effectiveAt: DateTime.Parse(data.GetProperty("effective_at").GetString()),
                resumeAt: data.GetProperty("resume_at").GetBoolean(),
                items: data.GetProperty("items").EnumerateArray()
                    .Select(Item.FromDict)
                    .ToList()
            );
        }
    }
} 