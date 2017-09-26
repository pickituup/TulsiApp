using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.NavigationFramework;
using Tulsi.ViewModels.Content;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tulsi.Pages.Content {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PasscodeView : ContentView, IView {

        private readonly PasscodeViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public PasscodeView() {
            InitializeComponent();

            BindingContext = _viewModel = new PasscodeViewModel();
        }

        public void ApplyVisualChangesWhileNavigating() {

        }

        public void Dispose() {
            _viewModel.Dispose();
        }
    }
}