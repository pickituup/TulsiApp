using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.NavigationFramework;
using Xamarin.Forms;
using Tulsi.ViewModels;

namespace Tulsi {
    public partial class BuyerProfilePage : ContentPage, IView {
        private BuyerProfileViewModel _viewModel;

        public BuyerProfilePage() {
            InitializeComponent();

            _viewModel = new BuyerProfileViewModel();
            BindingContext = _viewModel;

            //ProfileViewModel pvm = new ProfileViewModel();
            //ProfileTransactionsListView.ItemsSource = pvm.TransactionsData;
            //ProfileTransactionsListView.ItemSelected += (sender, e) => {
            //    ((ListView)sender).SelectedItem = null;
            //};

            TapGestureRecognizer CloseTap = new TapGestureRecognizer();
            CloseTap.Tapped += (s, e) => {
                Application.Current.MainPage.Navigation.PopAsync();
            };
            Close.GestureRecognizers.Add(CloseTap);
        }

        /// <summary>
        /// Make some visual changes of current page through navigating process (hide side menu or smt...)
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() {
            
        }
    }
}
