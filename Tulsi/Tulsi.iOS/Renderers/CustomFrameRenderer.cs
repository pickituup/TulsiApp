using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms.Platform.iOS;
using Tulsi.Controls;
using Xamarin.Forms;
using System.ComponentModel;

[assembly: ExportRenderer(typeof(CustomFrame), typeof(Tulsi.iOS.Renderers.CustomFrameRenderer))]
namespace Tulsi.iOS.Renderers
{
    public class CustomFrameRenderer : VisualElementRenderer<CustomFrame>
    {
        private CustomFrame _control;
        public CustomFrameRenderer()
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<CustomFrame> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                _control = e.NewElement as CustomFrame;
                this.SetupLayer(_control.BorderWidth, _control?.BorderRadius ?? 5);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == CustomFrame.OutlineColorProperty.PropertyName || e.PropertyName == CustomFrame.BorderWidthProperty.PropertyName)
            {
                this.SetupLayer(_control?.BorderWidth ?? 5, _control?.BorderRadius ?? 5);
            }
        }

        private void SetupLayer(int borderWidth, nfloat borderRadius)
        {

            Layer.CornerRadius = borderRadius;
            if (Element.BackgroundColor != Color.Default)
            {
                Layer.BackgroundColor = Element.BackgroundColor.ToCGColor();
            }
            else
            {
                Layer.BackgroundColor = UIColor.White.CGColor;
            }
            //if (!base.Element.HasShadow)
            //{
            //	this.get_Layer().set_ShadowOpacity(0f);
            //}
            //else
            //{
            //	this.get_Layer().set_ShadowRadius(5);
            //	this.get_Layer().set_ShadowColor(UIColor.get_Black().get_CGColor());
            //	this.get_Layer().set_ShadowOpacity(0.8f);
            //	this.get_Layer().set_ShadowOffset(new SizeF());
            //}
            if (Element.OutlineColor != Color.Default)
            {
                this.Layer.BackgroundColor = base.Element.OutlineColor.ToCGColor();
                this.Layer.BorderWidth = borderWidth;
            }
            else
            {
                this.Layer.BackgroundColor = UIColor.Clear.CGColor;
            }
            this.Layer.RasterizationScale = UIScreen.MainScreen.Scale;
            this.Layer.ShouldRasterize = true;
        }
    }
}