using Tulsi.NavigationFramework;
using Tulsi.ViewModels;
using Xamarin.Forms;

namespace Tulsi {
    public partial class PasscodePage : ContentPage, IView {

        private readonly PasscodePageViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public PasscodePage() {
            InitializeComponent();
            
            BindingContext = _viewModel = new PasscodePageViewModel();
        }

        public void ApplyVisualChangesWhileNavigating() {

        }

        /// <summary>
        ///     Occurs only for Android (not for iOS).
        ///     False navigate out from page, true - staying in this page.
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed() {
            Dispose();
            return false;
        }

        public void Dispose() {
            _viewModel.Dispose();
        }
    }
}
