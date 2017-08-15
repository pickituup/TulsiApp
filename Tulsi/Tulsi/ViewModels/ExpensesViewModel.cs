using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tulsi.ViewModels
{
   public class ExpensesViewModel
    {
        public List<ChartModel> ChartData { get; set; }
        public List<Transaction> TransactionsData { get; set; }
        public ExpensesViewModel()
        {
            ChartData = new List<ChartModel>()
            {
                new ChartModel { Name = "Groceries", Value = 29 },
                new ChartModel { Name = "Utilities", Value = 16 },
                new ChartModel { Name = "Car", Value = 14 },
                new ChartModel { Name = "Payments", Value = 12 },
                new ChartModel { Name = "iTunes", Value = 10 },
                new ChartModel { Name = "House", Value = 8 },
                new ChartModel { Name = "Wardrobe", Value = 6 },
                new ChartModel { Name = "Food", Value = 5 },
            };
        }
    }
    public class ExpensesChartModel
    {
        public string Name { get; set; }

        public string Value { get; set; }
    }
}
