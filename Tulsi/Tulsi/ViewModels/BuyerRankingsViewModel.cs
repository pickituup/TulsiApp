using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tulsi.ViewModels
{
    public class BuyerRankingsViewModel
    {
        public List<BuyerRanking> BuyerRankings { get; set; }
        public BuyerRankingsViewModel()
        {
            BuyerRankings = new List<BuyerRanking>()
            {
            new BuyerRanking { Name = "DFC Mickey", Rank=1, IsUp=true, Change=1 },
            new BuyerRanking { Name = "DFC Mickey", Rank=2, IsUp=true, Change=1 },
            new BuyerRanking { Name = "DFC Mickey", Rank=3, IsUp=false, Change=1 },
            new BuyerRanking { Name = "DFC Mickey", Rank=4, IsUp=false, Change=1 },
            new BuyerRanking { Name = "DFC Mickey", Rank=5, IsUp=true, Change=1 },
            new BuyerRanking { Name = "DFC Mickey", Rank=6, IsUp=true, Change=1 },
            new BuyerRanking { Name = "DFC Mickey", Rank=7, IsUp=true, Change=1 },
            new BuyerRanking { Name = "DFC Mickey", Rank=8, IsUp=true, Change=1 },
            };
        }
    }
    public class BuyerRanking
    {
        public string Name { get; set; }
        public int Rank { get; set; }
        public bool IsUp { get; set; }
        public int Change { get; set; }
    }
}
