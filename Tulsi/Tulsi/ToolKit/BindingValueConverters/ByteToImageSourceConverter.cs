using System;
using System.Globalization;
using Xamarin.Forms;

namespace Tulsi.ToolKit.BindingValueConverters {
    public class ByteToImageSourceConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            switch (value) {
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

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }
    }
}
