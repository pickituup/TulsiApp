using Tulsi.NavigationFramework;
using Tulsi.ViewModels;
using Xamarin.Forms;

namespace Tulsi {
    public partial class LadaanPage : ContentPage, IView {

        private readonly LadaanViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public LadaanPage() {
            InitializeComponent();

            BindingContext = _viewModel = new LadaanViewModel();
        }

        private void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            menuItems.SelectedItem = null;
        }

        public void ApplyVisualChangesWhileNavigating() {
            
        }
    }
}
