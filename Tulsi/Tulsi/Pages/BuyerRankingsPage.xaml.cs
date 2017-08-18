using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using Tulsi.NavigationFramework;
using Tulsi.Helpers;
using Xamarin.Forms;
using Tulsi.ViewModels;
using SlideOverKit;

namespace Tulsi
{
    public partial class BuyerRankingsPage : MenuContainerPage, IView
    {
        private BuyerRankingsViewModel _viewModel;

        public BuyerRankingsPage()
        {
            InitializeComponent();

            _viewModel = ((App)Application.Current).BuyerRankingsVM;
            BindingContext = _viewModel;

            SlideMenu = new SideMenuView();
        }

        /// <summary>
        /// Open side menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowMenuTapped(object sender, EventArgs e) {
            ShowMenu();
        }
        
        /// <summary>
        /// Temporary
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnItemSelected(object sender, SelectedItemChangedEventArgs e) {
            BaseSingleton<ViewSwitchingLogic>.Instance.NavigateTo(ViewType.BuyerProfilePage);

            ((ListView)sender).SelectedItem = null;
        }
    }

    //public class RankingsLabel : IValueConverter {
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
    //        return "#" + value.ToString();
    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
    //        throw new NotImplementedException();
    //    }
    //}

    //public class RankingsIcon : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        if ((bool)value == true)
    //        {
    //            return ImageSource.FromResource("Tulsi.Images.ranking_up.png");
    //        }
    //        else
    //        {
    //            return ImageSource.FromResource("Tulsi.Images.ranking_down.png");
    //        }

    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    //public class RankingsColor : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        if ((bool)value == true)
    //        {
    //            return Color.FromHex("#82DA69");
    //        }
    //        else
    //        {
    //            return Color.FromHex("#E57233");
    //        }

    //    }

    //    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
}
