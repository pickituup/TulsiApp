using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Tulsi.NavigationFramework;
using Tulsi.Helpers;
using Tulsi.MVVM.Core;
using Tulsi.Model;

namespace Tulsi.ViewModels
{
    public class BuyerViewModel : ViewModelBase, IViewModel
    {
        public BuyerViewModel()
        {
            TransactionsData = new List<Transaction>()
            {
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" },
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" },
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" },
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" }
            };

            DisplaySearchPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage);
            });

            DisplayBuyerRankingsPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.BuyerRankingsPage);
            });

            DisplayLatePaymentsPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.LatePaymentsPage);
            });
        }

        /// <summary>
        /// Display SearchPage command
        /// </summary>
        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        /// Display BuyerRankingsPage command
        /// </summary>
        public ICommand DisplayBuyerRankingsPageCommand { get; private set; }

        /// <summary>
        /// Display LatePaymentsPage page command
        /// </summary>
        public ICommand DisplayLatePaymentsPageCommand { get; private set; }

        /// <summary>
        /// Values are hard coded...
        /// </summary>
        public List<Transaction> TransactionsData { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose() {
            throw new NotImplementedException("BuyerViewModel.Dispose - not implemented");
        }
    }
}