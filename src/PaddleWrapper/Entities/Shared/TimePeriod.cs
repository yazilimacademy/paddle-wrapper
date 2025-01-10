namespace PaddleWrapper.Entities.Shared
{
    public class TimePeriod
    {
        public DateTime StartsAt { get; }
        public DateTime EndsAt { get; }

        public TimePeriod(DateTime startsAt, DateTime endsAt)
        {
            StartsAt = startsAt;
            EndsAt = endsAt;
        }

        public static TimePeriod FromDict(JsonElement data)
        {
            return new TimePeriod(
                DateTime.Parse(data.GetProperty("starts_at").GetString()),
                DateTime.Parse(data.GetProperty("ends_at").GetString())
            );
        }
    }
} 