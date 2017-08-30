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

namespace Tulsi {
    public partial class SettingsPage : MenuContainerPage, IView {

        private readonly SettingsViewModel _viewModel;

        public SettingsPage() {
            InitializeComponent();

            SlideMenu = new SideMenuView();

            BindingContext = _viewModel = new SettingsViewModel();
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

        public void Dispose() {
            
        }

        public void ReSubscribe() {
            
        }
    }
}
