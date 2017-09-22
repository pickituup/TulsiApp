using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tulsi.SharedService {

    /// <summary>
    /// Includes common and simple device opportunities
    /// </summary>
    public interface IDeviceServices {

        /// <summary>
        /// Toggles screen mode (full screen - no status bar; default - with status bar)
        /// </summary>
        /// <param name="isFullScreenMode"></param>
        void ToggleScreenMode(bool isFullScreenMode);

        /// <summary>
        /// Change status bar background to the appropriate hex color. 
        /// null/empty hex color will use default color from android resources.
        /// </summary>
        /// <param name="hexColor"></param>
        void ChangeStatusBarColor(string hexColor);
    }
}
