using Xamarin.Forms;

namespace Tulsi.Controls {
    public class ColorProgressBar : ProgressBar {

        public static BindableProperty BarColorProperty = BindableProperty.Create(propertyName: "BarColor",
                                                                                  returnType: typeof(Color),
                                                                                  declaringType: typeof(ColorProgressBar),
                                                                                  defaultValue: default(Color));

        public Color BarColor {
            get { return (Color)GetValue(BarColorProperty); }
            set { SetValue(BarColorProperty, value); }
        }
    }
}
