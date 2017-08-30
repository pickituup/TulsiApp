using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Tulsi.ViewModels;
using Tulsi.NavigationFramework;

namespace Tulsi {
    public partial class GrowerProfilePage : ContentPage, IView {

        private readonly GrowerProfilePageViewModel _viewModel;

        public GrowerProfilePage() {
            InitializeComponent();

            BindingContext = _viewModel = new GrowerProfilePageViewModel();
        }

        public void ApplyVisualChangesWhileNavigating() {
            
        }

        public void Dispose() {
            
        }

        public void ReSubscribe() {
            
        }

        private void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            menuItems.SelectedItem = null;
        }
    }
}
