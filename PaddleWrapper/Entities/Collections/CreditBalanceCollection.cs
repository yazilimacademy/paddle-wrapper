using System.Collections.Generic;
using PaddleWrapper.Entities.Credit;

namespace PaddleWrapper.Entities.Collections
{
    public class CreditBalanceCollection : Collection<CreditBalance>
    {
        private CreditBalanceCollection(List<CreditBalance> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new CreditBalanceCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            var items = new List<CreditBalance>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(CreditBalance.From((Dictionary<string, object>)item));
            }

            return new CreditBalanceCollection(items, paginator);
        }
    }
} 