using Android.Content;
using Android.Views;
using Tulsi.Controls;
using Tulsi.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(WhiteViewCell), typeof(ViewCellItemSelectedCustomRenderer))]
namespace Tulsi.Droid.Renderers {
    public class ViewCellItemSelectedCustomRenderer : ViewCellRenderer {

        protected override Android.Views.View GetCellCore(Cell item, Android.Views.View convertView, ViewGroup parent, Context context) {

            var cell = base.GetCellCore(item, convertView, parent, context);

            cell.SetBackgroundResource(Resource.Drawable.ViewCellBackground);

            return cell;
        }
    }
}