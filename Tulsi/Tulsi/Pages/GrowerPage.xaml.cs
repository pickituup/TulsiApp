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
    public partial class GrowerPage : MenuContainerPage
    {
        public GrowerPage()
        {
            InitializeComponent();

            GrowerViewModel gvm = new GrowerViewModel();
            DashboardViewModel dvm = new DashboardViewModel();
            BindingContext = dvm;

            int hd = DependencyService.Get<IDisplaySize>().GetHeightDiP();
            int wd = DependencyService.Get<IDisplaySize>().GetWidthDiP();
            AbsoluteLayout.SetLayoutBounds(SideMenuOverlay, new Rectangle(0, 0, 0.9, hd - 20));

            BuyerViewModel bvm = new BuyerViewModel();
            this.BindingContext = bvm;
            TransactionsListView.ItemsSource = bvm.TransactionsData;
            TransactionsListView.ItemSelected += (sender, e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };

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
            TransactionsListView.ItemSelected += (sender, e) =>
                {
                    GrowerProfilePage gpp = new GrowerProfilePage();
                    Application.Current.MainPage.Navigation.PushAsync(gpp);
                };

            SfChart chart = new SfChart();
            DoughnutSeries doughnutSeries = new DoughnutSeries()
            {
                ItemsSource = gvm.ChartData,
                XBindingPath = "Name",
                YBindingPath = "Value",
                DoughnutCoefficient = 0.7,
                ExplodeIndex = 0
            };
            List<Color> colors = new List<Color>()
            {
                Color.FromHex("#82DA69"),
                Color.FromHex("#9EE5FC"),
            };

            doughnutSeries.ColorModel.Palette = ChartColorPalette.Custom;
            doughnutSeries.ColorModel.CustomBrushes = colors;
            chart.Series.Add(doughnutSeries);

            chart.HorizontalOptions = LayoutOptions.Center;
            chart.VerticalOptions = LayoutOptions.StartAndExpand;
            chart.WidthRequest = 180;
            chart.HeightRequest = 180;
            //chart.BackgroundColor = Color.FromHex("#F3F3F3");
            ChartGrid.Children.Add(chart);

            StackLayout MiddleStack = new StackLayout()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor=Color.White
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

            TransactionsListView.ItemsSource = gvm.TransactionsData;
            TransactionsListView.ItemSelected += (sender, e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };
        }

        void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null)
            {
                return; //ItemSelected is called on deselection, which results in SelectedItem being set to null
            }
            GrowerProfilePage gpp = new GrowerProfilePage();
            Application.Current.MainPage.Navigation.PushAsync(gpp);
            //((ListView)sender).SelectedItem = null; //uncomment line if you want to disable the visual selection state.
        }
    }
}
