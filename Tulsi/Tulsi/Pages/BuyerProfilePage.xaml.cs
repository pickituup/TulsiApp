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
        private BuyerProfilePageViewModel _viewModel;

        public BuyerProfilePage() {
            InitializeComponent();

            BindingContext = _viewModel = new BuyerProfilePageViewModel();
        }

        /// <summary>
        /// Make some visual changes of current page through navigating process (hide side menu or smt...)
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() {
            
        }

        public void Dispose() {

        }

        public void ReSubscribe() {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
            ((ListView)sender).SelectedItem = null;
        }
    }
}
