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

        public BuyerRankingsPage()
        {
            InitializeComponent();

            _viewModel = ((App)Application.Current).BuyerRankingsVM;
            BindingContext = _viewModel;

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
        /// Temporary
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
            BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.BuyerProfilePage);

            ((ListView)sender).SelectedItem = null;
        }

        /// <summary>
        /// Make some visual changes of current page through navigating process (hide side menu or smt...)
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() {
            SlideMenu.HideWithoutAnimations();
        }
    }
}