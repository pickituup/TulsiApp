using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.NavigationFramework;
using Tulsi.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tulsi.Pages.Content {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BankAccountsView : ContentView, IView {

        private BankAccountsViewModel _viewModel;

        public BankAccountsView() {
            InitializeComponent();

            BindingContext = _viewModel = new BankAccountsViewModel();
        }

        public void ApplyVisualChangesWhileNavigating() {
        }
    }
}