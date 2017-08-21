using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.ViewModels;
using Xamarin.Forms;
using SlideOverKit;
using Tulsi.SharedService;
using Tulsi.NavigationFramework;

namespace Tulsi {
    public partial class BankAccountsPage : MenuContainerPage, IView {
        private BankAccountsViewModel _viewModel;

        /// <summary>
        /// Public ctor.
        /// </summary>
        public BankAccountsPage() {
            InitializeComponent();

            BindingContext = _viewModel = new BankAccountsViewModel();

            SlideMenu = new SideMenuView();

            int hd = DependencyService.Get<IDisplaySize>().GetHeightDiP();
            // AbsoluteLayout.SetLayoutBounds(SideMenuOverlay, new Rectangle(0, 0, 0.9, hd - 20));


            //Background1.Source = ImageSource.FromResource("Tulsi.Images.bank_background.png");
            // Background2.Source = ImageSource.FromResource("Tulsi.Images.bank_background.png");
            Icici.Source = ImageSource.FromResource("Tulsi.Images.icici_logo.png");
            PNB.Source = ImageSource.FromResource("Tulsi.Images.pnb_logo.png");

            //Slide menu creating

            //Toolbar taps
            //TapGestureRecognizer ToolbarTap1 = new TapGestureRecognizer();
            //ToolbarTap1.Tapped += (s, e) => {
            //    this.ShowMenu();
            //};
            //Menu.GestureRecognizers.Add(ToolbarTap1);

            //TapGestureRecognizer ToolbarTap2 = new TapGestureRecognizer();
            //ToolbarTap2.Tapped += (s, e) => {
            //    SearchPage sp = new SearchPage();
            //    Application.Current.MainPage.Navigation.PushAsync(sp);
            //};
            //Search.GestureRecognizers.Add(ToolbarTap2);

            //In page navigation
            TapGestureRecognizer InPageNavigationTap1 = new TapGestureRecognizer();
            InPageNavigationTap1.Tapped += (s, e) => {
                BankAccountDetailsPage badp = new BankAccountDetailsPage();
                Application.Current.MainPage.Navigation.PushAsync(badp);
            };
            Account1.GestureRecognizers.Add(InPageNavigationTap1);
            Account2.GestureRecognizers.Add(InPageNavigationTap1);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() {
            SlideMenu.HideWithoutAnimations();
        }

        /// <summary>
        /// Opens side menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowMenuCommand(object sender, EventArgs e) {
            ShowMenu();
        }
    }
}