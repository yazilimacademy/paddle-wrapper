namespace PaddleWrapper.Notifications.Entities
{
    public class DateTime
    {
        private const string PADDLE_RFC3339 = "yyyy-MM-dd'T'HH:mm:ss.fffK";
        private readonly System.DateTime _value;

        private DateTime(System.DateTime value)
        {
            _value = value.ToUniversalTime();
        }

        public string Format(string? format = null)
        {
            return _value.ToString(format ?? PADDLE_RFC3339);
        }

        public static DateTime? FromString(string date)
        {
            if (date == "0001-01-01T00:00:00Z")
            {
                return null;
            }

            try
            {
                var parsedDate = System.DateTime.Parse(date).ToUniversalTime();
                return new DateTime(parsedDate);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static DateTime? Parse(string date)
        {
            return FromString(date);
        }

        public static DateTime? Parse(DateTime dateTime)
        {
            return dateTime;
        }

        public static implicit operator System.DateTime(DateTime paddleDateTime)
        {
            return paddleDateTime._value;
        }

        public static implicit operator DateTime(System.DateTime dateTime)
        {
            return new DateTime(dateTime);
        }
    }
} 