using System.Dynamic;

namespace BlazorSyncfusionCrm.Client.Pages
{
    public partial class Index
    {
        private List<string> countries = new List<string> { "South Korea", "India", "Germany", "Italy", "Russia" };
        private Random randomNum = new Random();
        public List<ExpandoObject> MedalDetails { get; set; } = new List<ExpandoObject>();


        public class ChartData
        {
            public DateTime XValue { get; set; }
            public double YValue { get; set; }
        }

        public List<ChartData> ConsumerReports = new List<ChartData>
        {
            new ChartData { XValue = new DateTime(2005, 01, 01), YValue = 21 },
            new ChartData { XValue = new DateTime(2006, 01, 01), YValue = 24 },
            new ChartData { XValue = new DateTime(2007, 01, 01), YValue = 36 },
            new ChartData { XValue = new DateTime(2008, 01, 01), YValue = 38 },
            new ChartData { XValue = new DateTime(2009, 01, 01), YValue = 54 },
            new ChartData { XValue = new DateTime(2010, 01, 01), YValue = 57 },
            new ChartData { XValue = new DateTime(2011, 01, 01), YValue = 70 },
        };


        protected override void OnInitialized()
        {
            MedalDetails = Enumerable.Range(0, 5).Select((x) =>
            {
                dynamic d = new ExpandoObject();
                d.X = countries[x];
                d.Y = randomNum.Next(20, 80);
                return d;
            }).Cast<ExpandoObject>().ToList<ExpandoObject>();
        }
    }
}
