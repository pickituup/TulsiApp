using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tulsi.ViewModels
{
    public class GrowerViewModel
    {
        public List<ChartModel> ChartData { get; set; }
        public List<Transaction> TransactionsData { get; set; }
        public GrowerViewModel()
        {
            ChartData = new List<ChartModel>()
            {
                new ChartModel { Name = "Paid", Value = 23 },
                new ChartModel { Name = "Due", Value = 77 }
            };
            TransactionsData = new List<Transaction>()
            {
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" },
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" },
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" },
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" },
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" },
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" }
            };
        }
    }
}
