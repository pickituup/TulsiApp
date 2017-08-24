using Tulsi.NavigationFramework;
using Tulsi.ViewModels;
using Xamarin.Forms;

namespace Tulsi {
    public partial class ArrivalDetailsPage : ContentPage, IView {

        private readonly ArrivalDetailsViewModel _viewModel;

        public ArrivalDetailsPage() {
            InitializeComponent();

            BindingContext = _viewModel = new ArrivalDetailsViewModel();
        }
        
        public void ApplyVisualChangesWhileNavigating() {
            
        }
    }
}
