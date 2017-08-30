using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.NavigationFramework;
using Tulsi.Helpers;
using Xamarin.Forms;
using Tulsi.ViewModels;
using SlideOverKit;
using Tulsi.SharedService;

namespace Tulsi {
    /// <summary>
    /// TODO: LatePaymentsPage use similar 'hide/show behavior' as in BuyerRankingsPage, BuyerPage. Try
    /// to define abstract core of that behavior
    /// </summary>
    public partial class LatePaymentsPage : ContentPage, IView {

        private LatePaymentsPageViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public LatePaymentsPage() {
            InitializeComponent();

            BindingContext = _viewModel = new LatePaymentsPageViewModel();

            _viewModel.Spot = spot_ContentView;
        }

        public void ApplyVisualChangesWhileNavigating() {

        }

        protected override void OnDisappearing() {
            if (_viewModel.ImportedView != null) {
                _viewModel.ImportedView.Dispose();
            }
            _viewModel.Dispose();
        }

        public void Dispose() {
            _viewModel.Dispose();
        }

        public void ReSubscribe() {
            
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
                _viewModel.NativeSenderCloseView();
                return true;
            }
        }
    }
}
