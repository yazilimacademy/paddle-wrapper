using System.Text.Json;

namespace PaddleWrapper.Entities.Shared
{
    public class PriceQuantity
    {
        public int Minimum { get; }
        public int Maximum { get; }

        public PriceQuantity(int minimum, int maximum)
        {
            Minimum = minimum;
            Maximum = maximum;
        }
    }
} 