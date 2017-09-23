using Tulsi.Helpers;
using Tulsi.NavigationFramework;
using Tulsi.ViewModels;
using Xamarin.Forms;

namespace Tulsi {
    public partial class LadaanPage : ContentPage, IView {

        private readonly LadaanPageViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public LadaanPage() {
            InitializeComponent();

            BindingContext = _viewModel = new LadaanPageViewModel();
        }

        public void ApplyVisualChangesWhileNavigating() {
            
        }

        /// <summary>
        ///     Occurs only for Android (not for iOS).
        ///     False navigate out from page, true - staying in this page.
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed() {
            if (_viewModel.SelectedLadaanTransaction != null) {
                _viewModel.SelectedLadaanTransaction = null;
                return true;
            }

            BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack();
            
            return true;
        }

        public void Dispose() {
            _viewModel.Dispose();
        }
    }
}
