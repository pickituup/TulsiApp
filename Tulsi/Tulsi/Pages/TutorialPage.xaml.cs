using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tulsi.Helpers;
using Tulsi.Model.DataContainers.DataItems;
using Tulsi.NavigationFramework;
using Tulsi.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tulsi.Pages {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TutorialPage : ContentPage, IView {

        private readonly TutorialPageViewModel _viewModel;

        /// <summary>
        ///     ctor().
        /// </summary>
        public TutorialPage() {
            InitializeComponent();

            BindingContext = _viewModel = new TutorialPageViewModel();
        }

        /// <summary>
        /// 
        /// </summary>
        protected override void OnAppearing() {
            base.OnAppearing();

            SetPlatformStatusBarColor("#ffffff");
        }

        protected override void OnDisappearing() {
            base.OnDisappearing();

            SetPlatformStatusBarColor(null);
        }

        private void SetPlatformStatusBarColor(string color) {
            switch (Device.RuntimePlatform) {
                case Device.Android:
                    _viewModel.ChangeStatusBarColor(color);
                    break;
                case Device.iOS:
                    break;
                default:
                    _viewModel.ChangeStatusBarColor(null);
                    break;
            }
        }

        public void ApplyVisualChangesWhileNavigating() { }

        private void OnSelectedItem(object sender, SelectedItemChangedEventArgs e) {
            if (e.SelectedItem is TutorialItem) {
                TutorialItem selectedItem = e.SelectedItem as TutorialItem;
                image.Source = GetImageSource(selectedItem.Id);
            }
        }

        private ImageSource GetImageSource(int id) {
            switch (id) {
                case 1:
                    return ImageSource.FromResource("Tulsi.Images.selection1.png");
                case 2:
                    return ImageSource.FromResource("Tulsi.Images.selection2.png");
                case 3:
                    return ImageSource.FromResource("Tulsi.Images.selection3.png");
                case 4:
                    return ImageSource.FromResource("Tulsi.Images.selection4.png");
                case 5:
                    return ImageSource.FromResource("Tulsi.Images.selection5.png");
                default:
                    return null;
            }
        }

        public void Dispose() {
            _viewModel.Dispose();
        }
    }
}