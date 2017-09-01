using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tulsi.Controls.PrimitiveSegmentControl {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SquareSegmentItem : PrimitiveSegmentItemBase {

        /// <summary>
        ///     ctor().
        /// </summary>
        public SquareSegmentItem() {
            InitializeComponent();

            BaseViewForTap = baseView_Frame;
        }

        public override string Label {
            get => outputText_Label.Text;
            set => outputText_Label.Text = value;
        }

        public override void Deselect() {
            baseView_Frame.BackgroundColor = Color.White;
            outputText_Label.TextColor = Color.FromHex("#AAAAAA");
        }

        public override void Select() {
            baseView_Frame.BackgroundColor = Color.FromHex("#2793F5");
            outputText_Label.TextColor = Color.White;
        }
    }
}