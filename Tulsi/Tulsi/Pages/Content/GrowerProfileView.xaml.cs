using System;
using Tulsi.Helpers;
using Tulsi.NavigationFramework;
using Tulsi.SharedService;
using Tulsi.ViewModels.Content;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tulsi.Pages.Content {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GrowerProfileView : ContentView, IView {

        private readonly GrowerProfileViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public GrowerProfileView() {
            InitializeComponent();

            BindingContext = _viewModel = new GrowerProfileViewModel();

            BaseSingleton<NavigationObserver>.Instance.CloseView += OnCloseView;
        }

        private void OnCloseView(object sender, EventArgs e) {
            int displayHeight = DependencyService.Get<IDisplaySize>().GetHeight();
            ((View)Parent).TranslationY = displayHeight;

            Dispose();
        }

        public void ApplyVisualChangesWhileNavigating() {
        }

        public void Dispose() {
            _viewModel.Dispose();
            BaseSingleton<NavigationObserver>.Instance.CloseView -= OnCloseView;
        }
    }
}