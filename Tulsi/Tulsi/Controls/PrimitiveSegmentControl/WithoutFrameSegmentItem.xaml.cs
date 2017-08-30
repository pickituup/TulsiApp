using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tulsi.Controls.PrimitiveSegmentControl {
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WithoutFrameSegmentItem : PrimitiveSegmentItemBase {

        /// <summary>
        ///     ctor().
        /// </summary>
        public WithoutFrameSegmentItem() {
            InitializeComponent();

            BaseViewForTap = baseView_Frame;
        }
        
        public override string Label {
            get => outputText_Label.Text;
            set => outputText_Label.Text = value;
        }
        
        public override void Deselect() {
            baseView_Frame.BackgroundColor = Color.Transparent;
            outputText_Label.TextColor = Color.FromHex("#AAAAAA");
        }
        
        public override void Select() {
            baseView_Frame.BackgroundColor = Color.Transparent;
            outputText_Label.TextColor = Color.FromHex("#2793F5");
        }
    }
}