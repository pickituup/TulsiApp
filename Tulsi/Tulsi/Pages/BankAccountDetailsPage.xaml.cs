using Tulsi.Helpers;
using Tulsi.NavigationFramework;
using Tulsi.ViewModels;
using Xamarin.Forms;

namespace Tulsi {
    public partial class BankAccountDetailsPage : ContentPage, IView {

        private BankAccountDetailsViewModel _viewModel;

        public BankAccountDetailsPage() {
            InitializeComponent();

            BindingContext = _viewModel = new BankAccountDetailsViewModel();
        }

        public void ApplyVisualChangesWhileNavigating() {
            
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

        public void Dispose() {
            _viewModel.Dispose();
        }
    }
}
