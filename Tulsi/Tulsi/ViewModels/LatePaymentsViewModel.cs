using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.Model;
using Tulsi.MVVM.Core;
using Tulsi.NavigationFramework;
using Tulsi.Helpers;
using System.Windows.Input;
using Xamarin.Forms;

namespace Tulsi.ViewModels {
    public class LatePaymentsViewModel : ViewModelBase, IViewModel {
        /// <summary>
        /// TODO: maby define one shared ViewContainer builder for all 'users'
        /// </summary>
        private ViewContainer _viewContainer;
        private LatePayment _selectedLatePayment;
        private VisualElement _movableSpot;
        private IView _buyerProfileDetailView;

        /// <summary>
        /// Public ctor.
        /// </summary>
        public LatePaymentsViewModel() {
            _viewContainer = new ViewContainer();
            BuyerProfileDetailView = _viewContainer.GetViewByType(ViewType.BuyerProfileView);

            DisplaySearchPageCommand = new Command(()=> {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage);
            });

            LooseSelectionCommand = new Command(() => {
                SelectedItem = null;
            });

            HARDCODED_DATA_INSERT();
        }

        /// <summary>
        /// 
        /// </summary>
        public List<LatePayment> LatePayments { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        /// Loose selection of prev selected rate command
        /// </summary>
        public ICommand LooseSelectionCommand { get; private set; }

        /// <summary>
        /// Buyer profile detail view representation.
        /// </summary>
        public IView BuyerProfileDetailView {
            get => _buyerProfileDetailView;
            private set => SetProperty<IView>(ref _buyerProfileDetailView, value);
        }

        /// <summary>
        /// 
        /// </summary>
        public LatePayment SelectedItem {
            get => _selectedLatePayment;
            set {
                if (SetProperty<LatePayment>(ref _selectedLatePayment, value)) {
                    ToogleSpotVisibility(value == null ? false : true);
                }
            }
        }

        /// <summary>
        /// 
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
            LatePayments = new List<LatePayment>()
            {
                new LatePayment { Name = "SKC Arjun", Amount=78000,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" }
                    }},
                new LatePayment { Name = "DFC Mickey", Amount=78000,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" }
                    } },
                new LatePayment { Name = "KK Nandu", Amount=78000,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" }
                    } },
                new LatePayment { Name = "(M) Henu", Amount=78000,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" }
                    } },
                new LatePayment { Name = "SF", Amount=78000,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" }
                    } },
                new LatePayment { Name = "PJB", Amount=78000,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" }
                    } }
            };
        }
    }
}
