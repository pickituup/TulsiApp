using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Tulsi.Controls.PrimitiveSegmentControl {
    public abstract class PrimitiveSegmentItemBase : ContentView {

        public static readonly BindableProperty ItemCommandProperty =
           BindableProperty.Create("ItemCommand",
               typeof(ICommand),
               typeof(PrimitiveSegmentItemBase));

        /// <summary>
        /// 
        /// </summary>
        public ICommand ItemCommand {
            get {
                return (ICommand)GetValue(ItemCommandProperty);
            }
            set {
                SetValue(ItemCommandProperty, value);
            }
        }

        /// <summary>
        /// On that view will be setted tap gesture recognizer.
        /// </summary>
        public View BaseViewForTap { get; protected set; }

        /// <summary>
        /// 
        /// </summary>
        public abstract string Label { get; set; }

        /// <summary>
        /// Abstract selection
        /// </summary>
        public abstract void Select();

        /// <summary>
        /// Abstract deselection
        /// </summary>
        public abstract void Deselect();
    }
}