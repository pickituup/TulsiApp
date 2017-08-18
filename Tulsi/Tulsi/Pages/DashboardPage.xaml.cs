using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Tulsi.Controls;
using Tulsi.ViewModels;
using Syncfusion.SfChart.XForms;
using SlideOverKit;
using Tulsi.NavigationFramework;

namespace Tulsi {
    public partial class DashboardPage : MenuContainerPage, IView {

        private readonly DashboardViewModel _viewModel;

        public DashboardPage() {
            InitializeComponent();

            _viewModel = new DashboardViewModel();

            //DashboardViewModel dvm = ((App)Application.Current).DashboardVM;
            BindingContext = _viewModel = new DashboardViewModel();


            Photo1.Source = ImageSource.FromResource("Tulsi.Images.photo1.png");
            Info1.Source = ImageSource.FromResource("Tulsi.Images.info.png");
            User.Source = ImageSource.FromResource("Tulsi.Images.users.png");

            Photo2.Source = ImageSource.FromResource("Tulsi.Images.photo1.png");
            Info2.Source = ImageSource.FromResource("Tulsi.Images.info.png");
            User2.Source = ImageSource.FromResource("Tulsi.Images.users.png");

            Photo3.Source = ImageSource.FromResource("Tulsi.Images.photo1.png");
            Info3.Source = ImageSource.FromResource("Tulsi.Images.info.png");
            User3.Source = ImageSource.FromResource("Tulsi.Images.users.png");


            SlideMenu = new SideMenuView();

            //In page navigation
            TapGestureRecognizer InPageNavigationTap1 = new TapGestureRecognizer();
            InPageNavigationTap1.Tapped += (s, e) => {
                BuyerPage bp = new BuyerPage();
                Application.Current.MainPage.Navigation.PushAsync(bp);
            };
            ChartGrid.GestureRecognizers.Add(InPageNavigationTap1);

            TapGestureRecognizer InPageNavigationTap2 = new TapGestureRecognizer();
            InPageNavigationTap2.Tapped += (s, e) => {
                TodayRatesPage trp = new TodayRatesPage();
                Application.Current.MainPage.Navigation.PushAsync(trp);
            };
            RatesGrid.GestureRecognizers.Add(InPageNavigationTap2);

            TapGestureRecognizer InPageNavigationTap3 = new TapGestureRecognizer();
            InPageNavigationTap3.Tapped += (s, e) => {
                LadaanPage lp = new LadaanPage();
                Application.Current.MainPage.Navigation.PushAsync(lp);
            };
            ExtraRatesGrid.GestureRecognizers.Add(InPageNavigationTap3);

            TapGestureRecognizer InPageNavigationTap4 = new TapGestureRecognizer();
            InPageNavigationTap4.Tapped += (s, e) => {
                NewsPage np = new NewsPage();
                Application.Current.MainPage.Navigation.PushAsync(np);
            };

            SfChart chart = new SfChart();
            DoughnutSeries doughnutSeries = new DoughnutSeries() {
                ItemsSource = _viewModel.ChartData,
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
            chart.Series.Add(doughnutSeries);

            chart.Title.TextColor = Color.FromHex("#cccccc");
            chart.HorizontalOptions = LayoutOptions.Center;
            chart.VerticalOptions = LayoutOptions.Center;
            //chart.BackgroundColor = Color.FromHex("#F3F3F3");
            chart.BackgroundColor = Color.Transparent;
            ChartGrid.Children.Add(chart);

            StackLayout MiddleStack = new StackLayout() {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White
            };
            Label MiddleText1 = new Label() {
                Text = "23%",
                FontSize = 20,
                FontAttributes = FontAttributes.Bold

            };
            Label MiddleText2 = new Label() {
                Text = "mobile",
                FontSize = 10,
                FontAttributes = FontAttributes.Bold

            };
            MiddleStack.Children.Add(MiddleText1);
            MiddleStack.Children.Add(MiddleText2);
            ChartGrid.Children.Add(MiddleStack);



        }

        private void ShowMenuCommand(object sender, EventArgs e) {
            ShowMenu();
        }
    }
}
