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
using Android.Graphics;
using Android.Support.V4.Widget;

namespace Tulsi.Droid.Renderers.Helpers {
    public class SwipeTargetObserver : Java.Lang.Object, ViewTreeObserver.IOnPreDrawListener {

        private Rect _oldBounds = new Rect(),
            _newBounds = new Rect();

        /// <summary>
        /// 
        /// </summary>
        public View SwipeTarget { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public SwipeRefreshLayout SwipeRefreshLayout { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RelativeLayout HintLayout { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public bool OnPreDraw() {
            _newBounds.Set(SwipeTarget.Left, SwipeRefreshLayout.Top, SwipeTarget.Right, SwipeTarget.Bottom);

            //Console.WriteLine("---------------> {0}", _newBounds.Height());
            //Console.WriteLine("========================> {0}", _newBounds.Height());
            Console.WriteLine("---------------> CircleControl {0}", SwipeTarget.Height);
            Console.WriteLine("========================> HintLayout {0}", HintLayout.Height);
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~> HintText {0}", HintLayout.GetChildAt(0).Height);

            if (!_oldBounds.Equals(_newBounds)) {

                //
                // TODO: remove that hardcoded values
                //
                if ((_newBounds.Height() + 108) < 0) {
                    HintLayout.LayoutParameters.Height = 0;
                }
                else {
                    //
                    // TODO: remove that hardcoded values
                    //
                    HintLayout.LayoutParameters.Height = (int)((_newBounds.Height() + 108) * 1.75);
                }

                HintLayout.Invalidate();
                HintLayout.RequestLayout();

                _oldBounds.Set(_newBounds);
            }

            return true;
        }
    }
}