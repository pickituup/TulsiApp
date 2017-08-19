using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.NavigationFramework;
using Xamarin.Forms;
using SlideOverKit;
using Tulsi.SharedService;
using Tulsi.ViewModels;

namespace Tulsi {
    public partial class ReportsPage : MenuContainerPage, IView {

        private readonly ReportsViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public ReportsPage() {
            InitializeComponent();

            SlideMenu = new SideMenuView();

            BindingContext = _viewModel = new ReportsViewModel();
        }

        // Deselect item.
        private void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            menuItems.SelectedItem = null;
        }

        // Show side menu.
        private void ShowMenuCommand(object sender, EventArgs e) {
            ShowMenu();
        }

        /// <summary>
        /// Make some visual changes of current page through navigating process (hide side menu or smt...)
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() {
            SlideMenu.HideWithoutAnimations();
        }
    }
}
