using System.Text.Json;

namespace PaddleWrapper.Entities.Collections
{
    public class ReportCollection : Collection<Report>
    {
        private ReportCollection(List<Report> items, Paginator? paginator = null)
            : base(items, paginator)
        {
        }

        public static ReportCollection FromJson(JsonElement json, Paginator? paginator)
        {
            return From(JsonSerializer.Deserialize<Dictionary<string, object>>(json.GetRawText()), paginator);
        }

        public static new ReportCollection From(Dictionary<string, object> data, Paginator? paginator)
        {
            List<Report> items = new();
            object[] dataArray = (object[])data["data"];

            foreach (object item in dataArray)
            {
                items.Add(Report.From((Dictionary<string, object>)item));
            }

            return new ReportCollection(items, paginator);
        }
    }
}