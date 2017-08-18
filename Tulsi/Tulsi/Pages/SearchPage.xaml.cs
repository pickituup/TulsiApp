using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.NavigationFramework;
using Xamarin.Forms;
using Tulsi.ViewModels;
using SlideOverKit;

namespace Tulsi {
    public partial class SearchPage : MenuContainerPage, IView {

        private readonly SearchViewModel _viewModel;

        public SearchPage() {
            InitializeComponent();

            SlideMenu = new SideMenuView();

            BindingContext = _viewModel = new SearchViewModel();

            //In page navigation
            TapGestureRecognizer BuyersTap = new TapGestureRecognizer();
            BuyersTap.Tapped += (s, e) => {
                BuyersArea.BackgroundColor = Color.FromHex("#027CE9");
                BuyersAreaLabel.TextColor = Color.White;
                GrowersArea.BackgroundColor = Color.FromHex("#FFFFFF");
                GrowersAreaLabel.TextColor = Color.FromHex("#CCCCCC");
            };
            BuyersArea.GestureRecognizers.Add(BuyersTap);
            BuyersAreaLabel.GestureRecognizers.Add(BuyersTap);

            TapGestureRecognizer GrowersTap = new TapGestureRecognizer();
            GrowersTap.Tapped += (s, e) => {
                BuyersArea.BackgroundColor = Color.FromHex("#FFFFFF");
                BuyersAreaLabel.TextColor = Color.FromHex("#CCCCCC");
                GrowersArea.BackgroundColor = Color.FromHex("#027CE9");
                GrowersAreaLabel.TextColor = Color.White;
            };
            GrowersArea.GestureRecognizers.Add(GrowersTap);

        }

        private void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e) {
            menuItems.SelectedItem = null;
        }

        private void ShowMenuCommand(object sender, EventArgs e) {
            ShowMenu();
        }
    }
}
