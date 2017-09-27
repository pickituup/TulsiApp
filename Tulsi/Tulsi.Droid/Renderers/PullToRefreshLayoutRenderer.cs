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
using Android.Support.V4.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using PullToRefresh.Droid.Renderers;
using System.ComponentModel;
using System.Reflection;
using Tulsi.Controls;
using Tulsi.Droid.Renderers.Helpers;

[assembly: ExportRenderer(typeof(PullToRefreshLayout), typeof(PullToRefreshLayoutRenderer))]
namespace PullToRefresh.Droid.Renderers {
    [Preserve(AllMembers = true)]
    public class PullToRefreshLayoutRenderer : SwipeRefreshLayout, IVisualElementRenderer, SwipeRefreshLayout.IOnRefreshListener {

        private bool _init;
        private bool _refreshing;
        private IVisualElementRenderer _packed;
        private BindableProperty _rendererProperty = null;
        private TextView _hintLabel;
        private Android.Widget.RelativeLayout _hintLayout;
        private bool _isPreparingRefresh = false;
        private DateTime _lastRefreshDate = DateTime.Now;

        public event EventHandler<VisualElementChangedEventArgs> ElementChanged;
        public event EventHandler<PropertyChangedEventArgs> ElementPropertyChanged;

        /// <summary>
        /// 
        /// </summary>
        public PullToRefreshLayoutRenderer()
            : base(Forms.Context) { }

        /// <summary>
        /// 
        /// </summary>
        private BindableProperty RendererProperty {
            get {
                if (_rendererProperty != null)
                    return _rendererProperty;

                var type = Type.GetType("Xamarin.Forms.Platform.Android.Platform, Xamarin.Forms.Platform.Android");
                var prop = type.GetField("RendererProperty", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
                var val = prop.GetValue(null);
                _rendererProperty = val as BindableProperty;

                return _rendererProperty;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override bool Refreshing {
            get {
                return _refreshing;
            }
            set {
                try {
                    _refreshing = value;
                    //this will break binding :( sad panda we need to wait for next version for this
                    //right now you can't update the binding.. so it is 1 way
                    if (RefreshView != null && RefreshView.IsRefreshing != _refreshing) {
                        RefreshView.IsRefreshing = _refreshing;
                    }

                    if (base.Refreshing == _refreshing) {
                        return;
                    }

                    base.Refreshing = _refreshing;
                }
                catch (Exception ex) { }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public VisualElementTracker Tracker { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public VisualElement Element { get; private set; }

        /// <summary>
        /// 
        /// </summary>
        public static void Init() {
            DateTime temp = DateTime.Now;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element">Element.</param>
        public void SetElement(VisualElement element) {
            VisualElement oldElement = Element;

            if (oldElement != null) {
                oldElement.PropertyChanged -= HandlePropertyChanged;
            }

            Element = element;
            if (Element != null) {
                UpdateContent();
                Element.PropertyChanged += HandlePropertyChanged;
            }

            if (!_init) {
                _init = true;

                Tracker = new VisualElementTracker(this);
                SetOnRefreshListener(this);
            }

            //
            // TODO: remove that hardcoded values
            //
            SetProgressViewOffset(false, -80, 4);
            UpdateColors();
            UpdateIsRefreshing();
            UpdateIsSwipeToRefreshEnabled();

            if (ElementChanged != null) {
                ElementChanged(this, new VisualElementChangedEventArgs(oldElement, this.Element));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool CanChildScrollUp() =>
            CanScrollUp(_packed.ViewGroup);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="view"></param>
        /// <returns></returns>
        private bool CanScrollUp(Android.Views.View view) {
            var viewGroup = view as ViewGroup;
            if (viewGroup == null) {
                return base.CanChildScrollUp();
            }

            if (view is Android.Widget.ScrollView) {
                var scrollview = view as Android.Widget.ScrollView;

                int y = scrollview.ScrollY;
                return !(scrollview.ScrollY <= 0.0);
            }

            //var sdk = (int)global::Android.OS.Build.VERSION.SdkInt;
            //if (sdk >= 16) {
            //    if (viewGroup.IsScrollContainer) {
            //        return base.CanChildScrollUp();
            //    }
            //}

            //for (int i = 0; i < viewGroup.ChildCount; i++) {
            //    var child = viewGroup.GetChildAt(i);
            //    if (child is Android.Widget.AbsListView) {
            //        var list = child as Android.Widget.AbsListView;
            //        if (list != null) {
            //            if (list.FirstVisiblePosition == 0) {
            //                var subChild = list.GetChildAt(0);

            //                return subChild != null && subChild.Top != 0;
            //            }

            //            return true;
            //        }

            //    }
            //    else if (child is Android.Widget.ScrollView) {
            //        var scrollview = child as Android.Widget.ScrollView;
            //        return (scrollview.ScrollY <= 0.0);
            //    }
            //    else if (child is Android.Webkit.WebView) {
            //        var webView = child as Android.Webkit.WebView;
            //        return (webView.ScrollY > 0.0);
            //    }
            //    else if (child is Android.Support.V4.Widget.SwipeRefreshLayout) {
            //        return CanScrollUp(child as ViewGroup);
            //    }
            //    //else if something else like a recycler view?
            //}

            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        public PullToRefreshLayout RefreshView =>
            Element == null ? null : (PullToRefreshLayout)Element;

        /// <summary>
        /// 
        /// </summary>
        public void OnRefresh() {
            _lastRefreshDate = DateTime.Now;
            RefreshView?.RefreshCommand?.Execute(null);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void HandlePropertyChanged(object sender, PropertyChangedEventArgs e) {
            if (e.PropertyName == "Content")
                UpdateContent();
            else if (e.PropertyName == PullToRefreshLayout.IsPullToRefreshEnabledProperty.PropertyName)
                UpdateIsSwipeToRefreshEnabled();
            else if (e.PropertyName == PullToRefreshLayout.IsRefreshingProperty.PropertyName)
                UpdateIsRefreshing();
            else if (e.PropertyName == PullToRefreshLayout.RefreshColorProperty.PropertyName)
                UpdateColors();
            else if (e.PropertyName == PullToRefreshLayout.RefreshBackgroundColorProperty.PropertyName)
                UpdateColors();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="widthConstraint"></param>
        /// <param name="heightConstraint"></param>
        /// <returns></returns>
        public SizeRequest GetDesiredSize(int widthConstraint, int heightConstraint) {
            _packed.ViewGroup.Measure(widthConstraint, heightConstraint);

            //Measure child here and determine size
            return new SizeRequest(new Size(_packed.ViewGroup.MeasuredWidth, _packed.ViewGroup.MeasuredHeight));
        }

        /// <summary>
        /// 
        /// </summary>
        public void UpdateLayout() => Tracker?.UpdateLayout();

        /// <summary>
        /// 
        /// </summary>
        public Android.Views.ViewGroup ViewGroup => this;

        /// <summary>
        /// 
        /// </summary>
        public Android.Views.View View => this;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        public void SetLabelFor(int? id) { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public override bool OnTouchEvent(MotionEvent e) {
            if (e.Action == MotionEventActions.Move) {
                if (!_isPreparingRefresh) {
                    TimeSpan timeOffset = DateTime.Now - _lastRefreshDate;
                    _hintLabel.Text = string.Format("Updated {0} ago.", timeOffset.TotalMinutes < 1 ? string.Format("{0} sec", (int)timeOffset.TotalSeconds) : string.Format("{0} min", (int)timeOffset.TotalMinutes));
                }

                _isPreparingRefresh = true;
            }
            else if (e.Action == MotionEventActions.Up) {
                _isPreparingRefresh = false;
            }

            return base.OnTouchEvent(e);
        }

        /// <summary>
        /// Cleanup layout.
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing) {
            base.Dispose(disposing);

            /*if (disposing)
            {
                if (Element != null)
                {
                    Element.PropertyChanged -= HandlePropertyChanged;
                }

                if (packed != null)
                    RemoveView(packed.ViewGroup);
            }

            packed?.Dispose();
            packed = null;

            Tracker?.Dispose();
            Tracker = null;
            

            if (rendererProperty != null)
            {
                rendererProperty = null;
            }
            init = false;*/
        }

        /// <summary>
        /// 
        /// </summary>
        private void PrepareHint() {
            _hintLabel = new TextView(this.Context);
            _hintLabel.Text = "Hint label";
            Android.Widget.RelativeLayout.LayoutParams relativeLayoutParameters =
                new Android.Widget.RelativeLayout.LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);
            relativeLayoutParameters.AddRule(LayoutRules.AlignParentBottom);
            relativeLayoutParameters.AddRule(LayoutRules.CenterHorizontal);
            _hintLabel.LayoutParameters = relativeLayoutParameters;

            _hintLayout = new Android.Widget.RelativeLayout(this.Context);
            _hintLayout.LayoutParameters = new Android.Widget.RelativeLayout.LayoutParams(LayoutParams.MatchParent, 0);
            _hintLayout.SetPadding(0, 0, 0, 7);
            _hintLayout.AddView(_hintLabel);
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateContent() {
            if (RefreshView.Content == null) {
                return;
            }

            if (_packed != null) {
                RemoveView(_packed.ViewGroup);
            }

            _packed = Platform.CreateRenderer(RefreshView.Content);

            try {
                RefreshView.Content.SetValue(RendererProperty, _packed);
            }
            catch (Exception ex) {
                System.Diagnostics.Debug.WriteLine("Unable to sent renderer property, maybe an issue: " + ex);
            }

            PrepareHint();
            PrepareSwipeObserver();

            _packed.ViewGroup.LayoutParameters = new LayoutParams(LayoutParams.WrapContent, LayoutParams.WrapContent);

            Android.Widget.LinearLayout baseLinearLayout = new Android.Widget.LinearLayout(this.Context);
            baseLinearLayout.Orientation = Orientation.Vertical;
            baseLinearLayout.AddView(_hintLayout);
            baseLinearLayout.AddView(_packed.ViewGroup);

            AddView(baseLinearLayout, LayoutParams.MatchParent);
        }

        /// <summary>
        /// 
        /// </summary>
        private void PrepareSwipeObserver() {
            Android.Views.View swipeTarget = this.GetChildAt(0);

            if (swipeTarget == null) {
                return;
            }

            SwipeTargetObserver swipeTargetObserver = new SwipeTargetObserver() {
                SwipeTarget = swipeTarget,
                SwipeRefreshLayout = this,
                HintLayout = _hintLayout
            };

            swipeTarget.ViewTreeObserver.AddOnPreDrawListener(swipeTargetObserver);
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateColors() {
            if (RefreshView == null) {
                return;
            }
            if (RefreshView.RefreshColor != Color.Default) {
                SetColorSchemeColors(RefreshView.RefreshColor.ToAndroid());
            }
            if (RefreshView.RefreshBackgroundColor != Color.Default) {
                SetProgressBackgroundColorSchemeColor(RefreshView.RefreshBackgroundColor.ToAndroid());
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private void UpdateIsRefreshing() =>
            Refreshing = RefreshView.IsRefreshing;

        /// <summary>
        /// 
        /// </summary>
        private void UpdateIsSwipeToRefreshEnabled() =>
            Enabled = RefreshView.IsPullToRefreshEnabled;
    }
}