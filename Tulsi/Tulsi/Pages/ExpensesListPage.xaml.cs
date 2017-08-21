using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.NavigationFramework;
using Tulsi.Helpers;
using Xamarin.Forms;
using SlideOverKit;
using Tulsi.SharedService;
using Tulsi.ViewModels;

namespace Tulsi {
    public partial class ExpensesListPage : MenuContainerPage, IView {
        private ExpensesListViewModel _viewModel;

        /// <summary>
        /// Public ctor.
        /// </summary>
        public ExpensesListPage() {
            InitializeComponent();

            //Slide menu creating
            SlideMenu = new SideMenuView();

            BindingContext = _viewModel = new ExpensesListViewModel();

            More.Source = ImageSource.FromResource("Tulsi.Images.3whitecircles.png");
            ExpensesIcon.Source = ImageSource.FromResource("Tulsi.Images.expenses_group.png");

            FoodIcon.Source = ImageSource.FromResource("Tulsi.Images.expenses_food.png");
            PersonalIcon.Source = ImageSource.FromResource("Tulsi.Images.expenses_personal.png");
            GroceriesIcon.Source = ImageSource.FromResource("Tulsi.Images.expenses_groceries.png");
            BonuslIcon.Source = ImageSource.FromResource("Tulsi.Images.expenses_bonus.png");
            UtilitiesIcon.Source = ImageSource.FromResource("Tulsi.Images.expenses_utilities.png");
            CarIcon.Source = ImageSource.FromResource("Tulsi.Images.expenses_car.png");
        }

        /// <summary>
        /// IView implementation
        /// </summary>
        public void ApplyVisualChangesWhileNavigating() {
            SlideMenu.HideWithoutAnimations();
        }

        /// <summary>
        /// Displays side menu
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ShowMenuCommand(object sender, EventArgs e) {
            ShowMenu();
        }
    }
}
