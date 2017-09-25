using System;
using System.Globalization;
using Xamarin.Forms;

namespace Tulsi.ToolKit.BindingValueConverters {
    public class ProgressBarColorConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if ((double)value < 0.5) 
                return Color.FromHex("#2793F5");
            if ((double)value >= 0.5 && (double)value < 0.8) 
                return Color.Yellow;
            if ((double)value >= 0.8) 
                return Color.Red;
            return Color.Accent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return value;
        }
    }
}
