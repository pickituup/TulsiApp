using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Tulsi.Controls.PrimitiveSegmentControl {
    public partial class FramedLabelSegmentItem : PrimitiveSegmentItemBase {

        /// <summary>
        /// 
        /// </summary>
        public FramedLabelSegmentItem() {
            InitializeComponent();

            BaseViewForTap = _baseView_Frame;
        }

        /// <summary>
        /// 
        /// </summary>
        public override string Label {
            get => _outputText_Label.Text;
            set => _outputText_Label.Text = value;
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Deselect() {
            _baseView_Frame.BackgroundColor = Color.White;
            _outputText_Label.TextColor = Color.FromHex("#AAAAAA");
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Select() {
            _baseView_Frame.BackgroundColor = Color.FromHex("#2793F5");
            _outputText_Label.TextColor = Color.White;
        }
    }
}
