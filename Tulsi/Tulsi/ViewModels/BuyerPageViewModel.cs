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

namespace Tulsi.ViewModels {
    public class BuyerPageViewModel : ViewModelBase, IViewModel {
        /// <summary>
        /// TODO: maby define one shared ViewContainer builder for all 'users'
        /// </summary>
        private ViewContainer _viewContainer;
        private Transaction _selectedTransaction;
        private IView _buyerProfileDetailView;
        private VisualElement _movableSpot;

        /// <summary>
        /// Public ctor.
        /// </summary>
        public BuyerPageViewModel() {
            _viewContainer = new ViewContainer();

            DisplaySearchPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage);
            });

            DisplayBuyerRankingsPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.BuyerRankingsPage);
            });

            DisplayLatePaymentsPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.LatePaymentsPage);
            });

            LooseTransactionSelectionCommand = new Command(()=> {
                SelectedTransaction = null;
            });

            BuyerProfileDetailView = _viewContainer.GetViewByType(ViewType.BuyerProfileView);
            
            HARDCODED_DATA_INSERT();
        }

        /// <summary>
        /// Display SearchPage command
        /// </summary>
        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        /// Display BuyerRankingsPage command
        /// </summary>
        public ICommand DisplayBuyerRankingsPageCommand { get; private set; }

        /// <summary>
        /// Display LatePaymentsPage page command
        /// </summary>
        public ICommand DisplayLatePaymentsPageCommand { get; private set; }

        /// <summary>
        /// Loose selection of prev selected transaction command
        /// </summary>
        public ICommand LooseTransactionSelectionCommand { get; private set; }

        /// <summary>
        /// Values are hard coded...
        /// </summary>
        public List<Transaction> TransactionsData { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public Transaction SelectedTransaction {
            get => _selectedTransaction;
            set {
                if (SetProperty<Transaction>(ref _selectedTransaction, value)) {
                    ToogleSpotVisibility(value == null ? false : true);
                }
            }
        }

        /// <summary>
        /// Buyer profile detail view representation.
        /// </summary>
        public IView BuyerProfileDetailView {
            get => _buyerProfileDetailView;
            private set => SetProperty<IView>(ref _buyerProfileDetailView, value);
        }

        /// <summary>
        /// Movable spot. All translations and hide show changes
        /// will apply to that VisualElement.
        /// </summary>
        public VisualElement MovableSpot {
            get => _movableSpot;
            set {
                if (SetProperty<VisualElement>(ref _movableSpot, value) && 
                    value != null) {
                    //
                    // We will hide spot only if it's another spot instanse and it's not null.
                    //
                    ToogleSpotVisibility(false);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose() {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="isVisible"></param>
        private void ToogleSpotVisibility(bool isVisible) {
            if (isVisible) {
                MovableSpot.TranslateTo(0, 0);
            }
            else {
                //
                // TODO: get screen heigh dynamicaly
                //
                MovableSpot.TranslationY = 1000;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void HARDCODED_DATA_INSERT() {
            TransactionsData = new List<Transaction>()
            {
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200",
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
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200",
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" }
                    } },
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200",
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" }
                    }},
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200",
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
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" ,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                    }},
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200",
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
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200",
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=true, Quantity="8,200" }
                    }}
            };
        }
    }
}