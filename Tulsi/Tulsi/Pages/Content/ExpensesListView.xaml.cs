using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.NavigationFramework;
using Tulsi.ViewModels.Content;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tulsi.Pages.Content {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensesListView : ContentView, IView {

        private readonly ExpensesListViewModel _viewModel;

        /// <summary>
        ///     ctor.
        /// </summary>
        public ExpensesListView() {
            InitializeComponent();

            BindingContext = _viewModel = new ExpensesListViewModel();

            FoodIcon.Source = ImageSource.FromResource("Tulsi.Images.expenses_food.png");
            PersonalIcon.Source = ImageSource.FromResource("Tulsi.Images.expenses_personal.png");
            GroceriesIcon.Source = ImageSource.FromResource("Tulsi.Images.expenses_groceries.png");
            BonuslIcon.Source = ImageSource.FromResource("Tulsi.Images.expenses_bonus.png");
            UtilitiesIcon.Source = ImageSource.FromResource("Tulsi.Images.expenses_utilities.png");
            CarIcon.Source = ImageSource.FromResource("Tulsi.Images.expenses_car.png");
        }

        public void ApplyVisualChangesWhileNavigating() {
            
        }

        public void Dispose() {
            _viewModel.Dispose();
        }
    }
}