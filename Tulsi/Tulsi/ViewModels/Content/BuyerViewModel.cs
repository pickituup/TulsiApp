using System;
using System.Collections.Generic;
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
    public sealed class BuyerViewModel : ViewModelBase, IViewModel {

        private IView _buyerProfileDetailView;
        public IView BuyerProfileDetailView {
            get => _buyerProfileDetailView;
            private set => SetProperty<IView>(ref _buyerProfileDetailView, value);
        }

        private Transaction _selectedItem;
        public Transaction SelectedItem {
            get => _selectedItem;
            set {
                if (SetProperty<Transaction>(ref _selectedItem, value)) {
                    BaseSingleton<NavigationObserver>.Instance.OnImportedSpot(ViewType.BuyerProfileView);
                    BaseSingleton<NavigationObserver>.Instance.OnSendProfileTransAction(value.ProfileTransactions);
                }
            }
        }

        /// <summary>
        ///     Values are hard coded...
        /// </summary>
        public List<Transaction> TransactionsData { get; private set; }

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
        ///     Loose selection of prev selected transaction command
        /// </summary>
        public ICommand LooseSelectionCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public BuyerViewModel() {
            DisplaySearchPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage);
            });

            DisplayBuyerRankingsPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.BuyerRankingsPage);
            });

            DisplayLatePaymentsPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.LatePaymentsPage);
            });

            LooseSelectionCommand = new Command(() => {
                SelectedItem = null;
            });

            BuyerProfileDetailView = BaseSingleton<ViewSwitchingLogic>.Instance.GetViewByType(ViewType.BuyerProfileView);

            HARDCODED_DATA_INSERT();

        }

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
                }},
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

        public void Dispose() {
            
        }
    }
}
