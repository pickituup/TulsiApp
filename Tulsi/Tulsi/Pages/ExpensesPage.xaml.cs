using SlideOverKit;
using Syncfusion.SfChart.XForms;
using System;
using System.Collections.Generic;
using Tulsi.NavigationFramework;
using Tulsi.ViewModels;
using Xamarin.Forms;

namespace Tulsi {
    public partial class ExpensesPage : ContentPage, IView {

        private ExpensesPageViewModel _viewModel;

        /// <summary>
        /// Public ctor.
        /// </summary>
        public ExpensesPage() {
            InitializeComponent();

            BindingContext = _viewModel = new ExpensesPageViewModel();

            InitilizeChart();
        }

        private void InitilizeChart() {
            SfChart chart = new SfChart();

            ChartDataMarker chartDataMarker = new ChartDataMarker {
                LabelContent = LabelContent.Percentage,
                LabelStyle = new DataMarkerLabelStyle {
                    BackgroundColor = Color.Transparent,
                    Margin = new Thickness(5),
                    TextColor = Color.FromHex("#B3B3B3"),
                    LabelPosition = DataMarkerLabelPosition.Outer
                }
            };

            DoughnutSeries doughnutSeries = new DoughnutSeries() {
                ItemsSource = _viewModel.ChartData,
                XBindingPath = "Name",
                YBindingPath = "Value",
                DoughnutCoefficient = 0.7,
                DataMarker = chartDataMarker,
                DataMarkerPosition = CircularSeriesDataMarkerPosition.Outside
            };

            List<Color> colors = GetColorPalette();

            doughnutSeries.ColorModel.Palette = ChartColorPalette.Custom;
            doughnutSeries.ColorModel.CustomBrushes = colors;
            chart.Series.Add(doughnutSeries);

            chart.HorizontalOptions = LayoutOptions.Center;
            chart.VerticalOptions = LayoutOptions.Center;

            ChartGrid.Children.Add(chart);

            StackLayout MiddleStack = new StackLayout() {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.White,
            };

            Label MiddleText0 = new Label() {
                Text = "100%",
                FontSize = 14,
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                BackgroundColor = Color.White
            };

            Label MiddleText1 = new Label() {
                Text = "2,468.40",
                FontSize = 25,
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold

            };

            Label MiddleText2 = new Label() {
                Text = "USD",
                FontSize = 14,
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold
            };

            MiddleStack.Children.Add(MiddleText0);
            MiddleStack.Children.Add(MiddleText1);
            MiddleStack.Children.Add(MiddleText2);
            // MiddleStack.BackgroundColor = Color.Transparent;

            ChartGrid.Children.Add(MiddleStack);
        }

        private static List<Color> GetColorPalette() {
            return new List<Color>()
            {
                Color.FromHex("#F5DB67"),
                Color.FromHex("#9EE5FD"),
                Color.FromHex("#74C9FA"),
                Color.FromHex("#D76DC8"),
                Color.FromHex("#F8A5C3"),
                Color.FromHex("#82DA69"),
                Color.FromHex("#54CD33"),
                Color.FromHex("#E57233"),
            };
        }

        public void ApplyVisualChangesWhileNavigating() {
        }

        public void Dispose() {
        }

        public void ReSubscribe() {
            
        }
    }
}
