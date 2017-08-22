using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tulsi.ToolKit.MarkupExtensions {
    [ContentProperty("Source")]
    public sealed class ImageResourceExtension : IMarkupExtension {
        /// <summary>
        /// 
        /// </summary>
        public string Source { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns></returns>
        public object ProvideValue(IServiceProvider serviceProvider) {
            if (Source == null) {
                return null;
            }

            ImageSource imageSource = ImageSource.FromResource(Source);

            return imageSource;
        }
    }
}
