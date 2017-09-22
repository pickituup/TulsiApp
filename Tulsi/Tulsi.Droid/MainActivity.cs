using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Util;
using Android.Content;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Tulsi.SharedService;

[assembly: Xamarin.Forms.Dependency(typeof(Tulsi.Droid.DisplaySizeOnAndroid))]

namespace Tulsi.Droid {
    [Activity(Label = "Tulsi", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.SensorPortrait, ConfigurationChanges = ConfigChanges.ScreenSize)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity {
        /// <summary>
        /// For test commit and bla bla bla
        /// </summary>
        /// <param name="bundle"></param>
        protected override void OnCreate(Bundle bundle) {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            XamForms.Controls.Droid.Calendar.Init();
            LoadApplication(new App()); 
        }
    }

    public class DisplaySizeOnAndroid : IDisplaySize {
        public DisplaySizeOnAndroid() {
        }

        public int GetWidth() {
            DisplayMetrics metrics = Android.App.Application.Context.Resources.DisplayMetrics;
            return metrics.WidthPixels;
        }
        public int GetHeight() {
            DisplayMetrics metrics = Android.App.Application.Context.Resources.DisplayMetrics;
            return metrics.HeightPixels;
        }
        public int GetWidthDiP() {
            DisplayMetrics metrics = Android.App.Application.Context.Resources.DisplayMetrics;
            int dp = (int)((metrics.WidthPixels) / metrics.Density);
            return dp;
        }
        public int GetHeightDiP() {
            DisplayMetrics metrics = Android.App.Application.Context.Resources.DisplayMetrics;
            int dp = (int)((metrics.HeightPixels) / metrics.Density);
            return dp;
        }
        public float GetDensity() {
            DisplayMetrics metrics = Android.App.Application.Context.Resources.DisplayMetrics;
            return metrics.Density;
        }
    }
}

