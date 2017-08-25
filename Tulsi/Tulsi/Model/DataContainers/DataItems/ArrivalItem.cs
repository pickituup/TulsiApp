using Xamarin.Forms;

namespace Tulsi.Model.DataContainers.DataItems {
    public class ArrivalItem {

        public string Title { get; set; }
        /// <summary>
        ///     item value.
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        ///     item number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        ///     item icon.
        /// </summary>
        public ImageSource Icon { get; set; }
    }
}
