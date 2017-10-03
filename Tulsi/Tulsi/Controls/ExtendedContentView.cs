using Xamarin.Forms;

namespace Tulsi.Controls {
    public sealed class ExtendedContentView : ContentView {

        //  Border thickness.
        public static readonly BindableProperty BorderThicknessProperty = BindableProperty.Create(propertyName: "BorderThickness",
                                                                                                  returnType: typeof(int),
                                                                                                  declaringType: typeof(ExtendedContentView),
                                                                                                  defaultValue: default(int));
        public int BorderThickness {
            get { return (int)GetValue(BorderThicknessProperty); }
            set { SetValue(BorderThicknessProperty, value); }
        }

        //  Border color.
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(propertyName: "BorderColor",
                                                                                              returnType: typeof(Color),
                                                                                              declaringType: typeof(ExtendedContentView),
                                                                                              defaultValue: default(Color));
        public Color BorderColor {
            get { return (Color)GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        //  Corner radius.
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(propertyName: "CornerRadius",
                                                                                               returnType: typeof(int),
                                                                                               declaringType: typeof(ExtendedContentView),
                                                                                               defaultValue: default(int));
        public int CornerRadius {
            get { return (int)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
    }
}
