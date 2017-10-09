using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Tulsi.Controls;
using Tulsi.NavigationFramework;
using Tulsi.Helpers;
using Tulsi.ViewModels;

/// <summary>
/// TODO: define new namespace for all pages, Tulsi.Pages
/// </summary>
namespace Tulsi {
    public partial class LoginPage : ContentPage, IView {

        private readonly LoginPageViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public LoginPage() {
            InitializeComponent();

            BindingContext = _viewModel = new LoginPageViewModel();


            ////Taps
            //TapGestureRecognizer loginTapGestureRecognizer = new TapGestureRecognizer();
            //loginTapGestureRecognizer.Tapped += (s, e) => {
            //    // remove that
            //    //DashboardPage dp = new DashboardPage();
            //    //Application.Current.MainPage = new NavigationPage(dp);

            //    BaseSingleton<ViewSwitchingLogic>.Instance.BuildNavigationStack(ViewType.DashboardPage);
            //};
            //LoginLink.GestureRecognizers.Add(loginTapGestureRecognizer);

            //TapGestureRecognizer tapGestureRecognizer2 = new TapGestureRecognizer();
            //tapGestureRecognizer2.Tapped += (s, e) => {
            //    DisplayAlert("Navigation", "Sign up action", "OK");
            //};
            //SignupLink.GestureRecognizers.Add(tapGestureRecognizer2);

            //TapGestureRecognizer forgotPasswordTapGestureRecognizer = new TapGestureRecognizer();
            //forgotPasswordTapGestureRecognizer.Tapped += (s, e) => {
            //    BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.PasswordRecoveryPage);
            //};
            //ForgotPasswordLink.GestureRecognizers.Add(forgotPasswordTapGestureRecognizer);

            //EntryEx EmailEntry = new EntryEx() {
            //    BorderWidth = 2,
            //    BorderRadius = 50,
            //    BorderColor = Color.FromHex("#d9d9d9"),
            //    PlaceholderColor = Color.FromHex("#d9d9d9"),
            //    Placeholder = "Email",
            //    HeightRequest = 20,
            //    LeftPadding = 30,
            //    RightPadding = 30,
            //    Margin = 10,
            //    FontSize = 18,
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    Keyboard = Keyboard.Email,
            //};
            //LoginGrid.Children.Add(EmailEntry);
            //Grid.SetRow(EmailEntry, 3);
            //Grid.SetColumn(EmailEntry, 1);

            //EntryEx PasswordEntry = new EntryEx() {
            //    BorderWidth = 2,
            //    BorderRadius = 50,
            //    BorderColor = Color.FromHex("#d9d9d9"),
            //    PlaceholderColor = Color.FromHex("#d9d9d9"),
            //    Placeholder = "Password",
            //    HeightRequest = 20,
            //    LeftPadding = 30,
            //    RightPadding = 30,
            //    Margin = 10,
            //    FontSize = 18,
            //    HorizontalOptions = LayoutOptions.FillAndExpand,
            //    VerticalOptions = LayoutOptions.FillAndExpand,
            //    IsPassword = true,
            //};
            //LoginGrid.Children.Add(PasswordEntry);
            //Grid.SetRow(PasswordEntry, 4);
            //Grid.SetColumn(PasswordEntry, 1);
        }

        /// <summary>
        /// Make some visual changes of current page through navigating process (hide side menu or smt...)
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() {
            
        }

        protected override void OnDisappearing() {
            base.OnDisappearing();
        }

        /// <summary>
        ///     Occurs only for Android (not for iOS).
        ///     False navigate out from page, true - staying in this page.
        /// </summary>
        /// <returns></returns>
        protected override bool OnBackButtonPressed() {
            BaseSingleton<ViewSwitchingLogic>.Instance.NavigateOneStepBack();
            return true;
        }

        public void Dispose() {
            _viewModel.Dispose();
        }       
    }
}