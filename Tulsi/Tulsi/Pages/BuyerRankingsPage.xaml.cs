using System;
using Tulsi.NavigationFramework;
using Tulsi.ViewModels;
using Xamarin.Forms;

namespace Tulsi {
    public partial class BuyerRankingsPage : ContentPage, IView {

        private BuyerRankingsPageViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public BuyerRankingsPage() {
            InitializeComponent();

            BindingContext = _viewModel = new BuyerRankingsPageViewModel();

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

        public void Dispose() {
            _viewModel.Dispose();
        }

        public void ReSubscribe() {
            
        }
    }
}