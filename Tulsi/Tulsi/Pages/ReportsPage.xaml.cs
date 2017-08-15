using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using SlideOverKit;

namespace Tulsi
{
    public partial class ReportsPage : MenuContainerPage
    {
        public ReportsPage()
        {
            InitializeComponent();


            int hd = DependencyService.Get<IDisplaySize>().GetHeightDiP();
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
                BankAccountsPage bap = new BankAccountsPage();
                Application.Current.MainPage.Navigation.PushAsync(bap);
            };
            BankReport.GestureRecognizers.Add(InPageNavigationTap1);

            TapGestureRecognizer InPageNavigationTap2 = new TapGestureRecognizer();
            InPageNavigationTap2.Tapped += (s, e) =>
            {
                GrowerPage gp = new GrowerPage();
                Application.Current.MainPage.Navigation.PushAsync(gp);
            };
            GrowerReport.GestureRecognizers.Add(InPageNavigationTap2);

            TapGestureRecognizer InPageNavigationTap3 = new TapGestureRecognizer();
            InPageNavigationTap3.Tapped += (s, e) =>
            {
                BuyerPage bp = new BuyerPage();
                Application.Current.MainPage.Navigation.PushAsync(bp);
            };
            BuyerReport.GestureRecognizers.Add(InPageNavigationTap3);

            TapGestureRecognizer InPageNavigationTap4 = new TapGestureRecognizer();
            InPageNavigationTap4.Tapped += (s, e) =>
            {
                ArrivalPage ap = new ArrivalPage();
                Application.Current.MainPage.Navigation.PushAsync(ap);
            };
            ArrivalReport.GestureRecognizers.Add(InPageNavigationTap4);

            TapGestureRecognizer InPageNavigationTap5 = new TapGestureRecognizer();
            InPageNavigationTap5.Tapped += (s, e) =>
            {
                ExpensesPage ep = new ExpensesPage();
                Application.Current.MainPage.Navigation.PushAsync(ep);
            };
            ExpensesReport.GestureRecognizers.Add(InPageNavigationTap5);

            TapGestureRecognizer InPageNavigationTap6 = new TapGestureRecognizer();
            InPageNavigationTap6.Tapped += (s, e) =>
            {
                AuditLogPage alp = new AuditLogPage();
                Application.Current.MainPage.Navigation.PushAsync(alp);
            };
            AuditLogReport.GestureRecognizers.Add(InPageNavigationTap6);
        }
    }
}
