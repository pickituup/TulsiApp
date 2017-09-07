using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.Model;
using Tulsi.Model.DataContainers.DataItems;
using Tulsi.NavigationFramework;
using Tulsi.ViewModels.Content;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tulsi.Pages.Content {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ExpensesCarouselView : ContentView, IView {

        private readonly ExpensesCarouselViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public ExpensesCarouselView() {
            InitializeComponent();

            BindingContext = _viewModel = new ExpensesCarouselViewModel();
        }

        private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e) {
            if (e.SelectedItem is CarouselContent) {
                var selectedContent = e.SelectedItem as CarouselContent;
                image.Source = GetImageSource(selectedContent.Id);
            }
        }

        private ImageSource GetImageSource(int id) {
            switch (id) {
                case 1:
                    return ImageSource.FromResource("Tulsi.Images.selectContent1.png");
                case 2:
                    return ImageSource.FromResource("Tulsi.Images.selectContent2.png");
                default:
                    return null;
            }
        }

        public void ApplyVisualChangesWhileNavigating() {
            
        }

        public void Dispose() {
            foreach (var item in carousel.ItemsSource) {
                ((IView)(((CarouselContent)item).CurrentContent)).Dispose();
            }

            _viewModel.Dispose();
        }
    }
}