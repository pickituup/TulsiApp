using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.Helpers;
using Tulsi.NavigationFramework;
using Tulsi.ViewModels;
using Xamarin.Forms;

namespace Tulsi {
    public partial class ChatPage : ContentPage, IView {

        private readonly ChatViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public ChatPage() {
            InitializeComponent();

            BindingContext = _viewModel = new ChatViewModel();
        }

        /// <summary>
        ///     Make some visual changes of current page through navigating process (hide side menu or smt...)
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() {
            
        }

        /// <summary>
        ///     Occurs only for Android (not for iOS).
        ///     False navigate out from page, true - stay on this page.
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed() {
            BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack();
            return true;
        }

        private void BackButtonCommand(object sender, EventArgs e) {
            BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack();
        }

        public void Dispose() {
            _viewModel.Dispose();
        }
    }
}
