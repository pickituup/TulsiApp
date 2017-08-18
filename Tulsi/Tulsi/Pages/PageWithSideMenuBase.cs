using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SlideOverKit;

namespace Tulsi.Pages {
    /// <summary>
    /// Represents page with side menu.
    /// 
    /// TODO: try to define visualsation standart for ActionBar 
    /// (page header with side menu button, title and possible search) which prevents some DRY wen defining ActionBar.
    /// </summary>
    public abstract class PageWithSideMenuBase : MenuContainerPage {
        /// <summary>
        ///     Public ctor.
        /// </summary>
        public PageWithSideMenuBase() {
            SlideMenu = new SideMenuView();
        }
    }
}
