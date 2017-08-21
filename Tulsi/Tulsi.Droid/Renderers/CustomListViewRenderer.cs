using Tulsi.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Xamarin.Forms.ListView), typeof(CustomListViewRenderer))]
namespace Tulsi.Droid.Renderers {
    public class CustomListViewRenderer : ListViewRenderer {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.ListView> e) {
            base.OnElementChanged(e);

            Control.VerticalScrollBarEnabled = false;
        }
    }
}