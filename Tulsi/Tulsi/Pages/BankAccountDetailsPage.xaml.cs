using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.NavigationFramework;
using Tulsi.Helpers;
using Xamarin.Forms;
using SlideOverKit;
using Tulsi.SharedService;
using Tulsi.ViewModels;

namespace Tulsi {
    public partial class BankAccountDetailsPage : MenuContainerPage, IView {
        private BankAccountDetailsViewModel _viewModel;

        public BankAccountDetailsPage() {
            InitializeComponent();

            BindingContext = _viewModel = new BankAccountDetailsViewModel();

            SlideMenu = new SideMenuView();
        }

        /// <summary>
        /// IView imlementation
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() {
            SlideMenu.HideWithoutAnimations();
        }

        /// <summary>
        /// Opens side menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowMenuCommand(object sender, EventArgs e) {
            ShowMenu();
        }
    }
}
