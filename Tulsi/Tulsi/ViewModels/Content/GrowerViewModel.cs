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

namespace Tulsi.ViewModels.Content {
    public class GrowerViewModel : ViewModelBase, IViewModel {

        string _secondColumn;
        public string SecondColumn {
            get { return _secondColumn; }
            set { SetProperty(ref _secondColumn, value); }
        }

        string _lastColumn;
        public string LastColumn {
            get { return _lastColumn; }
            set { SetProperty(ref _lastColumn, value); }
        }

        ObservableCollection<ChartModel> _chartData;
        public ObservableCollection<ChartModel> ChartData {
            get { return _chartData; }
            set { SetProperty(ref _chartData, value); }
        }

        Transaction _selectedItem;
        public Transaction SelectedItem {
            get { return _selectedItem; }
            set {
                if (SetProperty(ref _selectedItem, value) && value != null) {
                    BaseSingleton<NavigationObserver>.Instance.OnGrowerViewImportedSpot(ViewType.GrowerProfileView);
                    BaseSingleton<NavigationObserver>.Instance.OnSendToGrowerProfileTransAction(value.ProfileTransactions);
                    SelectedItem = null;
                }
            }
        }

        ObservableCollection<Transaction> _transactionsData;
        public ObservableCollection<Transaction> TransactionsData {
            get { return _transactionsData; }
            set { SetProperty(ref _transactionsData, value); }
        }

        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        ///     Display Aggregate items.
        /// </summary>
        public ICommand AggregateCommand { get; private set; }

        /// <summary>
        ///     Display TimeLine items.
        /// </summary>
        public ICommand TimeLineCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public GrowerViewModel() {
            SetAggregateHeader();

            DisplaySearchPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage);
            });

            AggregateCommand = new Command(() => {
                TransactionsData = GetAggregateTransactions();
                SetAggregateHeader();
            });

            TimeLineCommand = new Command(() => {
                TransactionsData = GetTimeLineTransactions();
                SetTimeLineHeader();
            });

            ChartData = GetChartData();

            TransactionsData = GetAggregateTransactions();
        }

        private void SetAggregateHeader() {
            SecondColumn = "TCases";
            LastColumn = "TNetAmt";
        }

        private void SetTimeLineHeader() {
            SecondColumn = "Cases";
            LastColumn = "NetAmt";
        }

        private ObservableCollection<ChartModel> GetChartData() {
            return new ObservableCollection<ChartModel>()
            {
                new ChartModel { Name = "Paid", Value = 23 },
                new ChartModel { Name = "Due", Value = 77 }
            };
        }
        private ObservableCollection<Transaction> GetAggregateTransactions() {
            return new ObservableCollection<Transaction>()
            {
                new Transaction { Date = DateTime.Now, TCases = 230, Name = "JohnSn", Amount=110.341m,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=true, Quantity="8,200" }
                }},
                new Transaction { Date = DateTime.Now, TCases = 230, Name = "JohnSn", Amount=110.341m,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" }
                }},
                new Transaction { Date = DateTime.Now, TCases = 230, Name = "JohnSn", Amount=110.341m,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" }
                }},
                new Transaction { Date = DateTime.Now, TCases = 230, Name = "JohnSn", Amount=110.341m,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=true, Quantity="8,200" }
                }},
                new Transaction { Date = DateTime.Now, TCases = 230, Name = "JohnSn", Amount=110.341m,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                }},
                new Transaction { Date = DateTime.Now, TCases = 230, Name = "JohnSn", Amount=110.341m,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=true, Quantity="8,200" }
                }},
                new Transaction { Date = DateTime.Now, TCases = 230, Name = "JohnSn", Amount=110.341m,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=true, Quantity="8,200" }
                }}
            };
        }

        private ObservableCollection<Transaction> GetTimeLineTransactions() {
            return new ObservableCollection<Transaction>()
            {
                new Transaction { Date = DateTime.Now, TCases = 230, Name = "JohnSn", Amount=110.341m,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=true, Quantity="8,200" }
                }},
                new Transaction {Date = DateTime.Now, TCases = 230, Name = "JohnSn", Amount=110.341m,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=true, Quantity="8,200" }
                }}
            };
        }

        public void Dispose() {
        }
    }
}
