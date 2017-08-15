using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion.SfChart.XForms;
using Tulsi.ViewModels;
using SlideOverKit;

namespace Tulsi
{
    public partial class ExpensesPage : MenuContainerPage
    {
        public ExpensesPage()
        {
            InitializeComponent();

            ExpensesViewModel evm = new ExpensesViewModel();
            BindingContext = evm;

            int hd = DependencyService.Get<IDisplaySize>().GetHeightDiP();
            int wd = DependencyService.Get<IDisplaySize>().GetWidthDiP();
            AbsoluteLayout.SetLayoutBounds(SideMenuOverlay, new Rectangle(0, 0, 0.9, hd - 20));

            Category1.Source = ImageSource.FromResource("Tulsi.Images.yellowcategory.png");
            Category2.Source = ImageSource.FromResource("Tulsi.Images.lightbluecategory.png");
            Category3.Source = ImageSource.FromResource("Tulsi.Images.bluecategory.png");
            Category4.Source = ImageSource.FromResource("Tulsi.Images.magentacategory.png");
            Category5.Source = ImageSource.FromResource("Tulsi.Images.pinkcategory.png");

            Category6.Source = ImageSource.FromResource("Tulsi.Images.lightgreencategory.png");
            Category7.Source = ImageSource.FromResource("Tulsi.Images.greencategory.png");
            Category8.Source = ImageSource.FromResource("Tulsi.Images.browncategory.png");
            Category9.Source = ImageSource.FromResource("Tulsi.Images.graycategory.png");
            Category10.Source = ImageSource.FromResource("Tulsi.Images.graycategory.png");

            Category11.Source = ImageSource.FromResource("Tulsi.Images.graycategory.png");
            Category12.Source = ImageSource.FromResource("Tulsi.Images.graycategory.png");
            Category13.Source = ImageSource.FromResource("Tulsi.Images.graycategory.png");
            Category14.Source = ImageSource.FromResource("Tulsi.Images.graycategory.png");
            Category15.Source = ImageSource.FromResource("Tulsi.Images.graycategory.png");

            BlueCircleTab.Source = ImageSource.FromResource("Tulsi.Images.tabbluecircle.png");
            EmptyCircleTab.Source = ImageSource.FromResource("Tulsi.Images.emptycircle.png");

            More.Source = ImageSource.FromResource("Tulsi.Images.3whitecircles.png");

            SfChart chart = new SfChart();
            DoughnutSeries doughnutSeries = new DoughnutSeries()
            {
                ItemsSource = evm.ChartData,
                XBindingPath = "Name",
                YBindingPath = "Value",
                DoughnutCoefficient = 0.7,
            };
            doughnutSeries.DataMarker = new ChartDataMarker();
            List<Color> colors = new List<Color>()
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

            doughnutSeries.ColorModel.Palette = ChartColorPalette.Custom;
            doughnutSeries.ColorModel.CustomBrushes = colors;
            chart.Series.Add(doughnutSeries);

            chart.HorizontalOptions = LayoutOptions.Center;
            chart.VerticalOptions = LayoutOptions.Center;
            //chart.BackgroundColor = Color.FromHex("#F3F3F3");
            chart.WidthRequest = wd;
            ChartGrid.Children.Add(chart);

            StackLayout MiddleStack = new StackLayout()
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor=Color.White,
                
            };
            Label MiddleText0 = new Label()
            {
                Text = "100%",
                FontSize = 14,
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold,
                BackgroundColor=Color.White

            };
            Label MiddleText1 = new Label()
            {
                Text = "2,468.40",
                FontSize = 25,
                HorizontalOptions = LayoutOptions.Center,
                FontAttributes = FontAttributes.Bold

            };
            Label MiddleText2 = new Label()
            {
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

            //Toolbar taps
            TapGestureRecognizer tapGestureRecognizer1 = new TapGestureRecognizer();
            tapGestureRecognizer1.Tapped += (s, e) =>
            {
                SideMenuOverlay.IsVisible = true;
                OutsideOverlay.IsVisible = true;
            };
            Menu.GestureRecognizers.Add(tapGestureRecognizer1);

            TapGestureRecognizer tapGestureRecognizer2 = new TapGestureRecognizer();
            tapGestureRecognizer2.Tapped += (s, e) =>
            {
                SideMenuOverlay.IsVisible = false;
                OutsideOverlay.IsVisible = false;
            };
            OutsideOverlay.GestureRecognizers.Add(tapGestureRecognizer2);

            TapGestureRecognizer tapGestureRecognizer3 = new TapGestureRecognizer();
            tapGestureRecognizer3.Tapped += (s, e) =>
            {
                SideMenuOverlay.IsVisible = false;
                OutsideOverlay.IsVisible = false;
            };
            SideMenuHeaderCloseIcon.GestureRecognizers.Add(tapGestureRecognizer3);

            //In page navigation
            TapGestureRecognizer InPageNavigationTap1 = new TapGestureRecognizer();
            InPageNavigationTap1.Tapped += (s, e) =>
            {
                ExpensesListPage elp = new ExpensesListPage();
                Application.Current.MainPage.Navigation.PushAsync(elp);
            };
            ExpensesExtraIcon.GestureRecognizers.Add(InPageNavigationTap1);

        }
    }
}
