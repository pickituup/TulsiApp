using Tulsi.Helpers;
using Tulsi.NavigationFramework;
using Tulsi.ViewModels;
using Xamarin.Forms;

namespace Tulsi {
    public partial class TodayRatesPage : ContentPage, IView {

        private readonly TodayRatesPageViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public TodayRatesPage() {
            InitializeComponent();
            
            BindingContext = _viewModel = new TodayRatesPageViewModel();
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
    }
}
