using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using SlideOverKit;

namespace Tulsi
{
    public partial class ExpensesListPage : MenuContainerPage
    {
        public ExpensesListPage()
        {
            InitializeComponent();

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

            More.Source = ImageSource.FromResource("Tulsi.Images.3whitecircles.png");
            ExpensesIcon.Source = ImageSource.FromResource("Tulsi.Images.expenses_group.png");

            FoodIcon.Source = ImageSource.FromResource("Tulsi.Images.expenses_food.png");
            PersonalIcon.Source = ImageSource.FromResource("Tulsi.Images.expenses_personal.png");
            GroceriesIcon.Source = ImageSource.FromResource("Tulsi.Images.expenses_groceries.png");
            BonuslIcon.Source = ImageSource.FromResource("Tulsi.Images.expenses_bonus.png");
            UtilitiesIcon.Source = ImageSource.FromResource("Tulsi.Images.expenses_utilities.png");
            CarIcon.Source = ImageSource.FromResource("Tulsi.Images.expenses_car.png");
            /*IconPlace1.Source = ImageSource.FromResource("Tulsi.Images.expenses_place_micro.png");
            IconPlace2.Source = ImageSource.FromResource("Tulsi.Images.expenses_place_micro.png");
            IconCamera1.Source = ImageSource.FromResource("Tulsi.Images.expenses_camera_micro.png");
            IconRotate1.Source = ImageSource.FromResource("Tulsi.Images.expenses_rotate_micro.png");
            IconBell1.Source = ImageSource.FromResource("Tulsi.Images.expenses_bell_micro.png");*/

        }
    }
}
