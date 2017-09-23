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
using Tulsi.SharedService;
using Xamarin.Forms;

namespace Tulsi.ViewModels {
    public class GrowerPageViewModel : ViewModelBase, IViewModel {

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
                    BaseSingleton<NavigationObserver>.Instance.OnGrowerImportedSpot(ViewType.GrowerProfileView);
                    BaseSingleton<NavigationObserver>.Instance.OnSendToGrowerProfileTransAction(value.ProfileTransactions);

                    SelectedItem = null;
                }
            }
        }

        IView _importedView;
        public IView ImportedView {
            get { return _importedView; }
            set {
                if (SetProperty(ref _importedView, value) && value != null)
                    Spot.TranslateTo(0, 0, 700);
            }
        }

        ContentView _spot;
        public ContentView Spot {
            get { return _spot; }
            set {
                if (SetProperty(ref _spot, value) && value != null)
                    HideView();
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
        public GrowerPageViewModel() {
            SetAggregateHeader();

            BaseSingleton<NavigationObserver>.Instance.GrowerImportedSpot += ImportingSpot;

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

        private void ImportingSpot(object sender, NavigationImportedEventArgs e) {
            ImportedView = BaseSingleton<ViewSwitchingLogic>.Instance.GetViewByType(e.ViewType);
        }

        public async void CloseImportedView() {
            if (this.ImportedView != null) {
                await HideViewAsync();
                ImportedView.Dispose();
                ImportedView = null;
            }
        }

        public void NativeSenderCloseView() {
            CloseImportedView();
        }

        private async void HideView() => await HideViewAsync();

        private async Task HideViewAsync() {
            int displayHeight = DependencyService.Get<IDisplaySize>().GetHeight();
            await Spot.TranslateTo(0, displayHeight, 700);
        }

        private ObservableCollection<Transaction> GetAggregateTransactions() {
            return new ObservableCollection<Transaction>()
            {
                new Transaction { Date = DateTime.Now, TCases = 230, Name = "JohnSn", Amount=110.341m,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Date=DateTime.Now, Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "28", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Date=DateTime.Now, Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "28", IsP=true, Quantity="8,200" }
                }},
                new Transaction { Date = DateTime.Now, TCases = 230, Name = "JohnSn", Amount=110.341m,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Date=DateTime.Now, Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" }
                }},
                new Transaction { Date = DateTime.Now, TCases = 230, Name = "JohnSn", Amount=110.341m,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" }
                }},
                new Transaction { Date = DateTime.Now, TCases = 230, Name = "JohnSn", Amount=110.341m,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Date=DateTime.Now, Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "28", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Date=DateTime.Now, Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=true, Quantity="8,200" }
                }},
                new Transaction { Date = DateTime.Now, TCases = 230, Name = "JohnSn", Amount=110.341m,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                }},
                new Transaction { Date = DateTime.Now, TCases = 230, Name = "JohnSn", Amount=110.341m,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Date=DateTime.Now, Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "28", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Date=DateTime.Now, Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "28", IsP=true, Quantity="8,200" }
                }},
                new Transaction { Date = DateTime.Now, TCases = 230, Name = "JohnSn", Amount=110.341m,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Date=DateTime.Now, Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction{ Date=DateTime.Now, Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "28", IsP=true, Quantity="8,200" }
                }}
            };
        }

        private ObservableCollection<Transaction> GetTimeLineTransactions() {
            return new ObservableCollection<Transaction>()
            {
                new Transaction { Date = DateTime.Now, TCases = 230, Name = "JohnSn", Amount=110.341m,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "28", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=true, Quantity="8,200" }
                }},
                new Transaction {Date = DateTime.Now, TCases = 230, Name = "JohnSn", Amount=110.341m,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Date=DateTime.Now, Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Date=DateTime.Now, Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction{ Date=DateTime.Now, Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=true, Quantity="8,200" }
                }}
            };
        }
        private ObservableCollection<ChartModel> GetChartData() {
            return new ObservableCollection<ChartModel>()
            {
                new ChartModel { Name = "Paid", Value = 23 },
                new ChartModel { Name = "Due", Value = 77 }
            };
        }


        public void Dispose() {
            if (ImportedView != null) {
                ImportedView.Dispose();
            }

            BaseSingleton<NavigationObserver>.Instance.GrowerImportedSpot -= ImportingSpot;
        }
    }
}
