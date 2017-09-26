using System;
using System.Globalization;
using Tulsi.Helpers;
using Tulsi.NavigationFramework;
using Tulsi.Pages;
using Tulsi.Pages.temp;
using Tulsi.SharedService;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Tulsi {
    public partial class App : Application {

        public App() {
            InitializeComponent();

            //MainPage = new PasscodePage();

            if (DependencyService.Get<ISQLiteService>().IsPasscodeExist()) {
                BaseSingleton<ViewSwitchingLogic>.Instance.BuildNavigationStack(ViewType.PasscodePage);
            } else {
                BaseSingleton<ViewSwitchingLogic>.Instance.BuildNavigationStack(ViewType.TutorialPage);
            }
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
