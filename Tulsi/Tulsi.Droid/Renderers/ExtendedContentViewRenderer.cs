using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Tulsi.Controls;
using Tulsi.Droid.Renderers;
using Android.Graphics;
using Android.Util;

[assembly: ExportRenderer(typeof(ExtendedContentView), typeof(ExtendedContentViewRenderer))]
namespace Tulsi.Droid.Renderers {
    public sealed class ExtendedContentViewRenderer : ViewRenderer {

        private int _controlWidth;

        private int _controlHeight;

        private Paint _borderPaint;

        /// <summary>
        ///     ctor().
        /// </summary>
        public ExtendedContentViewRenderer() {
            SetWillNotDraw(false);

            Init();
        }

        private void Init() {
            _borderPaint = new Paint(PaintFlags.AntiAlias);
            _borderPaint.StrokeWidth = 4;
            _borderPaint.SetStyle(Paint.Style.Stroke);
        }

        protected override void OnSizeChanged(int w, int h, int oldw, int oldh) {
            base.OnSizeChanged(w, h, oldw, oldh);

            _controlWidth = w;
            _controlHeight = h;
        }

        public override void Draw(Canvas canvas) {
            float cornerRadius = TypedValue.ApplyDimension(
                ComplexUnitType.Dip,
                ((ExtendedContentView)Element).CornerRadius, Context.Resources.DisplayMetrics);

            RectF rectF = new RectF(0, 0, _controlWidth, _controlHeight);

            ClipRoundedScope(canvas, rectF, cornerRadius);

            base.Draw(canvas);

            DrawBorder(canvas, rectF, cornerRadius);
        }

        /// <summary>
        /// Draws the border around
        /// </summary>
        /// <param name="canvas"></param>
        private void DrawBorder(Canvas canvas, RectF rectF, float cornerRadius) {
            _borderPaint.Color = CreateNativeColor(((ExtendedContentView)Element).BorderColor);
            canvas.DrawRoundRect(rectF, cornerRadius, cornerRadius, _borderPaint);
        }

        private void ClipRoundedScope(Canvas canvas, RectF rectF, float cornerRadius) {
            Path path = new Path();
            path.AddRoundRect(rectF, cornerRadius, cornerRadius, Path.Direction.Cw);
            canvas.ClipPath(path);
        }

        /// <summary>
        /// Parse Xamarin Color to native Android Color.
        /// 
        /// TODO: DRY, set this method in service, static type.
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        private static Android.Graphics.Color CreateNativeColor(Xamarin.Forms.Color color) {
            byte red = (byte)(color.R * 255);
            byte green = (byte)(color.G * 255);
            byte blue = (byte)(color.B * 255);
            byte alpha = (byte)(color.A * 255);

            return new Android.Graphics.Color(red, green, blue, alpha);
        }
    }
}