using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.Helpers;
using Tulsi.NavigationFramework;
using Tulsi.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tulsi.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GodownPage : ContentPage, IView {

        private readonly GodownPageViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public GodownPage() {
            InitializeComponent();

            BindingContext = _viewModel = new GodownPageViewModel();
        }

        public void ApplyVisualChangesWhileNavigating() {
            
        }

        /// <summary>
        ///     Occurs only for Android (not for iOS).
        ///     False navigate out from page, true - staying in this page.
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed() {
            BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack();
            return true;
        }

        public void Dispose() {
            _viewModel.Dispose();
        }
    }
}