using Tulsi.NavigationFramework;
using Tulsi.ViewModels;
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
        }

        public void ApplyVisualChangesWhileNavigating() {
            _viewModel.Dispose();
        }
    }
}