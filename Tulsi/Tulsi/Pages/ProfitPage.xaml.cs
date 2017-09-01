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
using Tulsi.Helpers;

namespace Tulsi {
    public partial class ProfitPage : MenuContainerPage, IView {

        private readonly ProfitViewModel _viewModel;

        public ProfitPage() {
            InitializeComponent();

            SlideMenu = new SideMenuView();

            BindingContext = _viewModel = new ProfitViewModel(); ;

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
