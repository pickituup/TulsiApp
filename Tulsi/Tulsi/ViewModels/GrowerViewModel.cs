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
        ObservableCollection<Transaction> _transactionsData;
        /// <summary>
        /// TODO: maby define one shared ViewContainer builder for all 'users'
        /// </summary>
        private ViewContainer _viewContainer;
        private IView _groverProfileDetailView;
        Transaction _selectedItem;
        private VisualElement _movableSpot;

        /// <summary>
        ///     ctor().
        /// </summary>
        public GrowerViewModel() {
            _viewContainer = new ViewContainer();
            //
            // TODO: change ViewType.BuyerProfileView to the GroverProfileView, and configure 
            // bindings inside BuyerProfileView.
            //
            GroverProfileDetailView = _viewContainer.GetViewByType(ViewType.BuyerProfileView);

            DisplaySearchPageCommand = new Command(() => {
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
        public ObservableCollection<ChartModel> ChartData {
            get { return _chartData; }
            set { SetProperty(ref _chartData, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public Transaction SelectedItem {
            get { return _selectedItem; }
            set {
                if (SetProperty(ref _selectedItem, value)) {
                    ToogleSpotVisibility(value == null ? false : true);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public ObservableCollection<Transaction> TransactionsData {
            get { return _transactionsData; }
            set { SetProperty(ref _transactionsData, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        public ICommand DisplaySearchPageCommand { get; private set; }

        /// <summary>
        /// Loose selection of prev selected rate command
        /// </summary>
        public ICommand LooseSelectionCommand { get; private set; }

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
        /// Buyer profile detail view representation.
        /// </summary>
        public IView GroverProfileDetailView {
            get => _groverProfileDetailView;
            private set => SetProperty<IView>(ref _groverProfileDetailView, value);
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
            TransactionsData = new ObservableCollection<Transaction>()
            {
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" },
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" },
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" },
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" },
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" },
                new Transaction { Code = "SKC", Number = "28", Quantity="8,200" }
            };

            ChartData = new ObservableCollection<ChartModel>()
            {
                new ChartModel { Name = "Paid", Value = 23 },
                new ChartModel { Name = "Due", Value = 77 }
            };
        }
    }
}
