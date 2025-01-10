namespace PaddleWrapper.Entities.Shared
{
    public class Duration
    {
        public Interval Interval { get; }
        public int Frequency { get; }

        public Duration(Interval interval, int frequency)
        {
            Interval = interval;
            Frequency = frequency;
        }
    }
} 