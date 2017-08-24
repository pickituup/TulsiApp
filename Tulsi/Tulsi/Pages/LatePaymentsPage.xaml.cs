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

        private LatePaymentsViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public LatePaymentsPage() {
            InitializeComponent();

            BindingContext = _viewModel = new LatePaymentsViewModel();
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
