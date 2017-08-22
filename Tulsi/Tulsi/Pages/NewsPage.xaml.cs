using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using SlideOverKit;
using Tulsi.SharedService;
using Xamarin.Forms.Xaml;

namespace Tulsi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewsPage : MenuContainerPage
    {
        public NewsPage()
        {
            InitializeComponent();


            //int hd = DependencyService.Get<IDisplaySize>().GetHeightDiP();
            //AbsoluteLayout.SetLayoutBounds(SideMenuOverlay, new Rectangle(0, 0, 0.9, hd - 20));

            ////Slide menu creating
            //SlideMenu = new SideMenuView();

            ////Toolbar taps
            //TapGestureRecognizer ToolbarTap1 = new TapGestureRecognizer();
            //ToolbarTap1.Tapped += (s, e) =>
            //{
            //    this.ShowMenu();
            //};
            //Menu.GestureRecognizers.Add(ToolbarTap1);

            //TapGestureRecognizer ToolbarTap2 = new TapGestureRecognizer();
            //ToolbarTap2.Tapped += (s, e) =>
            //{
            //    SearchPage sp = new SearchPage();
            //    Application.Current.MainPage.Navigation.PushAsync(sp);
            //};
            //Search.GestureRecognizers.Add(ToolbarTap2);

        }
    }
}
