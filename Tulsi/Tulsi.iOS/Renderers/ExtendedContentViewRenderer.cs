using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Tulsi.Controls;
using Xamarin.Forms;
using Tulsi.iOS.Renderers;

[assembly: ExportRenderer(typeof(ExtendedContentView), typeof(ExtendedContentViewRenderer))]
namespace Tulsi.iOS.Renderers {
    public sealed class ExtendedContentViewRenderer : VisualElementRenderer<ExtendedContentView> {
        private ExtendedContentView _element;

        protected override void OnElementChanged(ElementChangedEventArgs<ExtendedContentView> e) {
            base.OnElementChanged(e);

            if (e.NewElement != null) {

                _element = e.NewElement as ExtendedContentView;
                SetupLayer(_element.BorderThickness, _element.CornerRadius);
            }
        }

        private void SetupLayer(int borderWidth, nfloat borderRadius) {

            Layer.CornerRadius = borderRadius;

            if (Element.BackgroundColor != Color.Default) {
                Layer.BackgroundColor = Element.BackgroundColor.ToCGColor();
            } else {
                Layer.BackgroundColor = UIColor.White.CGColor;
            }

            if (Element.BorderColor != Color.Default) {
                Layer.BorderColor = Element.BorderColor.ToCGColor();
                Layer.BorderWidth = borderWidth;
            }

            Layer.RasterizationScale = UIScreen.MainScreen.Scale;
            Layer.ShouldRasterize = true;
        }
    }
}