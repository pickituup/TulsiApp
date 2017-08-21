using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using SlideOverKit;
using Tulsi.SharedService;
using Tulsi.NavigationFramework;
using Tulsi.ViewModels;

namespace Tulsi {
    public partial class SetupDashboardPage : MenuContainerPage, IView {

        private readonly SetupDashboardViewModel _viewModel;

        public SetupDashboardPage() {
            InitializeComponent();

            SlideMenu = new SideMenuView();

            BindingContext = _viewModel = new SetupDashboardViewModel();
        }

        /// <summary>
        ///     Show side menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowMenuCommand(object sender, EventArgs e) {
            ShowMenu();
        }

        /// <summary>
        ///     Autohide side menu.
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() {
            SlideMenu.HideWithoutAnimations();
        }
    }
}
