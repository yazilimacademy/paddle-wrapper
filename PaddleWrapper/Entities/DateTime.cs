namespace PaddleWrapper.Entities
{
    public class PaddleDateTime
    {
        private const string PADDLE_RFC3339 = "yyyy-MM-dd'T'HH:mm:ss.fffzzz";
        private readonly DateTime _dateTime;

        private PaddleDateTime(DateTime dateTime)
        {
            _dateTime = dateTime.ToUniversalTime();
        }

        public string Format(string? format = null)
        {
            return _dateTime.ToString(format ?? PADDLE_RFC3339);
        }

        public static PaddleDateTime? From(string dateStr)
        {
            if (dateStr == "0001-01-01T00:00:00Z")
            {
                return null;
            }

            try
            {
                return new PaddleDateTime(DateTime.Parse(dateStr).ToUniversalTime());
            }
            catch (Exception)
            {
                return null;
            }
        }

        public static PaddleDateTime? From(DateTime date)
        {
            return new PaddleDateTime(date.ToUniversalTime());
        }

        public static implicit operator DateTime(PaddleDateTime paddleDateTime)
        {
            return paddleDateTime._dateTime;
        }

        public static implicit operator PaddleDateTime(DateTime dateTime)
        {
            return new PaddleDateTime(dateTime);
        }

        public override string ToString()
        {
            return Format();
        }
    }
}