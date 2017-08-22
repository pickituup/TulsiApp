using Tulsi.Controls;
using Xamarin.Forms;

namespace Tulsi.ToolKit.Triggers {
    public class ChangeBackgroundColorTriggerAction : TriggerAction<RoundedContentView> {
        protected override void Invoke(RoundedContentView sender) {
            sender.BackgroundColor = sender.IsFocused ? Color.FromHex("#2793F5") : Color.Transparent;
        }
    }
}
