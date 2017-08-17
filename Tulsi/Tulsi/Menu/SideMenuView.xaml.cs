using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using SlideOverKit;
using Tulsi.NavigationFramework;
using Tulsi.ViewModels.Menu;

namespace Tulsi {
    public partial class SideMenuView : SlideMenuView, IView {

        /// <summary>
        ///     ctor().
        /// </summary>
        public SideMenuView() {
            InitializeComponent();

            int wd = DependencyService.Get<IDisplaySize>().GetWidthDiP();
            WidthRequest = wd * 0.65;
            MenuOrientations = MenuOrientation.LeftToRight;
            IsFullScreen = true;
            AnimationDurationMillisecond = 500;
            BackgroundViewColor = GetPlatformColor();
            BackgroundColor = Color.FromHex("#ffffff");

            BindingContext = new SideMenuViewModel();

            // DashboardPage
            // BuyerPage
            // GrowerPage
            // AuditLogPage
            // ReportsPage
            // ChatPage
            // SettingsPage
            // ProfilePage
            // ProfitPage
        }

        private Color GetPlatformColor() {
            switch (Device.RuntimePlatform) {
                case Device.iOS:
                    return Color.FromHex("#33000000");
                case Device.Android:
                    return Color.FromHex("#33000000");
                default:
                    return Color.Accent;
            }
        }
    }
}