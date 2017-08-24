using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.MVVM.Core;
using System.Windows.Input;
using Xamarin.Forms;
using Tulsi.NavigationFramework;
using Tulsi.Helpers;
using Tulsi.Model;

namespace Tulsi.ViewModels {
    public class BuyerRankingsViewModel : ViewModelBase, IViewModel {
        /// <summary>
        /// TODO: maby define one shared ViewContainer builder for all 'users'
        /// </summary>
        private ViewContainer _viewContainer;
        private IView _buyerProfileDetailView;
        private VisualElement _movableSpot;
        private BuyerRanking _selectedItem;

        // Navigate back.
        public ICommand NavigateBackCommand { get; private set; }

        /// <summary>
        ///     ctor().
        /// </summary>
        public BuyerRankingsViewModel() {
            _viewContainer = new ViewContainer();
            BuyerProfileDetailView = _viewContainer.GetViewByType(ViewType.BuyerProfileView);

            DisplaySearchPageCommand = new Command(() => {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.SearchPage);
            });

            LooseSelectionCommand = new Command(() => {
                SelectedItem = null;
            });

            NavigateBackCommand = new Command(() => BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack());

            HARDCODED_DATA_INSERT();
        }

        /// <summary>
        /// Display SearchPage command
        /// </summary>
        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public List<BuyerRanking> BuyerRankings { get; private set; }

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
        public BuyerRanking SelectedItem {
            get => _selectedItem;
            set {
                if (SetProperty<BuyerRanking>(ref _selectedItem, value)) {
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
            } else {
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
            BuyerRankings = new List<BuyerRanking>() {
                new BuyerRanking { Name = "DFC Mickey", Rank=1, IsUp=true, Change=1,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" }
                    }},
                new BuyerRanking { Name = "DFC Mickey", Rank=2, IsUp=true, Change=1,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" }
                    }},
                new BuyerRanking { Name = "DFC Mickey", Rank=3, IsUp=false, Change=1,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" }
                    } },
                new BuyerRanking { Name = "DFC Mickey", Rank=4, IsUp=false, Change=1,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" }
                    } },
                new BuyerRanking { Name = "DFC Mickey", Rank=5, IsUp=true, Change=1,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" }
                    } },
                new BuyerRanking { Name = "DFC Mickey", Rank=6, IsUp=true, Change=1,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" }
                    } },
                new BuyerRanking { Name = "DFC Mickey", Rank=7, IsUp=true, Change=1,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" }
                    } },
                new BuyerRanking { Name = "DFC Mickey", Rank=8, IsUp=true, Change=1,
                    ProfileTransactions = new List<ProfileTransaction>() {
                        new ProfileTransaction { Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" },
                        new ProfileTransaction { Code = "DD/MM", Number = "28", IsP=false, Quantity="8,200" },
                        new ProfileTransaction{ Code = "DD/MM", Number = "", IsP=true, Quantity="8,200" }
                    } }
            };
        }
    }
}
