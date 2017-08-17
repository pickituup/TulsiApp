using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Tulsi.NavigationFramework;
using Xamarin.Forms;

namespace Tulsi.Menu {
    public sealed class SideMenuContainer {

        /// <summary>
        ///     Build side menu items.
        /// </summary>
        /// <returns></returns>
        public List<SideMenuItem> BuildSideMenuItems() {
            return new List<SideMenuItem> {
                new SideMenuItem {
                    Title = "Dashboard",
                    Image = ImageSource.FromStream(()=> {
                            Assembly assembly = GetType().GetTypeInfo().Assembly;
                            Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.dashboard_group.png");
                            return stream; }),
                    ViewType = ViewType.DashboardPage },
                new SideMenuItem {
                    Title = "Buyer",
                    Image = ImageSource.FromStream(()=> {
                            Assembly assembly = GetType().GetTypeInfo().Assembly;
                            Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.menu_buyer.png");
                            return stream; }),
                    ViewType = ViewType.LoginPage },
                new SideMenuItem {
                    Title = "Grower",
                    Image = ImageSource.FromStream(()=> {
                            Assembly assembly = GetType().GetTypeInfo().Assembly;
                            Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.menu_grower.png");
                            return stream; }),
                    ViewType = ViewType.LoginPage },
                new SideMenuItem {
                    Title = "Audit Log",
                    Image = ImageSource.FromStream(()=> {
                            Assembly assembly = GetType().GetTypeInfo().Assembly;
                            Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.menu_audit.png");
                            return stream; }),
                    ViewType = ViewType.LoginPage },
                new SideMenuItem {
                    Title = "Report",
                    Image = ImageSource.FromStream(()=> {
                            Assembly assembly = GetType().GetTypeInfo().Assembly;
                            Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.menu_report.png");
                            return stream; }),
                    ViewType = ViewType.LoginPage },
                new SideMenuItem {
                    Title = "Chat",
                    Image = ImageSource.FromStream(()=> {
                            Assembly assembly = GetType().GetTypeInfo().Assembly;
                            Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.menu_chat.png");
                            return stream; }),
                    ViewType = ViewType.LoginPage },
                new SideMenuItem {
                    Title = "Settings",
                    Image = ImageSource.FromStream(()=> {
                            Assembly assembly = GetType().GetTypeInfo().Assembly;
                            Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.menu_settings.png");
                            return stream; }),
                    ViewType = ViewType.LoginPage },
                new SideMenuItem {
                    Title = "Me",
                    Image = ImageSource.FromStream(()=> {
                            Assembly assembly = GetType().GetTypeInfo().Assembly;
                            Stream stream = assembly.GetManifestResourceStream("Tulsi.Images.menu_me.png");
                            return stream; }),
                    ViewType = ViewType.LoginPage }
            };
        }
    }
}
