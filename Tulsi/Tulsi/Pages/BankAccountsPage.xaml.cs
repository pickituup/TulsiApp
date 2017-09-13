using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.ViewModels;
using Xamarin.Forms;
using SlideOverKit;
using Tulsi.SharedService;
using Tulsi.NavigationFramework;
using Tulsi.Helpers;

namespace Tulsi {
    public partial class BankAccountsPage : MenuContainerPage, IView {
        private BankAccountsPageViewModel _viewModel;

        /// <summary>
        /// Public ctor.
        /// </summary>
        public BankAccountsPage() {
            InitializeComponent();

            BindingContext = _viewModel = new BankAccountsPageViewModel();

            SlideMenu = new SideMenuView();
        }

        /// <summary>
        ///     Autohide side menu.
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() {
            SlideMenu.HideWithoutAnimations();
        }

        /// <summary>
        ///     Open side menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowMenuCommand(object sender, EventArgs e) {
            ShowMenu();
        }

        /// <summary>
        ///     Occurs only for Android (not for iOS).
        ///     False navigate out from page, true - staying in this page.
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed() {
            BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack();
            return true;
        }

        public void Dispose() {
            _viewModel.Dispose();
            ((IView)(SlideMenu)).Dispose();
        }
    }
}