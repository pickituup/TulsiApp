using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Tulsi.ViewModels;
using Syncfusion.DataSource;
using SlideOverKit;
using Tulsi.NavigationFramework;
using Tulsi.SharedService;

namespace Tulsi {
    public partial class TodayRatesPage : MenuContainerPage, IView {

        private readonly TodayRatesViewModel _viewModel;

        public TodayRatesPage() {
            InitializeComponent();

            SlideMenu = new SideMenuView();

            BindingContext = _viewModel = new TodayRatesViewModel();

            int hd = DependencyService.Get<IDisplaySize>().GetHeightDiP();
            AbsoluteLayout.SetLayoutBounds(SideMenuOverlay, new Rectangle(0, 0, 0.9, hd - 20));
        }

        private void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            todayMenuItems.SelectedItem = null;

            if (todayMenuItems2.IsVisible) {
                todayMenuItems2.SelectedItem = null;
            }
        }

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
