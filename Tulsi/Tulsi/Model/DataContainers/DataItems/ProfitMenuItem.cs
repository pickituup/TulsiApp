using Xamarin.Forms;

namespace Tulsi.Model.DataContainers.DataItems {
    public class ProfitMenuItem {
        /// <summary>
        ///     Menu item value.
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        ///     Menu item status.
        /// </summary>
        public string Status { get; set; }

        /// <summary>
        ///     Menu item icon.
        /// </summary>
        public ImageSource Image { get; set; }
    }
}
