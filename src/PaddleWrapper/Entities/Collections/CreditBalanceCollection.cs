using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class CreditBalanceCollection : Collection<CreditBalance>
    {
        public CreditBalanceCollection(List<CreditBalance> items, Paginator paginator = null) 
            : base(items, paginator)
        {
        }

        public static CreditBalanceCollection FromList(IEnumerable<JsonElement> itemsData, Paginator paginator = null)
        {
            var items = itemsData.Select(CreditBalance.FromDict).ToList();
            return new CreditBalanceCollection(items, paginator);
        }
    }
} 