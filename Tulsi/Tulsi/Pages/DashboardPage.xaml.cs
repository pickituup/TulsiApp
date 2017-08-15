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

namespace Tulsi
{
    public partial class DashboardPage : MenuContainerPage
    {
        public DashboardPage()
        {
            InitializeComponent();

            DashboardViewModel dvm = ((App)Application.Current).DashboardVM;
            BindingContext = dvm;

            //this.sli

            Photo1.Source = ImageSource.FromResource("Tulsi.Images.photo1.png");
             Info1.Source = ImageSource.FromResource("Tulsi.Images.info.png");
            User.Source = ImageSource.FromResource("Tulsi.Images.users.png");

            Photo2.Source = ImageSource.FromResource("Tulsi.Images.photo1.png");
            Info2.Source = ImageSource.FromResource("Tulsi.Images.info.png");
            User2.Source = ImageSource.FromResource("Tulsi.Images.users.png");

            Photo3.Source = ImageSource.FromResource("Tulsi.Images.photo1.png");
            Info3.Source = ImageSource.FromResource("Tulsi.Images.info.png");
            User3.Source = ImageSource.FromResource("Tulsi.Images.users.png");

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
            TapGestureRecognizer InPageNavigationTap1 = new TapGestureRecognizer();
            InPageNavigationTap1.Tapped += (s, e) =>
            {
                BuyerPage bp = new BuyerPage();
                Application.Current.MainPage.Navigation.PushAsync(bp);
            };
            ChartGrid.GestureRecognizers.Add(InPageNavigationTap1);

            TapGestureRecognizer InPageNavigationTap2 = new TapGestureRecognizer();
            InPageNavigationTap2.Tapped += (s, e) =>
            {
                TodayRatesPage trp = new TodayRatesPage();
                Application.Current.MainPage.Navigation.PushAsync(trp);
            };
            RatesGrid.GestureRecognizers.Add(InPageNavigationTap2);

            TapGestureRecognizer InPageNavigationTap3 = new TapGestureRecognizer();
            InPageNavigationTap3.Tapped += (s, e) =>
            {
                LadaanPage lp = new LadaanPage();
                Application.Current.MainPage.Navigation.PushAsync(lp);
            };
            ExtraRatesGrid.GestureRecognizers.Add(InPageNavigationTap3);

            TapGestureRecognizer InPageNavigationTap4 = new TapGestureRecognizer();
            InPageNavigationTap4.Tapped += (s, e) =>
            {
                NewsPage np = new NewsPage();
                Application.Current.MainPage.Navigation.PushAsync(np);
            };
            //News1.GestureRecognizers.Add(InPageNavigationTap4);
            //News2.GestureRecognizers.Add(InPageNavigationTap4);
            //News3.GestureRecognizers.Add(InPageNavigationTap4);

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
            chart.Series.Add(doughnutSeries);

            chart.Title.TextColor = Color.FromHex("#cccccc");
            chart.HorizontalOptions = LayoutOptions.Center;
            chart.VerticalOptions = LayoutOptions.Center;
            //chart.BackgroundColor = Color.FromHex("#F3F3F3");
            chart.BackgroundColor = Color.Transparent;
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
            /*
            ListView NewsListView = new ListView();
            //NewsListView.BindingContext = dvm;
            NewsListView.ItemsSource = dvm.NewsData;
            NewsListView.ItemTemplate = new DataTemplate(() => {
                Grid grid = new Grid
                {

                    RowDefinitions =
                    {
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
                        new RowDefinition { Height = new GridLength(1, GridUnitType.Star) }
                    },
                    ColumnDefinitions =
                    {
                        new ColumnDefinition { Width=new GridLength(2, GridUnitType.Star) },
                        new ColumnDefinition { Width=new GridLength(5, GridUnitType.Star) },
                        new ColumnDefinition { Width=new GridLength(2, GridUnitType.Star) },
                    }
                };
                
                Label picture = new Label { HorizontalTextAlignment = TextAlignment.Center };
                //picture.SetBinding(Label.TextProperty, new Binding("Picture"));
                picture.Text = "Picture";
                Label header = new Label { FontAttributes = FontAttributes.Bold, FontSize = 25 };
                //header.SetBinding(Label.TextProperty, new Binding("Header"));
                header.Text = "Boating to the island";
                 Label edited = new Label { FontSize = 15 };
                //edited.SetBinding(Label.TextProperty, new Binding("Edited"));
                edited.Text = "Midified: date";
                Label icon = new Label { FontSize = 15, HorizontalTextAlignment = TextAlignment.Center };
                //icon.SetBinding(Label.TextProperty, new Binding("Icon"));
                icon.Text = "icon";

                grid.Children.Add(picture);
                grid.Children.Add(header);
                grid.Children.Add(edited);
                grid.Children.Add(icon);
                Grid.SetColumn(header, 1);
                Grid.SetColumn(edited, 1);
                Grid.SetColumn(icon, 2);
                Grid.SetRow(edited, 1);

                return grid;
            });
            MainLayout.Children.Add(NewsListView);
            */


        }
    }
}
