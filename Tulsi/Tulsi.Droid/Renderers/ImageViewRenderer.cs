using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Tulsi.Droid.Renderers;
using Xamarin.Forms.Platform.Android;
using System.ComponentModel;
using System.Net.Http;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using Felipecsl.GifImageViewLibrary;

[assembly: ExportRenderer(typeof(Image), typeof(ImageViewRenderer))]
namespace Tulsi.Droid.Renderers {
    public class ImageViewRenderer : ImageRenderer {

        private GifImageView _gif;

        protected override void OnElementChanged(ElementChangedEventArgs<Image> e) {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
                return;

            _gif = new Felipecsl.GifImageViewLibrary.GifImageView(Forms.Context);

            SetNativeControl(_gif);
        }

        protected override async void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == Image.SourceProperty.PropertyName) {
                byte[] bytes = null;

                var s = Element.Source;
                if (s is UriImageSource) {
                    using (var client = new HttpClient())
                        bytes = await client.GetByteArrayAsync(((UriImageSource)s).Uri);
                } else if (s is StreamImageSource) {
                    bytes = await GetBytesFromStreamAsync(await((StreamImageSource)s).Stream(default(CancellationToken)));
                } else if (s is FileImageSource) {
                    bytes = await GetBytesFromStreamAsync(File.OpenRead(((FileImageSource)s).File));
                }

                if (bytes == null)
                    return;

                try {
                    _gif.StopAnimation();
                    _gif.SetBytes(bytes);
                    _gif.StartAnimation();
                } catch (Exception ex) {
                    System.Diagnostics.Debug.WriteLine("Unable to load gif: " + ex.Message);
                }
            }
        }

        static async Task<byte[]> GetBytesFromStreamAsync(Stream stream) {
            using (stream) {
                if (stream == null || stream.Length == 0)
                    return null;

                var bytes = new byte[stream.Length];
                if (await stream.ReadAsync(bytes, 0, (int)stream.Length) > 0)
                    return bytes;
            }

            return null;
        }
    }
}