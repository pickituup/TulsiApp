using Tulsi.NavigationFramework;
using Xamarin.Forms;

namespace Tulsi.Model.DataContainers.DataItems {
    public sealed class SideMenuItem {
        /// <summary>
        ///     Menu item title.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        ///     Menu item view type.
        /// </summary>
        public ViewType ViewType { get; set; }

        /// <summary>
        ///     Menu item icon.
        /// </summary>
        public ImageSource Image { get; set; }
    }
}
