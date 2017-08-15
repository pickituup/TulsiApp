using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

using Xamarin.Forms;
using Tulsi.ViewModels;
using SlideOverKit;

namespace Tulsi
{
    public partial class BuyerRankingsPage : MenuContainerPage
    {
        public BuyerRankingsPage()
        {
            InitializeComponent();

            BuyerRankingsViewModel brvm = ((App)Application.Current).BuyerRankingsVM;
            BuyerRankingsListView.ItemsSource = brvm.BuyerRankings;
            BuyerRankingsListView.ItemSelected += (sender, e) =>
            {
                ((ListView)sender).SelectedItem = null;
            };

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

            //In page navigation
            TapGestureRecognizer InPageNavigationTap1 = new TapGestureRecognizer();
            InPageNavigationTap1.Tapped += (s, e) =>
            {
                BuyerProfilePage bpp = new BuyerProfilePage();
                Application.Current.MainPage.Navigation.PushAsync(bpp);
            };
            BuyerRankingsListView.GestureRecognizers.Add(InPageNavigationTap1);
        }
    }

    public class RankingsLabel: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return "#" + value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class RankingsIcon : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
            {
                return ImageSource.FromResource("Tulsi.Images.ranking_up.png");
            }
            else
            {
                return ImageSource.FromResource("Tulsi.Images.ranking_down.png");
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    public class RankingsColor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if ((bool)value == true)
            {
                return Color.FromHex("#82DA69");
            }
            else
            {
                return Color.FromHex("#E57233");
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
