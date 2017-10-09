using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Tulsi.iOS.Renderers;
using Tulsi.Controls;
using System.ComponentModel;
using Xamarin.Forms.Platform.iOS;
using System.Diagnostics;

[assembly: ExportRenderer(typeof(PullToRefreshLayout), typeof(PullToRefreshLayoutRenderer))]
namespace Tulsi.iOS.Renderers {
    /// <summary>
    /// Pull to refresh layout renderer.
    /// </summary>
    [Preserve(AllMembers = true)]
    public sealed class PullToRefreshLayoutRenderer : ViewRenderer<PullToRefreshLayout, UIView> {
        /// <summary>
        /// Used for registration with dependency service
        /// </summary>
        public async static void Init() {
            var temp = DateTime.Now;
        }

        private UIRefreshControl _refreshControl;

        private UIScrollView _uiScrollView;

        private UIWebView _uiWebView;

        private UITableView _uiTableView;

        private UICollectionView _uiCollectionView;

        private DateTime _lastRefreshDate = DateTime.Now;

        private string _title = string.Empty;

        /// <summary>
        /// Raises the element changed event.
        /// </summary>
        /// <param name="e">E.</param>
        protected override void OnElementChanged(ElementChangedEventArgs<PullToRefreshLayout> e) {
            base.OnElementChanged(e);

            if (e.OldElement != null || Element == null)
                return;

            if (e.NewElement != null) {
                // Configure the control and subscribe to event handlers
                _refreshControl = new UIRefreshControl();

                _refreshControl.AttributedTitle = new NSAttributedString("Hello motherfucker");

                _refreshControl.ValueChanged += OnRefresh;

                try {
                    TryInsertRefresh(this);
                } catch (Exception ex) {
                    Debug.WriteLine("View is not supported in PullToRefreshLayout: " + ex);
                }

                UpdateColors();
                UpdateIsRefreshing();
                UpdateIsSwipeToRefreshEnabled();
            }
        }

        private bool TryInsertRefresh(UIView view, int index = 0) {
            if (view is UITableView) {
                _uiTableView = view as UITableView;
                view.InsertSubview(_refreshControl, index);
                return true;
            }

            if (view is UICollectionView) {
                _uiCollectionView = view as UICollectionView;
                view.InsertSubview(_refreshControl, index);
                return true;
            }

            _uiWebView = view as UIWebView;
            if (_uiWebView != null) {
                _uiWebView.ScrollView.InsertSubview(_refreshControl, index);
                return true;
            }

            _uiScrollView = view as UIScrollView;
            if (_uiScrollView != null) {
                view.InsertSubview(_refreshControl, index);
                _uiScrollView.AlwaysBounceVertical = true;
                return true;
            }

            if (view.Subviews == null)
                return false;

            for (int i = 0; i < view.Subviews.Length; i++) {
                var control = view.Subviews[i];
                if (TryInsertRefresh(control, i))
                    return true;
            }

            return false;
        }

        private BindableProperty _rendererProperty;

        /// <summary>
        /// Gets the bindable property.
        /// </summary>
        /// <returns>The bindable property.</returns>
        private BindableProperty RendererProperty {
            get {
                if (_rendererProperty != null)
                    return _rendererProperty;

                var type = Type.GetType("Xamarin.Forms.Platform.iOS.Platform, Xamarin.Forms.Platform.iOS");
                var prop = type.GetField("RendererProperty");
                var val = prop.GetValue(null);
                _rendererProperty = val as BindableProperty;

                return _rendererProperty;
            }
        }

        private void UpdateColors() {
            if (RefreshView == null)
                return;
            if (RefreshView.RefreshColor != Color.Default)
                _refreshControl.TintColor = RefreshView.RefreshColor.ToUIColor();
            if (RefreshView.RefreshBackgroundColor != Color.Default)
                _refreshControl.BackgroundColor = RefreshView.RefreshBackgroundColor.ToUIColor();
        }

        private void UpdateIsRefreshing() {
            IsRefreshing = RefreshView.IsRefreshing;
        }

        private void UpdateIsSwipeToRefreshEnabled() {
            _refreshControl.Enabled = RefreshView.IsPullToRefreshEnabled;
        }

        /// <summary>
        /// Helpers to cast our element easily
        /// Will throw an exception if the Element is not correct
        /// </summary>
        /// <value>The refresh view.</value>
        public PullToRefreshLayout RefreshView {
            get { return Element; }
        }

        private bool _isRefreshing;
        /// <summary>
        /// Gets or sets a value indicating whether this instance is refreshing.
        /// </summary>
        /// <value><c>true</c> if this instance is refreshing; otherwise, <c>false</c>.</value>
        public bool IsRefreshing {
            get { return _isRefreshing; }
            set {
                _isRefreshing = value;
                if (_isRefreshing)
                    _refreshControl.BeginRefreshing();
                else {
                    _refreshControl.EndRefreshing();
                    _lastRefreshDate = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// The refresh view has been refreshed
        /// </summary>
        private void OnRefresh(object sender, EventArgs e) {
            //someone pulled down to refresh or it is done
            if (RefreshView == null)
                return;

            TimeSpan timeOffset = DateTime.Now - _lastRefreshDate;
            SetRefreshingTime(timeOffset);

            var command = RefreshView.RefreshCommand;
            if (command == null)
                return;

            command.Execute(null);
        }

        private void SetRefreshingTime(TimeSpan timeOffset) {
            _title = string.Format("Updated {0} ago.", timeOffset.TotalMinutes < 1 ? string.Format("{0} sec", (int)timeOffset.TotalSeconds) : string.Format("{0} min", (int)timeOffset.TotalMinutes));
            _refreshControl.AttributedTitle = new NSAttributedString(_title);
        }

        /// <summary>
        /// Raises the element property changed event.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);
            if (e.PropertyName == PullToRefreshLayout.IsPullToRefreshEnabledProperty.PropertyName)
                UpdateIsSwipeToRefreshEnabled();
            else if (e.PropertyName == PullToRefreshLayout.IsRefreshingProperty.PropertyName)
                UpdateIsRefreshing();
            else if (e.PropertyName == PullToRefreshLayout.RefreshColorProperty.PropertyName)
                UpdateColors();
            else if (e.PropertyName == PullToRefreshLayout.RefreshBackgroundColorProperty.PropertyName)
                UpdateColors();
        }

        /// <summary>
        /// Dispose the specified disposing.
        /// </summary>
        /// <param name="disposing">If set to <c>true</c> disposing.</param>
        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);
            if (_refreshControl != null) {
                _refreshControl.ValueChanged -= OnRefresh;
            }

            _uiTableView = null;
            _uiCollectionView = null;
            _uiWebView = null;
            _uiScrollView = null;
        }
    }
}