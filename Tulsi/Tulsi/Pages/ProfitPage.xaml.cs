using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.NavigationFramework;
using Xamarin.Forms;
using Syncfusion.SfChart.XForms;
using Tulsi.ViewModels;
using SlideOverKit;
using Tulsi.SharedService;
using Tulsi.Model;

namespace Tulsi {
    public partial class ProfitPage : MenuContainerPage, IView {

        private readonly ProfitViewModel _viewModel;

        public ProfitPage() {
            InitializeComponent();

            SlideMenu = new SideMenuView();

            BindingContext = _viewModel = new ProfitViewModel(); ;

            //-------------------------------------
            TapGestureRecognizer TabTap1 = new TapGestureRecognizer();
            TabTap1.Tapped += (s, e) => {
                QuarterlyArea.BackgroundColor = Color.FromHex("#2793F5");
                QuarterlyLabel.TextColor = Color.White;
                MonthlyArea.BackgroundColor = Color.Transparent;
                MonthlyLabel.TextColor = Color.FromHex("#B3B3B3");
                WeeklyArea.BackgroundColor = Color.Transparent;
                WeeklyLabel.TextColor = Color.FromHex("#B3B3B3");

                _viewModel.ReportsPeriod = Period.Quarterly;
            };
            QuarterlyArea.GestureRecognizers.Add(TabTap1);

            TapGestureRecognizer TabTap2 = new TapGestureRecognizer();
            TabTap2.Tapped += (s, e) => {
                QuarterlyArea.BackgroundColor = Color.Transparent;
                QuarterlyLabel.TextColor = Color.FromHex("#B3B3B3");
                MonthlyArea.BackgroundColor = Color.FromHex("#2793F5");
                MonthlyLabel.TextColor = Color.White;
                WeeklyArea.BackgroundColor = Color.Transparent;
                WeeklyLabel.TextColor = Color.FromHex("#B3B3B3");

                _viewModel.ReportsPeriod = Period.Monthly;
            };
            MonthlyArea.GestureRecognizers.Add(TabTap2);

            TapGestureRecognizer TabTap3 = new TapGestureRecognizer();
            TabTap3.Tapped += (s, e) => {
                QuarterlyArea.BackgroundColor = Color.Transparent;
                QuarterlyLabel.TextColor = Color.FromHex("#B3B3B3");
                MonthlyArea.BackgroundColor = Color.Transparent;
                MonthlyLabel.TextColor = Color.FromHex("#B3B3B3");
                WeeklyArea.BackgroundColor = Color.FromHex("#2793F5");
                WeeklyLabel.TextColor = Color.White;

                _viewModel.ReportsPeriod = Period.Quarterly;
            };
            WeeklyLabel.GestureRecognizers.Add(TabTap3);

            //-----------------------------------
            TapGestureRecognizer TabTap4 = new TapGestureRecognizer();
            TabTap4.Tapped += (s, e) => {
                Year1.TextColor = Color.FromHex("#2793F5");
                Year2.TextColor = Color.FromHex("#B3B3B3");

                _viewModel.Year = 2013;
            };
            Year1.GestureRecognizers.Add(TabTap4);

            TapGestureRecognizer TabTap5 = new TapGestureRecognizer();
            TabTap5.Tapped += (s, e) => {
                Year1.TextColor = Color.FromHex("#B3B3B3");
                Year2.TextColor = Color.FromHex("#2793F5");

                _viewModel.Year = 2014;
            };
            Year2.GestureRecognizers.Add(TabTap5);

            //-----------------------------------
            TapGestureRecognizer TabTap6 = new TapGestureRecognizer();
            TabTap6.Tapped += (s, e) => {
                PaidStatsLabel.TextColor = Color.FromHex("#2793F5");
                AllStatsLabel.TextColor = Color.FromHex("#B3B3B3");
            };
            PaidStatsLabel.GestureRecognizers.Add(TabTap6);

            TapGestureRecognizer TabTap7 = new TapGestureRecognizer();
            TabTap7.Tapped += (s, e) => {
                PaidStatsLabel.TextColor = Color.FromHex("#B3B3B3");
                AllStatsLabel.TextColor = Color.FromHex("#2793F5");

            };
            AllStatsLabel.GestureRecognizers.Add(TabTap7);
            //-----------------------------------

            SfChart chart = new SfChart();
            chart.BackgroundColor = Color.FromHex("#FFFFFF");
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
            series.StrokeColor = Color.FromHex("#2793F5");

            chart.Series.Add(series);
            ChartGrid.Children.Add(chart);
            Grid.SetColumn(chart, 1);
        }

        /// <summary>
        ///     Show side menu.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowMenuCommand(object sender, EventArgs e) {
            ShowMenu();
        }

        /// <summary>
        ///     Autohide side menu.
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() {
            SlideMenu.HideWithoutAnimations();
        }

        public void Dispose() {
            
        }

        public void ReSubscribe() {
            
        }
    }
}
