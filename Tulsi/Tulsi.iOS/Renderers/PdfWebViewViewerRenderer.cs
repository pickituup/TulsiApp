using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Tulsi.Controls;
using System.Net;
using Xamarin.Forms;
using Tulsi.iOS.Renderers;

[assembly: ExportRenderer(typeof(PdfWebView), typeof(PdfWebViewViewerRenderer))]
namespace Tulsi.iOS.Renderers {
    public sealed class PdfWebViewViewerRenderer : ViewRenderer<PdfWebView, UIWebView> {

        protected override void OnElementChanged(ElementChangedEventArgs<PdfWebView> e) {
            base.OnElementChanged(e);

            if (Control == null) {
                SetNativeControl(new UIWebView());
            }
            if (e.OldElement != null) {
                // Cleanup
            }
            if (e.NewElement != null) {
                PdfWebView customWebView = Element as PdfWebView;
                string fileName = WebUtility.UrlEncode(customWebView.Uri);
                Control.LoadRequest(new NSUrlRequest(new NSUrl(fileName)));
                Control.ScalesPageToFit = true;
            }
        }
    }
}