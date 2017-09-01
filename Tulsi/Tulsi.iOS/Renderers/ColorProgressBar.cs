using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Xamarin.Forms;
using Tulsi.Controls;
using Tulsi.iOS.Renderers;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(ColorProgressBar), typeof(ColorProgressBarRenderer))]
namespace Tulsi.iOS.Renderers {
    public class ColorProgressBarRenderer : ProgressBarRenderer {

        /// <summary>
        ///     ctor().
        /// </summary>
        public ColorProgressBarRenderer() {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ProgressBar> e) {
            base.OnElementChanged(e);

            if (e.NewElement == null)
                return;

            if (Control != null) {
                UpdateBarColor();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == ColorProgressBar.BarColorProperty.PropertyName) {
                UpdateBarColor();
            }
        }

        private void UpdateBarColor() {
            var element = Element as ColorProgressBar;
            Control.TintColor = element.BarColor.ToUIColor();
        }
    }
}