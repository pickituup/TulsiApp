using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.NavigationFramework;
using Xamarin.Forms;
using Tulsi.ViewModels;
using SlideOverKit;
using Tulsi.SharedService;

namespace Tulsi {
    public partial class AuditLogPage : MenuContainerPage, IView {

        private readonly AuditLogPageViewModel _viewModel;

        /// <summary>
        ///     Public ctor().
        /// </summary>
        public AuditLogPage() {
            InitializeComponent();

            SlideMenu = new SideMenuView();

            BindingContext = _viewModel = new AuditLogPageViewModel();
        }

        /// <summary>
        /// Show side menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowMenuCommand(object sender, EventArgs e) {
            ShowMenu();
        }

        /// <summary>
        ///     Make some visual changes of current page through navigating process (hide side menu or smt...)
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
