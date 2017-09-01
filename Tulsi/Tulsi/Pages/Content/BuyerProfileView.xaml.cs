using System;
using Tulsi.Helpers;
using Tulsi.NavigationFramework;
using Tulsi.SharedService;
using Tulsi.ViewModels;
using Tulsi.ViewModels.Content;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tulsi.Pages.Content {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuyerProfileView : ContentView, IView {

        private readonly BuyerProfileViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public BuyerProfileView() {
            InitializeComponent();

            BindingContext = _viewModel = new BuyerProfileViewModel();

            BaseSingleton<NavigationObserver>.Instance.CloseView += OnCloseView;
        }

        public void ApplyVisualChangesWhileNavigating() {
        }

        private void OnCloseView(object sender, EventArgs e) {
            int displayHeight = DependencyService.Get<IDisplaySize>().GetHeight();
            ((View)Parent).TranslationY = displayHeight;

            Dispose();
        }

        public void Dispose() {
            _viewModel.Dispose();
            BaseSingleton<NavigationObserver>.Instance.CloseView -= OnCloseView;
        }
    }
}