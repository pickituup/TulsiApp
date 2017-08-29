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
    public partial class AuditLogView : ContentView, IView {

        private AuditLogViewModel _viewModel;

        public AuditLogView() {
            InitializeComponent();

            BindingContext = _viewModel = new AuditLogViewModel();
        }

        public void ApplyVisualChangesWhileNavigating() {
            _viewModel.Dispose();
        }
    }
}