using System.Net;
using Tulsi.Controls;
using Tulsi.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(PdfWebView), typeof(PdfWebViewRenderer))]
namespace Tulsi.Droid.Renderers {
    public class PdfWebViewRenderer : WebViewRenderer {

        protected override void OnElementChanged(ElementChangedEventArgs<WebView> e) {
            base.OnElementChanged(e);

            if (e.NewElement != null) {
                PdfWebView customWebView = Element as PdfWebView;
                Control.Settings.AllowUniversalAccessFromFileURLs = true;
                Control.Settings.AllowFileAccessFromFileURLs = true;
                Control.Settings.JavaScriptEnabled = true;
                Control.Settings.BuiltInZoomControls = true;
                Control.Settings.DisplayZoomControls = false;

                Control.LoadUrl(string.Format("file:///android_asset/pdfviewer/index.html?file={0}", string.Format("file:///android_asset/Content/{0}", WebUtility.UrlEncode(customWebView.Uri))));
            }
        }
    }
}