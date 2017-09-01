using Tulsi.Helpers;
using Tulsi.NavigationFramework;
using Tulsi.ViewModels;
using Xamarin.Forms;

namespace Tulsi {
    public partial class TodayRatesPage : ContentPage, IView {

        private readonly TodayRatesViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public TodayRatesPage() {
            InitializeComponent();
            
            BindingContext = _viewModel = new TodayRatesViewModel();

            //
            // TODO: remove that evnet subscription and use Controls.StackList
            //
            //_viewModel.TodayRatesData.CollectionChanged += TodayRatesDataCollectionChanged;

            //InitialiseExpandedGroupItem(_viewModel.TodayRatesData);
        }

        /// <summary>
        ///     Make some visual changes of current page through navigating process (hide side menu or smt...)
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() {
            
        }

        public void Dispose() {
            _viewModel.Dispose();
        }

        /// <summary>
        ///     Occurs only for Android (not for iOS).
        ///     False navigate out from page, true - staying in this page.
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed() {
            BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack();
            return true;
        }

        //private void TodayRatesDataCollectionChanged(object sender, NotifyCollectionChangedEventArgs e) {
        //    //
        //    // TODO: handle other observable collection Actions
        //    //
        //    if (e.Action == NotifyCollectionChangedAction.Add) {
        //        InitialiseExpandedGroupItem(e.NewItems);
        //    }
        //}

        /// <summary>
        ///     TODO: define some factoy or ControlContainer that will create that ExpandedGroup...
        /// </summary>
        /// <param name="newItems"></param>
        //private void InitialiseExpandedGroupItem(IList newItems) {
        //    foreach (object item in newItems) {
        //        ExpandedGroup expandedGroup = new ExpandedGroup();
        //        expandedGroup.BindingContext = item;

        //        _ratesStack_StackLayout.Children.Add(expandedGroup);
        //    }
        //}
    }
}
