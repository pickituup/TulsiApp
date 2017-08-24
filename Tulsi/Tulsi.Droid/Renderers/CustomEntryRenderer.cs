using Tulsi.Droid.Renderers;
using Xamarin.Forms;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace Tulsi.Droid.Renderers {
    public class CustomEntryRenderer : EntryRendererBase {
    }
}