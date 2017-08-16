using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Tulsi.NavigationFramework {
    public sealed class ViewBuider<TView> : ViewBuilderBase<TView> where TView : IView, new() {
        /// <summary>
        /// Define new instance of Xamarin.Forms.NavigationPage with target view inside.
        /// </summary>
        /// <returns></returns>
        public NavigationPage GetViewInNavigationFrame() {
            return new NavigationPage(View as Page);
        }

        /// <summary>
        /// Return target view instance.
        /// </summary>
        /// <returns></returns>
        public IView GetView() {
            return View;
        }
    }
}
