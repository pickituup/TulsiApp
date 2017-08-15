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
    public partial class ProfitPage : MenuContainerPage
    {
        public ProfitPage()
        {
            InitializeComponent();

            ProfitViewModel pvm = ((App)Application.Current).ProfitVM;
            BindingContext = pvm;

            int hd = DependencyService.Get<IDisplaySize>().GetHeightDiP();
            AbsoluteLayout.SetLayoutBounds(SideMenuOverlay, new Rectangle(0, 0, 0.9, hd - 20));

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

            //Tabs navigation
            TapGestureRecognizer TabTap1 = new TapGestureRecognizer();
            TabTap1.Tapped += (s, e) =>
            {
                QuarterlyArea.BackgroundColor= Color.FromHex("#2793F5");
                QuarterlyLabel.TextColor = Color.White;
                MonthlyArea.BackgroundColor = Color.Transparent;
                MonthlyLabel.TextColor = Color.FromHex("#B3B3B3");
                WeeklyArea.BackgroundColor = Color.Transparent;
                WeeklyLabel.TextColor = Color.FromHex("#B3B3B3");

                pvm.ReportsPeriod = ProfitViewModel.Period.Quarterly;
            };
            QuarterlyArea.GestureRecognizers.Add(TabTap1);

            TapGestureRecognizer TabTap2 = new TapGestureRecognizer();
            TabTap2.Tapped += (s, e) =>
            {
                QuarterlyArea.BackgroundColor = Color.Transparent;
                QuarterlyLabel.TextColor = Color.FromHex("#B3B3B3");
                MonthlyArea.BackgroundColor = Color.FromHex("#2793F5");
                MonthlyLabel.TextColor = Color.White;
                WeeklyArea.BackgroundColor = Color.Transparent;
                WeeklyLabel.TextColor = Color.FromHex("#B3B3B3");

                pvm.ReportsPeriod = ProfitViewModel.Period.Monthly;
            };
            MonthlyArea.GestureRecognizers.Add(TabTap2);

            TapGestureRecognizer TabTap3 = new TapGestureRecognizer();
            TabTap3.Tapped += (s, e) =>
            {
                QuarterlyArea.BackgroundColor = Color.Transparent;
                QuarterlyLabel.TextColor = Color.FromHex("#B3B3B3");
                MonthlyArea.BackgroundColor = Color.Transparent;
                MonthlyLabel.TextColor = Color.FromHex("#B3B3B3");
                WeeklyArea.BackgroundColor = Color.FromHex("#2793F5");
                WeeklyLabel.TextColor = Color.White;

                pvm.ReportsPeriod = ProfitViewModel.Period.Quarterly;
            };
            WeeklyLabel.GestureRecognizers.Add(TabTap3);

            TapGestureRecognizer TabTap4 = new TapGestureRecognizer();
            TabTap4.Tapped += (s, e) =>
            {
                Year1.TextColor = Color.FromHex("#2793F5");
                Year2.TextColor = Color.FromHex("#B3B3B3");

                pvm.Year = 2013;
            };
            Year1.GestureRecognizers.Add(TabTap4);

            TapGestureRecognizer TabTap5 = new TapGestureRecognizer();
            TabTap5.Tapped += (s, e) =>
            {
                Year1.TextColor = Color.FromHex("#B3B3B3");
                Year2.TextColor = Color.FromHex("#2793F5");

                pvm.Year = 2014;
            };
            Year2.GestureRecognizers.Add(TabTap5);

            TapGestureRecognizer TabTap6 = new TapGestureRecognizer();
            TabTap6.Tapped += (s, e) =>
            {
                PaidStatsLabel.TextColor = Color.FromHex("#2793F5");
                AllStatsLabel.TextColor = Color.FromHex("#B3B3B3");
            };
            PaidStatsLabel.GestureRecognizers.Add(TabTap6);

            TapGestureRecognizer TabTap7 = new TapGestureRecognizer();
            TabTap7.Tapped += (s, e) =>
            {
                PaidStatsLabel.TextColor = Color.FromHex("#B3B3B3");
                AllStatsLabel.TextColor = Color.FromHex("#2793F5");

            };
            AllStatsLabel.GestureRecognizers.Add(TabTap7);

            IncomeIcon.Source = ImageSource.FromResource("Tulsi.Images.greenprofiticon.png");
            ExpenseIcon.Source = ImageSource.FromResource("Tulsi.Images.orangeprofiticon.png");
            LossIcon.Source = ImageSource.FromResource("Tulsi.Images.grayprofiticon.png");

            SfChart chart = new SfChart();
            chart.BackgroundColor = Color.FromHex("#F3F3F3");
            //Initializing Primary Axis
            CategoryAxis primaryAxis = new CategoryAxis();
            primaryAxis.IsVisible = false;
            chart.PrimaryAxis = primaryAxis;

            //Initializing Secondary Axis
            NumericalAxis secondaryAxis = new NumericalAxis();
            secondaryAxis.Minimum = 400;
            secondaryAxis.Maximum = 440;
            secondaryAxis.Interval = 20;

            chart.SecondaryAxis = secondaryAxis;

            //Initializing column series
            AreaSeries series = new AreaSeries();

            series.SetBinding(ChartSeries.ItemsSourceProperty, "ChartData");
            series.XBindingPath = "Step";
            series.YBindingPath = "Value";
            series.Color = Color.FromHex("#A9D4FB");
            series.StrokeColor= Color.FromHex("#2793F5");

            chart.Series.Add(series);
            ChartGrid.Children.Add(chart);
            Grid.SetColumn(chart, 1);
        }
    }
}
