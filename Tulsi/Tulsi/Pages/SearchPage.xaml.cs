using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Tulsi.ViewModels;
using SlideOverKit;

namespace Tulsi
{
    public partial class SearchPage : MenuContainerPage
    {
        public SearchPage()
        {
            InitializeComponent();

            SearchViewModel svm = ((App)Application.Current).SearchVM;
            SearchResultListView.ItemsSource = svm.Result;
            SearchResultListView.ItemSelected += (sender, e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };

            //Slide menu creating
            SlideMenu = ((App)Application.Current).SideMenu;

            //Toolbar taps
            TapGestureRecognizer ToolbarTap1 = new TapGestureRecognizer();
            ToolbarTap1.Tapped += (s, e) =>
            {
                this.ShowMenu();
            };
            Menu.GestureRecognizers.Add(ToolbarTap1);

            //In page navigation
            TapGestureRecognizer BuyersTap = new TapGestureRecognizer();
            BuyersTap.Tapped += (s, e) =>
            {
                BuyersArea.BackgroundColor = Color.FromHex("#027CE9");
                BuyersAreaLabel.TextColor = Color.White;
                GrowersArea.BackgroundColor = Color.FromHex("#FFFFFF");
                GrowersAreaLabel.TextColor = Color.FromHex("#CCCCCC");
            };
            BuyersArea.GestureRecognizers.Add(BuyersTap);
            BuyersAreaLabel.GestureRecognizers.Add(BuyersTap);

            TapGestureRecognizer GrowersTap = new TapGestureRecognizer();
            GrowersTap.Tapped += (s, e) =>
            {
                BuyersArea.BackgroundColor = Color.FromHex("#FFFFFF");
                BuyersAreaLabel.TextColor = Color.FromHex("#CCCCCC");
                GrowersArea.BackgroundColor = Color.FromHex("#027CE9");
                GrowersAreaLabel.TextColor = Color.White;
            };
            GrowersArea.GestureRecognizers.Add(GrowersTap);

        }
    }
}
