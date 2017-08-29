using Tulsi.NavigationFramework;
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
        }

        /// <summary>
        /// 
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() {
            _viewModel.Dispose();
        }
    }
}