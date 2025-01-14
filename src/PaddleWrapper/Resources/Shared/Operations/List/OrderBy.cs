namespace PaddleWrapper.Resources.Shared.Operations.List
{
    public sealed class OrderBy
    {
        private readonly string _field;
        private readonly string _direction;

        private OrderBy(string field, string direction)
        {
            _field = field;
            _direction = direction;
        }

        public static OrderBy IdAscending()
        {
            return new OrderBy("id", "asc");
        }

        public static OrderBy IdDescending()
        {
            return new OrderBy("id", "desc");
        }

        public override string ToString()
        {
            return $"{_field}[{_direction}]";
        }
    }
}