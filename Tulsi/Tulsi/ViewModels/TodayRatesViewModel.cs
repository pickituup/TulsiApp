using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public class TodayRatesViewModel : ViewModelBase, IViewModel {

        ObservableCollection<TodayRatesEntry> _todayRatesData;
        public ObservableCollection<TodayRatesEntry> TodayRatesData {
            get { return _todayRatesData; }
            set { SetProperty(ref _todayRatesData, value); }
        }

        // Navigates to search page
        public ICommand DisplaySearchPageCommand { get; private set; }

        // Navigate back.
        public ICommand NavigateBackCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public TodayRatesViewModel() {
            _todayRatesData = new ObservableCollection<TodayRatesEntry>();

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));

            NavigateBackCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());

            HARDCODED_DATA_INSERT();
        }

        private void HARDCODED_DATA_INSERT() {
            for (int i = 0; i < 4; i++) {
                TodayRatesEntry todayRatesEntry = new TodayRatesEntry() {
                    GroupName = "Wahe Guru",
                    Sum = 667
                };

                todayRatesEntry.Items.Add(new TodayRatesSubItem() { Code = "24D", Number = 160 });
                todayRatesEntry.Items.Add(new TodayRatesSubItem() { Code = "24D", Number = 160 });
                todayRatesEntry.Items.Add(new TodayRatesSubItem() { Code = "44D", Number = 160 });
                todayRatesEntry.Items.Add(new TodayRatesSubItem() { Code = "24D", Number = 160 });
                todayRatesEntry.Items.Add(new TodayRatesSubItem() { Code = "24D", Number = 160 });
                todayRatesEntry.Items.Add(new TodayRatesSubItem() { Code = "24D", Number = 160 });
                todayRatesEntry.Items.Add(new TodayRatesSubItem() { Code = "24D", Number = 160 });
                todayRatesEntry.Items.Add(new TodayRatesSubItem() { Code = "24D", Number = 160 });
                todayRatesEntry.Items.Add(new TodayRatesSubItem() { Code = "24D", Number = 160 });

                TodayRatesData.Add(todayRatesEntry);
            }
        }

        public void Dispose() {

        }
    }
}
