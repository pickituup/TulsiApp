using System;
using System.ComponentModel;
using Android.Views;
using Android.Graphics.Drawables;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Tulsi.Controls;
using Tulsi.Droid.Renderers;

[assembly: ExportRenderer(typeof(RoundedView), typeof(RoundedViewRenderer))]
namespace Tulsi.Droid.Renderers
{
    public class RoundedViewRenderer : LabelRenderer
    {
        #region Private fields and properties

        private LabelBorderRenderer _renderer;
        private const GravityFlags DefaultGravity = GravityFlags.CenterVertical;

        #endregion

        #region Parent override

        protected override void OnAttachedToWindow()
        {
            base.OnAttachedToWindow();

            Control.Gravity = DefaultGravity;
            var entryEx = Element as RoundedView;
            UpdateBackground(entryEx);
            UpdatePadding(entryEx);
            UpdateTextAlighnment(entryEx);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Element == null)
                return;
            var entryEx = Element as RoundedView;
            if (e.PropertyName == RoundedView.BorderWidthProperty.PropertyName ||
                e.PropertyName == RoundedView.BorderColorProperty.PropertyName ||
                e.PropertyName == RoundedView.BorderRadiusProperty.PropertyName ||
                e.PropertyName == RoundedView.BackgroundColorProperty.PropertyName)
            {
                UpdateBackground(entryEx);
            }
            else if (e.PropertyName == RoundedView.LeftPaddingProperty.PropertyName ||
                e.PropertyName == RoundedView.RightPaddingProperty.PropertyName)
            {
                UpdatePadding(entryEx);
            }
            else if (e.PropertyName == Entry.HorizontalTextAlignmentProperty.PropertyName)
            {
                UpdateTextAlighnment(entryEx);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                if (_renderer != null)
                {
                    _renderer.Dispose();
                    _renderer = null;
                }
            }
        }

        #endregion

        #region Utility methods

        private void UpdateBackground(RoundedView RView)
        {
            if (_renderer != null)
            {
                _renderer.Dispose();
                _renderer = null;
            }
            _renderer = new LabelBorderRenderer();

            Control.Background = _renderer.GetBorderBackground(RView.BorderColor, RView.BorderColor, RView.BorderWidth, RView.BorderRadius);
        }

        private void UpdatePadding(RoundedView entryEx)
        {
            Control.SetPadding((int)Forms.Context.ToPixels(entryEx.LeftPadding), 0,
                (int)Forms.Context.ToPixels(entryEx.RightPadding), 0);
        }

        private void UpdateTextAlighnment(RoundedView RView)
        {
            var gravity = DefaultGravity;
            switch (RView.HorizontalTextAlignment)
            {
                case Xamarin.Forms.TextAlignment.Start:
                    gravity |= GravityFlags.Start;
                    break;
                case Xamarin.Forms.TextAlignment.Center:
                    gravity |= GravityFlags.CenterHorizontal;
                    break;
                case Xamarin.Forms.TextAlignment.End:
                    gravity |= GravityFlags.End;
                    break;
            }
            Control.Gravity = gravity;
        }

        #endregion
    }
    public class LabelBorderRenderer : IDisposable
    {
        #region Parent override

        private GradientDrawable _background;

        #endregion

        #region IDisposable

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_background != null)
                {
                    _background.Dispose();
                    _background = null;
                }
            }
        }

        #endregion

        #region Public API

        public Drawable GetBorderBackground(Color borderColor, Color backgroundColor, float borderWidth, float borderRadius)
        {
            if (_background != null)
            {
                _background.Dispose();
                _background = null;
            }
            borderWidth = borderWidth > 0 ? borderWidth : 0;
            borderRadius = borderRadius > 0 ? borderRadius : 0;
            borderColor = borderColor != Color.Default ? borderColor : Color.Transparent;
            backgroundColor = backgroundColor != Color.Default ? backgroundColor : Color.Transparent;

            var strokeWidth = Xamarin.Forms.Forms.Context.ToPixels(borderWidth);
            var radius = Xamarin.Forms.Forms.Context.ToPixels(borderRadius);
            _background = new GradientDrawable();
            _background.SetColor(backgroundColor.ToAndroid());
            if (radius > 0)
                _background.SetCornerRadius(radius);
            if (borderColor != Color.Transparent && strokeWidth > 0)
            {
                _background.SetStroke((int)strokeWidth, borderColor.ToAndroid());
            }
            return _background;
        }

        #endregion
    }
}