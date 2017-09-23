using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tulsi.ToolKit.BindingValueConverters {
    public class IsNullToBoolConverter : IValueConverter {

        private static readonly string _ERROR_TO_SOURCE_CONVERTING = "IsNullToBoolConverter works only with OneWay binding";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return !(value == null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new InvalidOperationException(string.Format("IsNullToBoolConverter.ConvertBack - {0}",
                _ERROR_TO_SOURCE_CONVERTING));
        }
    }
}
