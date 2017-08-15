using System;
using System.ComponentModel;
using Android.Views;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Util;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Tulsi.Controls;
using Tulsi.Droid.Renderers;

[assembly: ExportRenderer(typeof(RoundedContentView), typeof(RoundedContentViewRenderer))]
namespace Tulsi.Droid.Renderers
{
    class RoundedContentViewRenderer : VisualElementRenderer<ContentView>
    {
        private float _cornerRadius;
        private RectF _bounds;
        private Path _path;

        protected override void OnElementChanged(ElementChangedEventArgs<ContentView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                return;
            }

            var element = (RoundedContentView)Element;

            _cornerRadius = TypedValue.ApplyDimension(ComplexUnitType.Dip, element.CornerRadius,
                Context.Resources.DisplayMetrics);
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh)
        {
            base.OnSizeChanged(w, h, oldw, oldh);
            if (w != oldw && h != oldh)
            {
                _bounds = new RectF(0, 0, w, h);
            }

            _path = new Path();
            _path.Reset();
            _path.AddRoundRect(_bounds, _cornerRadius, _cornerRadius, Path.Direction.Cw);
            _path.Close();
        }

        public override void Draw(Canvas canvas)
        {
            canvas.Save();
            canvas.ClipPath(_path);
            base.Draw(canvas);
            canvas.Restore();
        }
    }
}
