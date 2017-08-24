using Tulsi.NavigationFramework;
using Tulsi.ViewModels;
using Xamarin.Forms;

namespace Tulsi {
    public partial class BankAccountDetailsPage : ContentPage, IView {

        private BankAccountDetailsViewModel _viewModel;

        public BankAccountDetailsPage() {
            InitializeComponent();

            BindingContext = _viewModel = new BankAccountDetailsViewModel();
        }

        public void ApplyVisualChangesWhileNavigating() {
            
        }
    }
}
