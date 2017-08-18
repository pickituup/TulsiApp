using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Tulsi.ViewModels;
using SlideOverKit;
using Tulsi.NavigationFramework;
using Tulsi.SharedService;

namespace Tulsi {
    public partial class LadaanPage : MenuContainerPage, IView {

        private readonly LadaanViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public LadaanPage() {
            InitializeComponent();

            SlideMenu = new SideMenuView();

            BindingContext = _viewModel = new LadaanViewModel();

            int hd = DependencyService.Get<IDisplaySize>().GetHeightDiP();
            AbsoluteLayout.SetLayoutBounds(SideMenuOverlay, new Rectangle(0, 0, 0.9, hd - 20));
        }

        private void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            menuItems.SelectedItem = null;
        }

        private void ShowMenuCommand(object sender, EventArgs e) {
            ShowMenu();
        }
    }
}
