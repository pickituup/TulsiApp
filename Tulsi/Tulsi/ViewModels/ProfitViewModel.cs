using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tulsi.ViewModels
{
    public class ProfitViewModel
    {
        public List<ProfitChartModel> ChartData { get; set; }
        public Period ReportsPeriod { get; set; }
        public enum Period { Monthly, Quarterly, Weekly };
        public int Year { get; set; }

        public ProfitViewModel()
        {
            ChartData = new List<ProfitChartModel>()
            {
                new ProfitChartModel { Value = 420, Step = 1 },
                new ProfitChartModel { Value = 425, Step = 2 },
                new ProfitChartModel { Value = 425, Step = 3 },
                new ProfitChartModel { Value = 440, Step = 4 },
                new ProfitChartModel { Value = 420, Step = 5 },
                new ProfitChartModel { Value = 410, Step = 6 },
                new ProfitChartModel { Value = 408, Step = 7 },
                new ProfitChartModel { Value = 415, Step = 8 },
                new ProfitChartModel { Value = 425, Step = 9 },
            };

            Year = 2013;
            ReportsPeriod = Period.Monthly;
        }
    }
    public class ProfitChartModel
    {
        public double Value { get; set; }
        public int Step { get; set; }
    }
}
