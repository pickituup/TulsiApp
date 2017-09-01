using Android.Graphics;
using System.ComponentModel;
using Tulsi.Controls;
using Tulsi.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ColorProgressBar), typeof(ColorProgressBarRenderer))]
namespace Tulsi.Droid.Renderers {
    public class ColorProgressBarRenderer : ProgressBarRenderer {

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ProgressBar> e) {
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
            // http://stackoverflow.com/a/29199280
            Control.IndeterminateDrawable.SetColorFilter(element.BarColor.ToAndroid(), PorterDuff.Mode.SrcIn);
            Control.ProgressDrawable.SetColorFilter(element.BarColor.ToAndroid(), PorterDuff.Mode.SrcIn);
        }
    }
}