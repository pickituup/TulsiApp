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
    public partial class StockPendingDetailsPage : MenuContainerPage
    {
        public StockPendingDetailsPage()
        {
            InitializeComponent();

            StockPendingDetailsViewModel spdvm = ((App)Application.Current).StockPendingDetailsVM;
            BindingContext = spdvm;
            StockPendingDetailsListView.ItemsSource = spdvm.StockPendingDetails;
            StockPendingDetailsListView.ItemSelected += (sender, e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };

            int hd = DependencyService.Get<IDisplaySize>().GetHeightDiP();
            int wd = DependencyService.Get<IDisplaySize>().GetWidthDiP();
            AbsoluteLayout.SetLayoutBounds(SideMenuOverlay, new Rectangle(0, 0, 0.9, hd - 20));


            //Slide menu creating
            SlideMenu = ((App)Application.Current).SideMenu;

            //Toolbar taps
            TapGestureRecognizer ToolbarTap1 = new TapGestureRecognizer();
            ToolbarTap1.Tapped += (s, e) =>
            {
                this.ShowMenu();
            };
            Menu.GestureRecognizers.Add(ToolbarTap1);

            TapGestureRecognizer ToolbarTap2 = new TapGestureRecognizer();
            ToolbarTap2.Tapped += (s, e) =>
            {
                SearchPage sp = new SearchPage();
                Application.Current.MainPage.Navigation.PushAsync(sp);
            };
            Search.GestureRecognizers.Add(ToolbarTap2);

        }
    }
}
