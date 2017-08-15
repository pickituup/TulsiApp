using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tulsi.ViewModels
{
    public class StockPendingDetailsViewModel
    {

        public List<StockPendingDetail> StockPendingDetails { get; set; }
        public StockPendingDetailsViewModel()
        {
            StockPendingDetails = new List<StockPendingDetail>()
            {
                new StockPendingDetail { Name = "Balvinder Singh", Place="Gidravali", Number=6 },
                new StockPendingDetail { Name = "Sudhir Singh", Place="Abohar", Number=5 },
                new StockPendingDetail { Name = "Bahar Ali", Place="Ganganagar", Number=12 },
                new StockPendingDetail { Name = "Mukhi Singh", Place="Gidravali", Number=9 },
            };
        }
    }
    public class StockPendingDetail
    {
        public string Name { get; set; }
        public string Place { get; set; }
        public int Number { get; set; }
    }
}
