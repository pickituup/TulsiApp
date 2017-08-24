using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.NavigationFramework;
using Tulsi.Helpers;
using Xamarin.Forms;
using Tulsi.ViewModels;
using SlideOverKit;
using Tulsi.SharedService;

namespace Tulsi
{
    /// <summary>
    /// TODO: LatePaymentsPage use similar 'hide/show behavior' as in BuyerRankingsPage, BuyerPage. Try
    /// to define abstract core of that behavior
    /// </summary>
    public partial class LatePaymentsPage : MenuContainerPage, IView
    {
        private LatePaymentsViewModel _viewModel;

        /// <summary>
        /// Public ctor.
        /// </summary>
        public LatePaymentsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new LatePaymentsViewModel();
            _viewModel.MovableSpot = _spot_ConentView;

            //Slide menu creating
            SlideMenu = new SideMenuView();
        }

        /// <summary>
        /// Make some visual changes of current page through navigating process (hide side menu or smt...)
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() {
            SlideMenu.HideWithoutAnimations();
        }

        /// <summary>
        /// Occurs only for Android (not for iOS).
        /// False navigate out from page, true - keep staing in this page.
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed() {
            if (_viewModel.SelectedItem == null) {
                return false;
            }
            else {
                _viewModel.SelectedItem = null;

                return true;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowMenuCommand(object sender, EventArgs e) {
            ShowMenu();
        }
    }
}
