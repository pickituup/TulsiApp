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
    public partial class AddReportAccessPage : ContentPage, IView {

        private AddReportAccessPageViewModel _viewModel;

        /// <summary>
        /// 
        /// </summary>
        public AddReportAccessPage() {
            InitializeComponent();

            BindingContext = _viewModel = new AddReportAccessPageViewModel();
        }

        /// <summary>
        /// 
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() { }

        /// <summary>
        /// 
        /// </summary>
        public void Dispose() { }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed() {
            _viewModel.LeavePage();

            return true;
        }
    }
}
