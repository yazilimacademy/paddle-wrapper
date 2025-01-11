using System.Collections.Generic;
using PaddleWrapper.Entities.Business;

namespace PaddleWrapper.Entities.Collections
{
    public class BusinessCollection : Collection<Business.Business>
    {
        private BusinessCollection(List<Business.Business> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new BusinessCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            var items = new List<Business.Business>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(Business.Business.From((Dictionary<string, object>)item));
            }

            return new BusinessCollection(items, paginator);
        }
    }
} 