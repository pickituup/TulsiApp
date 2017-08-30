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
        private BankAccountsViewModel _viewModel;

        /// <summary>
        /// Public ctor.
        /// </summary>
        public BankAccountsPage() {
            InitializeComponent();

            BindingContext = _viewModel = new BankAccountsViewModel();

            SlideMenu = new SideMenuView();
        }

        /// <summary>
        /// 
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() {
            SlideMenu.HideWithoutAnimations();
        }

        public void Dispose() {
            _viewModel.Dispose();
        }

        public void ReSubscribe() {
            
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