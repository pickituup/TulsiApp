using Tulsi.NavigationFramework;
using Tulsi.ViewModels;
using Xamarin.Forms;

namespace Tulsi {
    public partial class SetupDashboardPage : ContentPage, IView {

        private readonly SetupDashboardViewModel _viewModel;

        public SetupDashboardPage() {
            InitializeComponent();

            BindingContext = _viewModel = new SetupDashboardViewModel();
        }
       
        public void ApplyVisualChangesWhileNavigating() {
            
        }
    }
}
