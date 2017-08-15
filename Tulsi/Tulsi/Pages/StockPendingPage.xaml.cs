using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using SlideOverKit;

namespace Tulsi
{
    public partial class StockPendingPage : MenuContainerPage
    {
        public StockPendingPage()
        {
            InitializeComponent();

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

            //In page navigation
            TapGestureRecognizer InPageNavigationTap1 = new TapGestureRecognizer();
            InPageNavigationTap1.Tapped += (s, e) =>
            {
                StockPendingDetailsPage spdp = new StockPendingDetailsPage();
                Application.Current.MainPage.Navigation.PushAsync(spdp);
            };
            Month1.GestureRecognizers.Add(InPageNavigationTap1);
            Month2.GestureRecognizers.Add(InPageNavigationTap1);
            Month3.GestureRecognizers.Add(InPageNavigationTap1);
            Month4.GestureRecognizers.Add(InPageNavigationTap1);
            Month5.GestureRecognizers.Add(InPageNavigationTap1);

            Month5.Text=DateTime.Today.ToString("MMM").ToUpper();
            Month4.Text= DateTime.Today.AddMonths(-1).ToString("MMM").ToUpper();
            Month3.Text = DateTime.Today.AddMonths(-2).ToString("MMM").ToUpper();
            Month2.Text = DateTime.Today.AddMonths(-3).ToString("MMM").ToUpper();
            Month1.Text = DateTime.Today.AddMonths(-4).ToString("MMM").ToUpper();
        }
    }
}
