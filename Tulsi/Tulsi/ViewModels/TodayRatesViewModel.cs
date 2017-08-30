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

        /// <summary>
        /// 
        /// </summary>
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

        /// <summary>
        /// 
        /// </summary>
        private void HARDCODED_DATA_INSERT() {
            Random random = new Random();

            for (int i = 0; i < 4; i++) {
                TodayRatesEntry todayRatesEntry = new TodayRatesEntry() {
                    GroupName = "Wahe Guru",
                    Sum = 667
                };

                int randomNumber = random.Next(1, 9);
                for (int y = 0; y < randomNumber; y++) {
                    todayRatesEntry.Items.Add(new TodayRatesSubItem() { Code = "24D", Number = 160 });
                }

                TodayRatesData.Add(todayRatesEntry);
            }
        }

        public void Dispose() {
            
        }

        public void ReSubscribe() {
            throw new NotImplementedException();
        }
    }
}
