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
using Tulsi.SharedService;
using System.Resources;

[assembly: Xamarin.Forms.Dependency(typeof(Tulsi.Droid.DependencyServices.DeviceServices))]
namespace Tulsi.Droid.DependencyServices {
    public class DeviceServices : IDeviceServices {

        /// <summary>
        /// Toggles screen mode (full screen - no status bar; default - with status bar).
        /// </summary>
        /// <param name="isFullScreenMode"></param>
        public void ToggleScreenMode(bool isFullScreenMode) {
            if (isFullScreenMode) {
                HideStatusBar();
                return;
            }

            DisplayStatusBar();
        }

        /// <summary>
        /// Change status bar background to the appropriate hex color. 
        /// null/empty hex color will use default color from android resources.
        /// If hexColor is null or empty the default resources color will be used.
        /// </summary>
        /// <param name="hexColor"></param>
        public void ChangeStatusBarColor(string hexColor) {
            if (string.IsNullOrEmpty(hexColor)) {
                ((MainActivity)Xamarin.Forms.Forms.Context).Window.SetStatusBarColor(new Android.Graphics.Color(Android.Support.V4.Content.ContextCompat.GetColor(Xamarin.Forms.Forms.Context, Resource.Color.default_blue_color)));
                return;
            }

            ((MainActivity)Xamarin.Forms.Forms.Context).Window.SetStatusBarColor(Android.Graphics.Color.ParseColor(hexColor));
        }

        /// <summary>
        /// 
        /// </summary>
        private void DisplayStatusBar() =>
            ((MainActivity)Xamarin.Forms.Forms.Context).Window.ClearFlags(WindowManagerFlags.Fullscreen);

        /// <summary>
        /// 
        /// </summary>
        private void HideStatusBar() =>
            ((MainActivity)Xamarin.Forms.Forms.Context).Window.AddFlags(WindowManagerFlags.Fullscreen);
    }
}