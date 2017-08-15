using System;
using System.ComponentModel;
using Android.Views;
using Tulsi.Controls;
using Tulsi.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;

[assembly: ExportRenderer(typeof(EntryEx), typeof(EntryExRenderer))]
namespace Tulsi.Droid.Renderers
{
    public class EntryExRenderer : EntryRenderer
    {
        #region Private fields and properties

        private BorderRenderer _renderer;
        private const GravityFlags DefaultGravity = GravityFlags.CenterVertical;

        #endregion

        #region Parent override

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || this.Element == null)
                return;
            Control.Gravity = DefaultGravity;
            var entryEx = Element as EntryEx;
            UpdateBackground(entryEx);
            UpdatePadding(entryEx);
            UpdateTextAlighnment(entryEx);
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            if (Element == null)
                return;
            var entryEx = Element as EntryEx;
            if (e.PropertyName == EntryEx.BorderWidthProperty.PropertyName ||
                e.PropertyName == EntryEx.BorderColorProperty.PropertyName ||
                e.PropertyName == EntryEx.BorderRadiusProperty.PropertyName ||
                e.PropertyName == EntryEx.BackgroundColorProperty.PropertyName)
            {
                UpdateBackground(entryEx);
            }
            else if (e.PropertyName == EntryEx.LeftPaddingProperty.PropertyName ||
                e.PropertyName == EntryEx.RightPaddingProperty.PropertyName)
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

        private void UpdateBackground(EntryEx entryEx)
        {
            if (_renderer != null)
            {
                _renderer.Dispose();
                _renderer = null;
            }
            _renderer = new BorderRenderer();

            Control.Background = _renderer.GetBorderBackground(entryEx.BorderColor, entryEx.BackgroundColor, entryEx.BorderWidth, entryEx.BorderRadius);
        }

        private void UpdatePadding(EntryEx entryEx)
        {
            Control.SetPadding((int)Forms.Context.ToPixels(entryEx.LeftPadding), 0,
                (int)Forms.Context.ToPixels(entryEx.RightPadding), 0);
        }

        private void UpdateTextAlighnment(EntryEx entryEx)
        {
            var gravity = DefaultGravity;
            switch (entryEx.HorizontalTextAlignment)
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
    public class BorderRenderer : IDisposable
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