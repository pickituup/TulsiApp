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
using Tulsi.Helpers;

namespace Tulsi {
    public partial class SettingsPage : MenuContainerPage, IView {

        private readonly SettingsViewModel _viewModel;

        public SettingsPage() {
            InitializeComponent();

            SlideMenu = new SideMenuView();

            BindingContext = _viewModel = new SettingsViewModel();

            _viewModel.Spot = spot_ConentView;
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
        ///    Autohide side menu.
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() {
            SlideMenu.HideWithoutAnimations();
        }

        /// <summary>
        ///     Occurs only for Android (not for iOS).
        ///     False navigate out from page, true - staying in this page.
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed() {
            if (_viewModel.IsImportedViewVisible) {
                _viewModel.NativeSenderCloseView();
                return true;
            } else {
                BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack();
                return true;
            }
        }

        public void Dispose() {
            _viewModel.Dispose();
            ((IView)(SlideMenu)).Dispose();
        }
    }
}
