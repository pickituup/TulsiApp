using Tulsi.NavigationFramework;
using Tulsi.ViewModels;
using Xamarin.Forms;

namespace Tulsi {
    /// <summary>
    /// TODO: BuyerRankingsPage use similar 'hide/show behavior' as in LatePaymentsPage, BuyerPage. Try
    /// to define abstract core of that behavior
    /// </summary>
    public partial class BuyerRankingsPage : ContentPage, IView {

        private BuyerRankingsViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public BuyerRankingsPage() {
            InitializeComponent();

            BindingContext = _viewModel = new BuyerRankingsViewModel();

            _viewModel.MovableSpot = _spot_ConentView;
        }

        public void ApplyVisualChangesWhileNavigating() {

        }

        /// <summary>
        ///     Occurs only for Android (not for iOS).
        ///     False navigate out from page, true - keep staing in this page.
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed() {
            if (_viewModel.SelectedItem == null) {
                return false;
            } else {
                _viewModel.SelectedItem = null;
                return true;
            }
        }
    }
}