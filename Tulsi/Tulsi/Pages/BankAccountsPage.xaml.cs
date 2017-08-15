using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using SlideOverKit;

namespace Tulsi
{
    public partial class BankAccountsPage : MenuContainerPage
    {
        public BankAccountsPage()
        {
            InitializeComponent();

            int hd = DependencyService.Get<IDisplaySize>().GetHeightDiP();
           // AbsoluteLayout.SetLayoutBounds(SideMenuOverlay, new Rectangle(0, 0, 0.9, hd - 20));


            //Background1.Source = ImageSource.FromResource("Tulsi.Images.bank_background.png");
           // Background2.Source = ImageSource.FromResource("Tulsi.Images.bank_background.png");
            Icici.Source = ImageSource.FromResource("Tulsi.Images.icici_logo.png");
            PNB.Source = ImageSource.FromResource("Tulsi.Images.pnb_logo.png");

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
                BankAccountDetailsPage badp = new BankAccountDetailsPage();
                Application.Current.MainPage.Navigation.PushAsync(badp);
            };
            Account1.GestureRecognizers.Add(InPageNavigationTap1);
            Account2.GestureRecognizers.Add(InPageNavigationTap1);
        }
    }
}
