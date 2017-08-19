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
    public partial class LatePaymentsPage : MenuContainerPage, IView
    {
        private LatePaymentsViewModel _viewModel;

        public LatePaymentsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new LatePaymentsViewModel();

            //Slide menu creating
            SlideMenu = ((App)Application.Current).SideMenu;
        }

        /// <summary>
        /// Make some visual changes of current page through navigating process (hide side menu or smt...)
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() {
            SlideMenu.HideWithoutAnimations();
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
