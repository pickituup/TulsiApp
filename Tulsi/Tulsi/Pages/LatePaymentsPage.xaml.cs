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
    public partial class LatePaymentsPage : MenuContainerPage
    {
        public LatePaymentsPage()
        {
            InitializeComponent();

            LatePaymentsViewModel lpvm = ((App)Application.Current).LatePaymentsVM;
            LatePaymentsListView.ItemsSource = lpvm.LatePayments;
            LatePaymentsListView.ItemSelected += (sender, e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };

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
                BuyerProfilePage bpp = new BuyerProfilePage();
                Application.Current.MainPage.Navigation.PushAsync(bpp);
            };
            LatePaymentsListView.GestureRecognizers.Add(InPageNavigationTap1);
        }
    }
}
