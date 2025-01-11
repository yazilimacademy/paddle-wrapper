using System.Collections.Generic;
using PaddleWrapper.Entities.Report;

namespace PaddleWrapper.Entities.Collections
{
    public class ReportCollection : Collection<Report>
    {
        private ReportCollection(List<Report> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static new ReportCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            var items = new List<Report>();
            var dataArray = (object[])data["data"];

            foreach (var item in dataArray)
            {
                items.Add(Report.From((Dictionary<string, object>)item));
            }

            return new ReportCollection(items, paginator);
        }
    }
} 