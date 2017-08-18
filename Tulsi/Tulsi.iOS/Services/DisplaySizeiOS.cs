using Tulsi.iOS.Services;
using Tulsi.SharedService;
using UIKit;
using Xamarin.Forms;

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