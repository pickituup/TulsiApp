using Tulsi.NavigationFramework;
using Tulsi.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tulsi.Pages.Content {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuyerProfileView : ContentView, IView {

        private readonly BuyerProfilePageViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public BuyerProfileView() {
            InitializeComponent();

            BindingContext = _viewModel = new BuyerProfilePageViewModel();
        }

        public void ApplyVisualChangesWhileNavigating() {
        }

        public void Dispose() {
            _viewModel.Dispose();
        }

        public void ReSubscribe() {
            
        }
    }
}