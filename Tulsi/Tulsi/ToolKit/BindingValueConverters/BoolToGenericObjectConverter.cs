using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tulsi.ToolKit.BindingValueConverters {
    public sealed class BoolToGenericObjectConverter<T> : IValueConverter {
        /// <summary>
        /// 
        /// </summary>
        public T TrueObject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public T FalseObject { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return ((bool)value) ? TrueObject : FalseObject;
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
            return ((T)value).Equals(TrueObject);
        }
    }
}