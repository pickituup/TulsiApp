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
    public class GrowerViewModel : ViewModelBase, IViewModel {

        ObservableCollection<ChartModel> _chartData;
        public ObservableCollection<ChartModel> ChartData {
            get { return _chartData; }
            set { SetProperty(ref _chartData, value); }
        }

        ObservableCollection<Transaction> _transactionsData;
        public ObservableCollection<Transaction> TransactionsData {
            get { return _transactionsData; }
            set { SetProperty(ref _transactionsData, value); }
        }

        Transaction _selectedMenuItem;
        public Transaction SelectedMenuItem {
            get { return _selectedMenuItem; }
            set {
                if (SetProperty(ref _selectedMenuItem, value) && value != null) {
                    // Do something
                    if (true) {
                        BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.GrowerProfilePage);
                    }
                }
            }
        }

        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public GrowerViewModel() {
            ChartData = new ObservableCollection<ChartModel>()
            {
                new ChartModel { Name = "Paid", Value = 23 },
                new ChartModel { Name = "Due", Value = 77 }
            };
            TransactionsData = new ObservableCollection<Transaction>()
            {
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" },
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" },
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" },
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" },
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" },
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" }
            };

            DisplaySearchPageCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage));
        }

        public void Dispose() {

        }
    }
}
