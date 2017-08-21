using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using SlideOverKit;
using Tulsi.NavigationFramework;
using Tulsi.ViewModels;

namespace Tulsi {
    public partial class ArrivalDetailsPage : MenuContainerPage, IView {

        private readonly ArrivalDetailsViewModel _viewModel;

        public ArrivalDetailsPage() {
            InitializeComponent();

            SlideMenu = new SideMenuView();

            BindingContext = _viewModel = new ArrivalDetailsViewModel();
        }

        // Show side menu.
        private void ShowMenuCommand(object sender, EventArgs e) {
            ShowMenu();
        }

        // Autohide side menu.
        public void ApplyVisualChangesWhileNavigating() {
            SlideMenu.HideWithoutAnimations();
        }
    }
}
