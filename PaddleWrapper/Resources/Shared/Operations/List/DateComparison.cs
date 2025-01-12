namespace PaddleWrapper.Resources.Shared.Operations.List
{
    public class DateComparison
    {
        public DateTime Date { get; }

        public Comparator? Comparator { get; }

        public DateComparison(DateTime date, Comparator? comparator = null)
        {
            Date = date;
            Comparator = comparator;
        }

        public string GetComparatorString()
        {
            return Comparator.HasValue ? $"[{Comparator}]" : string.Empty;
        }

        public string GetFormattedDate()
        {
            return Date.ToString("O");
        }
    }
}