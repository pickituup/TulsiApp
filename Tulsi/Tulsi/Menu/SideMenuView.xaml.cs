using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using SlideOverKit;

namespace Tulsi
{
    public partial class SideMenuView : SlideOverKit.SlideMenuView
    {
        public SideMenuView()
        {
            InitializeComponent();

            int hd = DependencyService.Get<IDisplaySize>().GetHeightDiP();
            int wd = DependencyService.Get<IDisplaySize>().GetWidthDiP();
            WidthRequest = wd * 0.65;
            //HeightRequest = hd - 15;
            MenuOrientations = MenuOrientation.LeftToRight;
            IsFullScreen = true;
            AnimationDurationMillisecond = 500;

            TapGestureRecognizer tapGestureRecognizer3 = new TapGestureRecognizer();
            tapGestureRecognizer3.Tapped += (s, e) =>
            {
                this.HideWithoutAnimations();
            };
            SideMenuHeaderCloseIcon.GestureRecognizers.Add(tapGestureRecognizer3);


            //Menu taps

            TapGestureRecognizer MenuTap1 = new TapGestureRecognizer();
            MenuTap1.Tapped += (s, e) =>
            {
                BuyerPage bp = new BuyerPage();
                Application.Current.MainPage.Navigation.PushAsync(bp);
            };
            BuyerMenuIcon.GestureRecognizers.Add(MenuTap1);
            BuyerMenuItem.GestureRecognizers.Add(MenuTap1);
            BuyerExtraTap.GestureRecognizers.Add(MenuTap1);

            TapGestureRecognizer MenuTap2 = new TapGestureRecognizer();
            MenuTap2.Tapped += (s, e) =>
            {
                GrowerPage gp = new GrowerPage();
                Application.Current.MainPage.Navigation.PushAsync(gp);
            };
            GrowerMenuIcon.GestureRecognizers.Add(MenuTap2);
            GrowerMenuItem.GestureRecognizers.Add(MenuTap2);
            GrowerExtraTap.GestureRecognizers.Add(MenuTap2);

            TapGestureRecognizer MenuTap3 = new TapGestureRecognizer();
            MenuTap3.Tapped += (s, e) =>
            {
                AuditLogPage ap = new AuditLogPage();
                Application.Current.MainPage.Navigation.PushAsync(ap);
            };
            AuditLogMenuIcon.GestureRecognizers.Add(MenuTap3);
            AuditLogMenuItem.GestureRecognizers.Add(MenuTap3);
            AuditLogExtraTap.GestureRecognizers.Add(MenuTap3);

            TapGestureRecognizer MenuTap4 = new TapGestureRecognizer();
            MenuTap4.Tapped += (s, e) =>
            {
                ReportsPage rp = new ReportsPage();
                Application.Current.MainPage.Navigation.PushAsync(rp);
            };
            ReportMenuIcon.GestureRecognizers.Add(MenuTap4);
            ReportMenuItem.GestureRecognizers.Add(MenuTap4);
            ReportExtraTap.GestureRecognizers.Add(MenuTap4);

            TapGestureRecognizer MenuTap5 = new TapGestureRecognizer();
            MenuTap5.Tapped += (s, e) =>
            {
                ChatPage cp = new ChatPage();
                Application.Current.MainPage.Navigation.PushAsync(cp);
            };
            ChatMenuIcon.GestureRecognizers.Add(MenuTap5);
            ChatMenuItem.GestureRecognizers.Add(MenuTap5);
            ChatExtraTap.GestureRecognizers.Add(MenuTap5);

            TapGestureRecognizer MenuTap6 = new TapGestureRecognizer();
            MenuTap6.Tapped += (s, e) =>
            {
                SettingsPage sp = new SettingsPage();
                Application.Current.MainPage.Navigation.PushAsync(sp);
            };
            SettingsMenuIcon.GestureRecognizers.Add(MenuTap6);
            SettingsMenuItem.GestureRecognizers.Add(MenuTap6);
            SettingsExtraTap.GestureRecognizers.Add(MenuTap6);

            TapGestureRecognizer MenuTap7 = new TapGestureRecognizer();
            MenuTap7.Tapped += (s, e) =>
            {
                ProfilePage pp = new ProfilePage();
                Application.Current.MainPage.Navigation.PushAsync(pp);
            };
            MeMenuIcon.GestureRecognizers.Add(MenuTap7);
            MeMenuItem.GestureRecognizers.Add(MenuTap7);
            MeExtraTap.GestureRecognizers.Add(MenuTap7);

            TapGestureRecognizer MenuTap8 = new TapGestureRecognizer();
            MenuTap8.Tapped += (s, e) =>
            {
                ProfitPage pp = new ProfitPage();
                Application.Current.MainPage.Navigation.PushAsync(pp);
            };
            SideMenuHeaderProfitIcon.GestureRecognizers.Add(MenuTap8);
            
        }
    }
}
