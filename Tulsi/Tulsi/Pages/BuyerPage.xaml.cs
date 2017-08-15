using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Syncfusion.SfChart.XForms;
using Tulsi.ViewModels;
using SlideOverKit;

namespace Tulsi
{
    public partial class BuyerPage : MenuContainerPage
    {
        public BuyerPage()
        {
            InitializeComponent();

            DashboardViewModel dvm = new DashboardViewModel();
            BindingContext = dvm;


            int hd = DependencyService.Get<IDisplaySize>().GetHeightDiP();
            AbsoluteLayout.SetLayoutBounds(SideMenuOverlay, new Rectangle(0, 0, 0.9, hd - 20));

            SfChart chart = new SfChart();
            DoughnutSeries doughnutSeries = new DoughnutSeries()
            {
                ItemsSource = dvm.ChartData,
                XBindingPath = "Name",
                YBindingPath = "Value",
                DoughnutCoefficient = 0.7,
                ExplodeIndex = 0
            };
            List<Color> colors = new List<Color>()
            {
                Color.FromHex("#82DA69"),
                Color.FromHex("#E47132"),
                Color.FromHex("#9EE5FC"),
            };

            doughnutSeries.ColorModel.Palette = ChartColorPalette.Custom;
            doughnutSeries.ColorModel.CustomBrushes = colors;
            chart.WidthRequest = 180;
            chart.HeightRequest = 180;
            //chart.BackgroundColor = Color.FromHex("#F3F3F3");
            chart.Series.Add(doughnutSeries);

            chart.Title.TextColor = Color.FromHex("#cccccc");
            chart.HorizontalOptions = LayoutOptions.Center;
            chart.VerticalOptions = LayoutOptions.Center;
            ChartGrid.Children.Add(chart);

            StackLayout MiddleStack = new StackLayout()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White
            };
            Label MiddleText1 = new Label()
            {
                Text = "23%",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold

            };
            Label MiddleText2 = new Label()
            {
                Text = "mobile",
                FontSize = 10,
                FontAttributes = FontAttributes.Bold

            };
            MiddleStack.Children.Add(MiddleText1);
            MiddleStack.Children.Add(MiddleText2);
            ChartGrid.Children.Add(MiddleStack);

            BuyerViewModel bvm = new BuyerViewModel();
            this.BindingContext = bvm;
            TransactionsListView.ItemsSource = bvm.TransactionsData;

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

            TapGestureRecognizer InPageNavigationTap2 = new TapGestureRecognizer();
            InPageNavigationTap2.Tapped += (s, e) =>
            {
                BuyerRankingsPage brp = new BuyerRankingsPage();
                Application.Current.MainPage.Navigation.PushAsync(brp);
            };
            Ranks.GestureRecognizers.Add(InPageNavigationTap2);
            RanksLabel.GestureRecognizers.Add(InPageNavigationTap2);

            TapGestureRecognizer InPageNavigationTap3 = new TapGestureRecognizer();
            InPageNavigationTap3.Tapped += (s, e) =>
            {
                LatePaymentsPage lpp = new LatePaymentsPage();
                Application.Current.MainPage.Navigation.PushAsync(lpp);
            };
            LatePayments.GestureRecognizers.Add(InPageNavigationTap3);
            LatePaymentsLabel.GestureRecognizers.Add(InPageNavigationTap3);
            RanksLabel.GestureRecognizers.Add(InPageNavigationTap2);

        }
        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            BuyerProfilePage bpp = new BuyerProfilePage();
            Application.Current.MainPage.Navigation.PushAsync(bpp);
            //((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.
        }
    }
}
