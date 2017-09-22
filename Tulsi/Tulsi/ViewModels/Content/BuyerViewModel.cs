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
using Tulsi.NavigationFramework.NavigationArgs;
using Xamarin.Forms;

namespace Tulsi.ViewModels.Content {
    public sealed class BuyerViewModel : ViewModelBase, IViewModel {

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

        private Transaction _selectedItem;
        public Transaction SelectedItem {
            get => _selectedItem;
            set {
                if (SetProperty(ref _selectedItem, value) && value != null) {
                    BaseSingleton<NavigationObserver>.Instance.OnBayerViewImportedSpot(ViewType.BuyerProfileView);
                    BaseSingleton<NavigationObserver>.Instance.OnSendToBuyerProfileTransAction(value.ProfileTransactions);

                    SelectedItem = null;
                }
            }
        }

        ObservableCollection<Transaction> _transactionsData;
        public ObservableCollection<Transaction> TransactionsData {
            get { return _transactionsData; }
            set { SetProperty(ref _transactionsData, value); }
        }

        /// <summary>
        ///     Display SearchPage command
        /// </summary>
        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        ///     Display BuyerRankingsPage command
        /// </summary>
        public ICommand DisplayBuyerRankingsPageCommand { get; private set; }

        /// <summary>
        ///     Display LatePaymentsPage page command
        /// </summary>
        public ICommand DisplayLatePaymentsPageCommand { get; private set; }

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
        public BuyerViewModel() {
            SetAggregateHeader();

            DisplaySearchPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage);
            });

            DisplayBuyerRankingsPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.BuyerRankingsPage);
            });

            DisplayLatePaymentsPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.LatePaymentsPage);
            });

            AggregateCommand = new Command(() => {
                TransactionsData = GetAggregateTransactions();
                SetAggregateHeader();
            });

            TimeLineCommand = new Command(() => {
                TransactionsData = GetTimeLineTransactions();
                SetTimeLineHeader();
            });

            TransactionsData = GetAggregateTransactions();

            ChartData = new ObservableCollection<ChartModel>()
            {
                new ChartModel { Name = "Paid", Value = 23 },
                new ChartModel { Name = "Over Due", Value = 5 },
                new ChartModel { Name = "Due", Value = 72 }
            };
        }

        private void SetAggregateHeader() {
            SecondColumn = "TCases";
            LastColumn = "TNetAmt";
        }

        private void SetTimeLineHeader() {
            SecondColumn = "Cases";
            LastColumn = "NetAmt";
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
            TransactionsData.Clear();
        }
    }
}
