using System;
using System.Globalization;
using Xamarin.Forms;

namespace Tulsi.ToolKit.BindingValueConverters {
    public sealed class StringToResourceImageSourceConverter : IValueConverter {

        private static readonly string ERROR_STRING_TO_IMAGE_SOURCE_CONVERT = "Invalid source string.";

        /// <summary>
        ///     Use 'value' as path to the EmbededResource image source.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            try {
                return ImageSource.FromResource(value.ToString());
            }
            catch (Exception exc) {
                throw new InvalidOperationException(string.Format("StringToImageSourceConverter.Convert - {0}. Exception details - {1}",
                    ERROR_STRING_TO_IMAGE_SOURCE_CONVERT,
                    exc.Message));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return null;
        }
    }
}
