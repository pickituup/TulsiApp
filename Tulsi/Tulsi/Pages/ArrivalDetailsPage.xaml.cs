using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using SlideOverKit;

namespace Tulsi
{
    public partial class ArrivalDetailsPage : MenuContainerPage
    {
        public ArrivalDetailsPage()
        {
            InitializeComponent();

            Background1.Source = ImageSource.FromResource("Tulsi.Images.arrivaldetails_background.png");
            Background2.Source = ImageSource.FromResource("Tulsi.Images.arrivaldetails_background.png");
            Background3.Source = ImageSource.FromResource("Tulsi.Images.arrivaldetails_background.png");

            c1.Source = ImageSource.FromResource("Tulsi.Images.bluecircle.png");
            c2.Source = ImageSource.FromResource("Tulsi.Images.bluecircle.png");
            c3.Source = ImageSource.FromResource("Tulsi.Images.bluecircle.png");
            c4.Source = ImageSource.FromResource("Tulsi.Images.bluecircle.png");
            c5.Source = ImageSource.FromResource("Tulsi.Images.bluecircle.png");

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
        }
    }
}
