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
        ///     Public ctor().
        /// </summary>
        public TodayRatesViewModel() {
            _todayRatesData = new ObservableCollection<TodayRatesEntry>();

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));

            HARDCODED_DATA_INSERT();
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<TodayRatesEntry> TodayRatesData {
            get { return _todayRatesData; }
            set { SetProperty(ref _todayRatesData, value); }
        }

        //TodayRatesEntry _selectedMenuItem;
        //public TodayRatesEntry SelectedMenuItem {
        //    get { return _selectedMenuItem; }
        //    set {
        //        if (SetProperty(ref _selectedMenuItem, value) && value != null) {
        //            // Do something
        //        }
        //    }
        //}

        /// <summary>
        /// Navigates to search page
        /// </summary>
        public ICommand DisplaySearchPageCommand { get; private set; }

        
        /// <summary>
        /// IViewModel implementation
        /// </summary>
        public void Dispose() {

        }

        /// <summary>
        /// 
        /// </summary>
        private void HARDCODED_DATA_INSERT() {
            //TodayRatesData = new ObservableCollection<TodayRatesEntry>()
            //{
            //    new TodayRatesEntry { GroupName = "Wahe Guru", Code = "24D", Number = "160" },
            //    new TodayRatesEntry { GroupName = "Wahe Guru", Code = "32D", Number = "140" },
            //    new TodayRatesEntry { GroupName = "Wahe Guru", Code = "42D", Number = "160" },
            //    new TodayRatesEntry { GroupName = "Wahe Guru", Code = "45D", Number = "160" },
            //    new TodayRatesEntry { GroupName = "Wahe Guru", Code = "54D", Number = "160" },
            //    new TodayRatesEntry { GroupName = "Wahe Guru", Code = "60D", Number = "160" },
            //    new TodayRatesEntry { GroupName = "Wahe Guru", Code = "72D", Number = "160" },
            //    new TodayRatesEntry { GroupName = "Wahe Guru", Code = "84D", Number = "160" },
            //    new TodayRatesEntry { GroupName = "Wahe Guru", Code = "96D", Number = "160" },
            //    new TodayRatesEntry { GroupName = "Wahe Guru", Code = "108D", Number = "160" },
            //};

            for (int i = 0; i < 4; i++) {
                TodayRatesEntry todayRatesEntry = new TodayRatesEntry() {
                    GroupName = "Wahe Guru",
                    Sum = 667
                };

                todayRatesEntry.Items.Add(new TodayRatesSubItem() { Code = "24D", Number = 160 });
                todayRatesEntry.Items.Add(new TodayRatesSubItem() { Code = "24D", Number = 160 });
                todayRatesEntry.Items.Add(new TodayRatesSubItem() { Code = "24D", Number = 160 });
                todayRatesEntry.Items.Add(new TodayRatesSubItem() { Code = "24D", Number = 160 });
                todayRatesEntry.Items.Add(new TodayRatesSubItem() { Code = "24D", Number = 160 });
                todayRatesEntry.Items.Add(new TodayRatesSubItem() { Code = "24D", Number = 160 });
                todayRatesEntry.Items.Add(new TodayRatesSubItem() { Code = "24D", Number = 160 });
                todayRatesEntry.Items.Add(new TodayRatesSubItem() { Code = "24D", Number = 160 });
                todayRatesEntry.Items.Add(new TodayRatesSubItem() { Code = "24D", Number = 160 });

                TodayRatesData.Add(todayRatesEntry);
            }
        }
    }
}
