using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tulsi.Helpers;
using Tulsi.Model;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Tulsi.Observers;
using Tulsi.Observers.DashboardArgs;
using Xamarin.Forms;

namespace Tulsi.ViewModels {
    public class DashboardPageViewModel : ViewModelBase, IViewModel {

        bool _hasTodayBalance;
        public bool HasTodayBalance {
            get { return _hasTodayBalance; }
            set { SetProperty(ref _hasTodayBalance, value); }
        }

        bool _hasColdStoire;
        public bool HasColdStoire {
            get { return _hasColdStoire; }
            set { SetProperty(ref _hasColdStoire, value); }
        }

        bool _hasLadaan;
        public bool HasLadaan {
            get { return _hasLadaan; }
            set { SetProperty(ref _hasLadaan, value); }
        }

        bool _hasTodayRates;
        public bool HasTodayRates {
            get { return _hasTodayRates; }
            set { SetProperty(ref _hasTodayRates, value); }
        }

        bool _hasBuyerSummary;
        public bool HasBuyerSummary {
            get { return _hasBuyerSummary; }
            set { SetProperty(ref _hasBuyerSummary, value); }
        }

        ObservableCollection<ChartModel> _chartData;
        public ObservableCollection<ChartModel> ChartData {
            get { return _chartData; }
            set { SetProperty(ref _chartData, value); }
        }

        ObservableCollection<NewsModel> _newsData;
        public ObservableCollection<NewsModel> NewsData {
            get { return _newsData; }
            set { SetProperty(ref _newsData, value); }
        }

        public ICommand DisplaySearchPageCommand { get; private set; }

        public ICommand DisplayLaddanPageCommand { get; private set; }

        public ICommand DisplayTodayRatePageCommand { get; private set; }

        public ICommand DisplayBuyerPageCommand { get; private set; }

        public ICommand DisplayColdStorePageCommand { get; private set; }

        public ICommand DisplayGodownPageCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public DashboardPageViewModel() {
            HasTodayBalance = BaseSingleton<DashboardHelper>.Instance.HasTodayBalance;

            HasColdStoire = BaseSingleton<DashboardHelper>.Instance.HasColdStoire;

            HasLadaan = BaseSingleton<DashboardHelper>.Instance.HasLadaan;

            HasTodayRates = BaseSingleton<DashboardHelper>.Instance.HasTodayRates;

            HasBuyerSummary = BaseSingleton<DashboardHelper>.Instance.HasBuyerSummary;

            BaseSingleton<DashboardObserver>.Instance.VisibleTodayBalance += OnVisibleTodayBalance;

            BaseSingleton<DashboardObserver>.Instance.VisibleColdStoire += OnVisibleColdStoire;

            BaseSingleton<DashboardObserver>.Instance.VisibleLadaan += OnVisibleLadaan;

            BaseSingleton<DashboardObserver>.Instance.VisibleTodayRates += OnVisibleTodayRates;

            BaseSingleton<DashboardObserver>.Instance.VisibleBuyerSummary += OnVisibleBuyerSummary;

            ChartData = new ObservableCollection<ChartModel>()
            {
                new ChartModel { Name = "Paid", Value = 23 },
                new ChartModel { Name = "Over Due", Value = 5 },
                new ChartModel { Name = "Due", Value = 72 }
            };

            NewsData = new ObservableCollection<NewsModel>()
            {
                new NewsModel { Picture = "Picture", Header = "Boating to the island", Edited="Midified: date", Icon="Icon" },
                new NewsModel { Picture = "Picture", Header = "Cabana view", Edited="Midified: date", Icon="Icon" },
                new NewsModel { Picture = "Picture", Header = "Chelsea view", Edited="Midified: date", Icon="Icon" }
            };

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));

            DisplayLaddanPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.LadaanPage));

            DisplayTodayRatePageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.TodayRatePage));

            DisplayBuyerPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.BuyerPage));

            DisplayColdStorePageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.ColdStorePage));

            DisplayGodownPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.GodownPage));
        }

        private void OnVisibleTodayBalance(object sender, VisibleTodayBalanceArgs e) {
            if (!HasTodayBalance.Equals(e.IsVisible)) {
                HasTodayBalance = e.IsVisible;
            }
        }

        private void OnVisibleColdStoire(object sender, VisibleColdStoireArgs e) {
            if (!HasColdStoire.Equals(e.IsVisible)) {
                HasColdStoire = e.IsVisible;
            }
        }

        private void OnVisibleLadaan(object sender, VisibleLadaanArgs e) {
            if (!HasLadaan.Equals(e.IsVisible)) {
                HasLadaan = e.IsVisible;
            }
        }

        private void OnVisibleTodayRates(object sender, VisibleTodayRatesArgs e) {
            if (!HasTodayRates.Equals(e.IsVisible)) {
                HasTodayRates = e.IsVisible;
            }
        }

        private void OnVisibleBuyerSummary(object sender, VisibleBuyerSummaryArgs e) {
            if (!HasBuyerSummary.Equals(e.IsVisible)) {
                HasBuyerSummary = e.IsVisible;
            }
        }

        public void Dispose() {
            ChartData.Clear();

            NewsData.Clear();

            BaseSingleton<DashboardObserver>.Instance.VisibleTodayBalance -= OnVisibleTodayBalance;

            BaseSingleton<DashboardObserver>.Instance.VisibleColdStoire -= OnVisibleColdStoire;

            BaseSingleton<DashboardObserver>.Instance.VisibleLadaan -= OnVisibleLadaan;

            BaseSingleton<DashboardObserver>.Instance.VisibleTodayRates -= OnVisibleTodayRates;

            BaseSingleton<DashboardObserver>.Instance.VisibleBuyerSummary -= OnVisibleBuyerSummary;
        }
    }
}
