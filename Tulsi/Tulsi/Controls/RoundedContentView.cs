using Xamarin.Forms;

namespace Tulsi.Controls {
    public class RoundedContentView : ContentView {
        public static readonly BindableProperty CornerRaidusProperty = BindableProperty.Create(propertyName: "CornerRadius",
                                                                                               returnType: typeof(float),
                                                                                               declaringType: typeof(RoundedContentView),
                                                                                               defaultValue: default(float));

        public float CornerRadius {
            get { return (float)GetValue(CornerRaidusProperty); }
            set { SetValue(CornerRaidusProperty, value); }
        }
    }
}
