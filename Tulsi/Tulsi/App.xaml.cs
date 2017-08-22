using System;
using System.Globalization;
using Tulsi.Helpers;
using Tulsi.NavigationFramework;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Tulsi {
    public partial class App : Application {

        public App() {
            InitializeComponent();

            BaseSingleton<ViewSwitchingLogic>.Instance.BuildNavigationStack(ViewType.LoginPage);
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
   
    [ContentProperty("Source")]
    public class ImageResourceExtension : IMarkupExtension {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider) {
            if (Source == null)
                return null;

            // Do your translation lookup here, using whatever method you require
            ImageSource imageSource = ImageSource.FromResource(Source);

            return imageSource;
        }
    }

    public class ProfileTransactionImage : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if ((bool)value == true) {
                return ImageSource.FromResource("Tulsi.Images.ptransaction.png");
            }
            else {
                return ImageSource.FromResource("Tulsi.Images.dtransaction.png");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }
    }
}
