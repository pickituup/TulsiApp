using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.MVVM.Core;
using System.Windows.Input;
using Xamarin.Forms;
using Tulsi.NavigationFramework;
using Tulsi.Helpers;
using Tulsi.Model;

namespace Tulsi.ViewModels {
    public class BuyerRankingsViewModel : ViewModelBase, IViewModel {
        /// <summary>
        /// Public ctor.
        /// </summary>
        public BuyerRankingsViewModel() {
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

            DisplaySearchPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage);
            });
        }

        /// <summary>
        /// Display SearchPage command
        /// </summary>
        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public List<BuyerRanking> BuyerRankings { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose() {
            throw new NotImplementedException("BuyerRankingsViewModel.Dispose - not implemented");
        }
    }
}
