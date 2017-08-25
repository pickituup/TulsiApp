using System;
using System.Globalization;
using Tulsi.Helpers;
using Tulsi.NavigationFramework;
using Tulsi.Pages.temp;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Tulsi {
    public partial class App : Application {

        public App() {
            InitializeComponent();

            //MainPage = new TempPage();
            //MainPage = new ArrivalPage();

            BaseSingleton<ViewSwitchingLogic>.Instance.BuildNavigationStack(ViewType.LoginPage);
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
