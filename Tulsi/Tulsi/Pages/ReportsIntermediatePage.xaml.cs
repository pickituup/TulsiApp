using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.NavigationFramework;
using Tulsi.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tulsi.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ReportsIntermediatePage : ContentPage, IView {

        private readonly ReportsIntermediatePageViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public ReportsIntermediatePage() {
            InitializeComponent();

            BindingContext = _viewModel = new ReportsIntermediatePageViewModel();

            _viewModel.Spot = spot_ConentView;
        }

        public void ApplyVisualChangesWhileNavigating() {
            
        }

        protected override void OnAppearing() {
            base.OnAppearing();
        }

        protected override void OnDisappearing() {
            base.OnDisappearing();

            _viewModel.Dispose();
        }

        protected override bool OnBackButtonPressed() {
            if (_viewModel.ImportedView == null) {
                return false;
            } else {
                _viewModel.NativeSenderCloseView();
                return true;
            }
        }

        public void Dispose() {
            
        }

        public void ReSubscribe() {
            
        }
    }
}