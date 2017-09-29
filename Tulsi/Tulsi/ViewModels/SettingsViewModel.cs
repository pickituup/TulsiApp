using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tulsi.Helpers;
using Tulsi.Model;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Tulsi.Observers;
using Tulsi.SharedService;
using Xamarin.Forms;

namespace Tulsi.ViewModels {
    public sealed class SettingsViewModel : ViewModelBase, IViewModel {

        public bool IsImportedViewVisible { get; set; }

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

        bool _hasPasscode;
        public bool HasPasscode {
            get { return _hasPasscode; }
            set {
                if (SetProperty(ref _hasPasscode, value))

                    if (Spot != null) {
                        if (value) {
                            Spot.TranslateTo(0, 0, 700);
                            IsImportedViewVisible = value;
                        } else {
                            CanPasscodeOff();
                        }
                    }
            }
        }

        

        IView _importedView;
        public IView ImportedView {
            get { return _importedView; }
            set { SetProperty(ref _importedView, value); }
        }

        ContentView _spot;
        public ContentView Spot {
            get { return _spot; }
            set {
                if (SetProperty(ref _spot, value) && value != null)
                    HideView();
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
            HasPasscode = DependencyService.Get<ISQLiteService>().IsPasscodeExist();

            ImportedView = BaseSingleton<ViewSwitchingLogic>.Instance.GetViewByType(ViewType.PasscodeView);

            IsVisibleAmount = BaseSingleton<DashboardHelper>.Instance.HasSideMenuAmount;

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));

            SetupDashboardPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SetupDashboardPage));

            CurrencyItems = GetCurrencyItems();

            SelectedCurrencyItem = CurrencyItems.FirstOrDefault();

            MessagingCenter.Subscribe<string>(this, "exitView", AutoHideView);

            MessagingCenter.Subscribe<ResponseUnchekPasscode>(this, "disablePasscode", DisablePasscode);
        }

        private void CanPasscodeOff() {
            RequestUncheckPasscode request = new RequestUncheckPasscode { NeedToUncheck = true };
            MessagingCenter.Send(request, "canUnchekPasscodeRequest");

            Spot.TranslateTo(0, 0, 700);
            IsImportedViewVisible = true;
        }

        private void DisablePasscode(ResponseUnchekPasscode obj) {
            if (obj.CanUncheck)
                DependencyService.Get<ISQLiteService>().ClearPasscode();
        }

        private void AutoHideView(string obj) {
            HideView();
        }

        public async void CloseImportedView() {
            if (this.ImportedView != null) {
                await HideViewAsync();
                ImportedView.Dispose();
                ImportedView = null;
            }
        }

        public void NativeSenderCloseView() {
            HideView();
        }

        private async void HideView() => await HideViewAsync();

        private async Task HideViewAsync() {
            IsImportedViewVisible = false;
            int displayHeight = DependencyService.Get<IDisplaySize>().GetHeight();
            await Spot.TranslateTo(0, displayHeight, 700);
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
            if (ImportedView != null) {
                ImportedView.Dispose();
            }

            MessagingCenter.Unsubscribe<string>(this, "exitView");
        }
    }
}
