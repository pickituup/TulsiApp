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
using Xamarin.Forms;

namespace Tulsi.ViewModels {
    public class ProfitViewModel : ViewModelBase, IViewModel {

        int _year;
        public int Year {
            get { return _year; }
            set { SetProperty(ref _year, value); }
        }

        Period _reportsPeriod;
        public Period ReportsPeriod {
            get { return _reportsPeriod; }
            set { SetProperty(ref _reportsPeriod, value); }
        }

        public List<ProfitChartModel> ChartData { get; set; }

        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public ProfitViewModel() {
            ChartData = new List<ProfitChartModel>()
            {
                new ProfitChartModel { Value = 420, Step = 1 },
                new ProfitChartModel { Value = 425, Step = 2 },
                new ProfitChartModel { Value = 425, Step = 3 },
                new ProfitChartModel { Value = 440, Step = 4 },
                new ProfitChartModel { Value = 420, Step = 5 },
                new ProfitChartModel { Value = 410, Step = 6 },
                new ProfitChartModel { Value = 408, Step = 7 },
                new ProfitChartModel { Value = 415, Step = 8 },
                new ProfitChartModel { Value = 425, Step = 9 },
            };

            Year = 2013;

            ReportsPeriod = Period.Monthly;

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));
        }

        public void Dispose() {
            
        }
    }
}
