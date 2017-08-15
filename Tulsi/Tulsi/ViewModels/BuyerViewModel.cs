using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tulsi.ViewModels
{
    public class BuyerViewModel
    {
        public List<Transaction> TransactionsData { get; set; }
        public BuyerViewModel()
        {
                        TransactionsData = new List<Transaction>()
            {
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" },
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" },
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" },
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" }
            };
        }
    }
    public class Transaction
    {
        public string Code { get; set; }
        public string Number { get; set; }
        public string Quantity { get; set; }
    }
}
