using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tulsi.Helpers;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Tulsi.Observers;
using Xamarin.Forms;

namespace Tulsi.ViewModels {
    public sealed class SetupDashboardViewModel : ViewModelBase, IViewModel {

        bool _hasTodayBalance;
        public bool HasTodayBalance {
            get { return _hasTodayBalance; }
            set {
                if (SetProperty(ref _hasTodayBalance, value)) {
                    BaseSingleton<DashboardHelper>.Instance.HasTodayBalance = value;
                    BaseSingleton<DashboardObserver>.Instance.OnVisibleTodayBalance(value);
                }
            }
        }

        bool _hasColdStoire;
        public bool HasColdStoire {
            get { return _hasColdStoire; }
            set {
                if (SetProperty(ref _hasColdStoire, value)) {
                    BaseSingleton<DashboardHelper>.Instance.HasColdStoire = value;
                    BaseSingleton<DashboardObserver>.Instance.OnVisibleColdStoire(value);
                }
            }
        }

        bool _hasLadaan;
        public bool HasLadaan {
            get { return _hasLadaan; }
            set {
                if (SetProperty(ref _hasLadaan, value)) {
                    BaseSingleton<DashboardHelper>.Instance.HasLadaan = value;
                    BaseSingleton<DashboardObserver>.Instance.OnVisibleLadaan(value);
                }
            }
        }

        bool _hasTodayRates;
        public bool HasTodayRates {
            get { return _hasTodayRates; }
            set {
                if (SetProperty(ref _hasTodayRates, value)) {
                    BaseSingleton<DashboardHelper>.Instance.HasTodayRates = value;
                    BaseSingleton<DashboardObserver>.Instance.OnVisibleTodayRates(value);
                }
            }
        }

        bool _hasBuyerSummary;
        public bool HasBuyerSummary {
            get { return _hasBuyerSummary; }
            set {
                if (SetProperty(ref _hasBuyerSummary, value)) {
                    BaseSingleton<DashboardHelper>.Instance.HasBuyerSummary = value;
                    BaseSingleton<DashboardObserver>.Instance.OnVisibleBuyerSummary(value);
                }
            }
        }

        // Navigate to Search page.
        public ICommand DisplaySearchPageCommand { get; private set; }

        // Navigate back.
        public ICommand NavigateBackCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public SetupDashboardViewModel() {
            HasTodayBalance = BaseSingleton<DashboardHelper>.Instance.HasTodayBalance;

            HasColdStoire = BaseSingleton<DashboardHelper>.Instance.HasColdStoire;

            HasLadaan = BaseSingleton<DashboardHelper>.Instance.HasLadaan;

            HasTodayRates = BaseSingleton<DashboardHelper>.Instance.HasTodayRates;

            HasBuyerSummary = BaseSingleton<DashboardHelper>.Instance.HasBuyerSummary;

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));

            NavigateBackCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());
        }

        public void Dispose() {

        }
    }
}
