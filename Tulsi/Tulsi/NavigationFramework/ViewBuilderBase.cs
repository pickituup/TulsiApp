using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tulsi.NavigationFramework {
    public abstract class ViewBuilderBase<TView> where TView : IView, new() {
        private readonly TView _view;

        /// <summary>
        /// Protected ctor.
        /// </summary>
        protected ViewBuilderBase() {
            _view = new TView();
        }

        /// <summary>
        /// Created view.
        /// </summary>
        protected TView View => _view;
    }
}
