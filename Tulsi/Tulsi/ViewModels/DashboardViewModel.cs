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
using Xamarin.Forms;

namespace Tulsi.ViewModels {
    public class DashboardViewModel : ViewModelBase, IViewModel {

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
        public DashboardViewModel() {
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

        public void Dispose() {
            ChartData.Clear();
            NewsData.Clear();
        }
    }
}
