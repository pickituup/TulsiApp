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

        TodayRatesEntry _selectedMenuItem;
        public TodayRatesEntry SelectedMenuItem {
            get { return _selectedMenuItem; }
            set {
                if (SetProperty(ref _selectedMenuItem, value) && value != null) {
                    // Do something
                }
            }
        }

        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public TodayRatesViewModel() {
            TodayRatesData = new ObservableCollection<TodayRatesEntry>()
            {
                new TodayRatesEntry { GroupName = "Wahe Guru", Code = "24D", Number = "160" },
                new TodayRatesEntry { GroupName = "Wahe Guru", Code = "32D", Number = "140" },
                new TodayRatesEntry { GroupName = "Wahe Guru", Code = "42D", Number = "160" },
                new TodayRatesEntry { GroupName = "Wahe Guru", Code = "45D", Number = "160" },
                new TodayRatesEntry { GroupName = "Wahe Guru", Code = "54D", Number = "160" },
                new TodayRatesEntry { GroupName = "Wahe Guru", Code = "60D", Number = "160" },
                new TodayRatesEntry { GroupName = "Wahe Guru", Code = "72D", Number = "160" },
                new TodayRatesEntry { GroupName = "Wahe Guru", Code = "84D", Number = "160" },
                new TodayRatesEntry { GroupName = "Wahe Guru", Code = "96D", Number = "160" },
                new TodayRatesEntry { GroupName = "Wahe Guru", Code = "108D", Number = "160" },
            };

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));
        }

        public void Dispose() {

        }
    }
}
