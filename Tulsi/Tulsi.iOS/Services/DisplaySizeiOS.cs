using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Tulsi.iOS.Services;

[assembly: Dependency(typeof(DisplaySizeiOS))]
namespace Tulsi.iOS.Services {
    public sealed class DisplaySizeiOS : IDisplaySize {

        public float GetDensity() {
            return default(float);
        }

        public int GetHeight() {
            return default(int);
        }

        public int GetHeightDiP() {
            return default(int);
        }

        public int GetWidth() {
            var tt = UIScreen.MainScreen.Bounds;
            return default(int);
        }

        public int GetWidthDiP() {
            var screenSize = UIScreen.MainScreen.Bounds;
            return (int)screenSize.Width;
        }
    }
}