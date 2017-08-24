using Android.Graphics.Drawables;
using Android.Views;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using NativeGraphics = Android.Graphics;

namespace Tulsi.Droid.Renderers {
    public abstract class EntryRendererBase : EntryRenderer {

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e) {
            base.OnElementChanged(e);

            if (Control != null && Element != null) {
                AllignTheText();
                RemoveUnderscore();
            }
        }

        /// <summary>
        /// Parse Xamarin Color to native Android Color.
        /// 
        /// TODO: DRY, set this method in service, static type.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private static NativeGraphics.Color CreateNativeColor(Color color) {
            byte red = (byte)(color.R * 255);
            byte green = (byte)(color.G * 255);
            byte blue = (byte)(color.B * 255);
            byte alpha = (byte)(color.A * 255);

            return new NativeGraphics.Color(red, green, blue, alpha);
        }

        /// <summary>
        /// Will hide the undefined underline through all native-element. Under the hood change the background of native
        /// control to the appropriate Forms Element bakground color.
        /// </summary>
        private void RemoveUnderscore() {
            if (Control != null && Element != null) {
                Color backgroundColor = Element.BackgroundColor;

                Control.Background = new ColorDrawable(CreateNativeColor(backgroundColor));
            }
        }

        /// <summary>
        /// Allign EditText's text in 'CenterVertical' direction with apropriate horizontal alignments.
        /// </summary>
        private void AllignTheText() {
            if (Element.HorizontalTextAlignment == Xamarin.Forms.TextAlignment.Center) {
                Control.Gravity = GravityFlags.Center;
            } else if (Element.HorizontalTextAlignment == Xamarin.Forms.TextAlignment.End) {
                Control.Gravity = GravityFlags.CenterVertical | GravityFlags.End;
            } else {
                Control.Gravity = GravityFlags.CenterVertical;
            }
        }
    }
}