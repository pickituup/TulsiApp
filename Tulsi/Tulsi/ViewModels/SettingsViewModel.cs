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
    public sealed class SettingsViewModel : ViewModelBase, IViewModel {

        bool _isVisibleAmount;
        public bool IsVisibleAmount {
            get { return _isVisibleAmount; }
            set {
                if (SetProperty(ref _isVisibleAmount, value)) {
                    BaseSingleton<DashboardObserver>.Instance.OnHideAmount(value);
                    BaseSingleton<DashboardHelper>.Instance.HasSideMenuAmount = value;
                }
            }
        }

        List<string> _currencyItems;
        public List<string> CurrencyItems {
            get { return _currencyItems; }
            set { SetProperty(ref _currencyItems, value); }
        }

        string _currentCurrency;
        public string CurrentCurrency {
            get { return _currentCurrency; }
            set {
                _currentCurrency = value;
                OnPropertyChanged();
            }
        }

        string _selectedCurrencyItem;
        public string SelectedCurrencyItem {
            get { return _selectedCurrencyItem; }
            set {
                SetProperty(ref _selectedCurrencyItem, value);

                CurrentCurrency = value;
            }
        }

        public ICommand SetupDashboardPageCommand { get; private set; }

        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public SettingsViewModel() {
            IsVisibleAmount = BaseSingleton<DashboardHelper>.Instance.HasSideMenuAmount;

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));

            SetupDashboardPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SetupDashboardPage));

            CurrencyItems = GetCurrencyItems();

            SelectedCurrencyItem = CurrencyItems.FirstOrDefault();
        }

        private List<string> GetCurrencyItems() {
            return new List<string>() {
                "INR",
                "USD",
                "EUR",
                "GBR"
            };
        }

        public void Dispose() {
        }
    }
}
