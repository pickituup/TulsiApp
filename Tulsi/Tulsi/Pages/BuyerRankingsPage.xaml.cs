using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Tulsi.NavigationFramework;
using Tulsi.Helpers;
using Xamarin.Forms;
using Tulsi.ViewModels;
using SlideOverKit;
using Tulsi.SharedService;

namespace Tulsi
{
    public partial class BuyerRankingsPage : MenuContainerPage, IView
    {
        private BuyerRankingsViewModel _viewModel;

        /// <summary>
        /// Public ctor
        /// </summary>
        public BuyerRankingsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new BuyerRankingsViewModel();

            _viewModel.MovableSpot = _spot_ConentView;

            SlideMenu = new SideMenuView();
        }

        /// <summary>
        /// Open side menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowMenuTapped(object sender, EventArgs e) {
            ShowMenu();
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
            if (_viewModel.SelectedBuyerRank == null) {
                return false;
            }
            else {
                _viewModel.SelectedBuyerRank = null;

                return true;
            }
        }
    }
}