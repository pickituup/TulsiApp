using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Tulsi.NavigationFramework;
using Tulsi.Helpers;
using Tulsi.MVVM.Core;
using Tulsi.Model;
using Tulsi.NavigationFramework.NavigationArgs;
using Tulsi.SharedService;
using System.Collections.ObjectModel;

namespace Tulsi.ViewModels {
    public class BuyerPageViewModel : ViewModelBase, IViewModel {

        IView _importedView;
        public IView ImportedView {
            get { return _importedView; }
            set {
                if (SetProperty(ref _importedView, value) && value != null)
                    Spot.TranslateTo(0, 0);
            }
        }

        ContentView _spot;
        public ContentView Spot {
            get { return _spot; }
            set {
                if (SetProperty(ref _spot, value) && value != null)
                    HideSpotView();
            }
        }

        private Transaction _selectedItem;
        public Transaction SelectedItem {
            get => _selectedItem;
            set {
                if (SetProperty<Transaction>(ref _selectedItem, value) && value != null) {
                    BaseSingleton<NavigationObserver>.Instance.OnImportedSpot(ViewType.BuyerProfileView);
                    BaseSingleton<NavigationObserver>.Instance.OnSendProfileTransAction(value.ProfileTransactions);
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
        public BuyerPageViewModel() {

            BaseSingleton<NavigationObserver>.Instance.ImportedSpot += ImportingSpot;

            BaseSingleton<NavigationObserver>.Instance.CloseView += OnCloseView;

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
            });

            TimeLineCommand = new Command(() => {
                TransactionsData = GetTimeLineTransactions();
            });

            TransactionsData = GetAggregateTransactions();
        }

        private void ImportingSpot(object sender, NavigationImportedEventArgs e) {
            ImportedView = BaseSingleton<ViewSwitchingLogic>.Instance.GetViewByType(e.ViewType);
        }

        private void OnCloseView(object sender, EventArgs e) {
            if (this.ImportedView != null) {
                SelectedItem = null;
                HideSpotView();
                ImportedView.Dispose();
                ImportedView = null;
            }
        }

        public void NativeSenderCloseView() {
            SelectedItem = null;
            HideSpotView();
            ImportedView.Dispose();
            ImportedView = null;
        }

        private void HideSpotView() {
            int displayHeight = DependencyService.Get<IDisplaySize>().GetHeight();
            Spot.TranslationY = displayHeight;
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
            if (ImportedView != null) {
                ImportedView.Dispose();
            }

            BaseSingleton<NavigationObserver>.Instance.CloseView -= OnCloseView;

            BaseSingleton<NavigationObserver>.Instance.ImportedSpot -= ImportingSpot;
        }

        public void ReSubscribe() {
            BaseSingleton<NavigationObserver>.Instance.CloseView += OnCloseView;

            BaseSingleton<NavigationObserver>.Instance.ImportedSpot += ImportingSpot;
        }
    }
}